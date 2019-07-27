#l "vsextensions-variables.cake"

#addin "nuget:?package=Cake.FileHelpers&version=3.0.0"

using System.Xml.Linq;

//-------------------------------------------------------------

private void ValidateVsExtensionsInput()
{
    // No validation required (yet)
}

//-------------------------------------------------------------

private bool HasVsExtensions()
{
    return VsExtensions != null && VsExtensions.Count > 0;
}

//-------------------------------------------------------------

private async Task PrepareForVsExtensionsAsync()
{
    if (!HasVsExtensions())
    {
        return;
    }

    // Check whether projects should be processed, `.ToList()` 
    // is required to prevent issues with foreach
    foreach (var vsExtension in VsExtensions.ToList())
    {
        if (!ShouldProcessProject(vsExtension))
        {
            VsExtensions.Remove(vsExtension);
        }
    }
}

//-------------------------------------------------------------

private void UpdateInfoForVsExtensions()
{
    if (!HasVsExtensions())
    {
        return;
    }

    foreach (var vsExtension in VsExtensions)
    {
        Information("Updating version for vs extension '{0}'", vsExtension);

        var projectDirectory = GetProjectDirectory(vsExtension);

        // Step 1: update vsix manifest
        var vsixManifestFileName = string.Format("{0}\\source.extension.vsixmanifest", projectDirectory);

        TransformConfig(vsixManifestFileName, new TransformationCollection 
        {
            { "PackageManifest/Metadata/Identity/@Version", VersionMajorMinorPatch },
            { "PackageManifest/Metadata/Identity/@Publisher", VsExtensionsPublisherName }
        });

        // Step 2: update vs gallery manifest
        var vsGalleryManifestFileName = string.Format("{0}\\source.extension.vsgallerymanifest", projectDirectory);

        var fileContents = System.IO.File.ReadAllText(vsGalleryManifestFileName);

        fileContents = fileContents.Replace("[PUBLISHERNAME]", VsExtensionsPublisherName);

        System.IO.File.WriteAllText(vsGalleryManifestFileName, fileContents);
    }
}

//-------------------------------------------------------------

private void BuildVsExtensions()
{
    if (!HasVsExtensions())
    {
        return;
    }
    
    foreach (var vsExtension in VsExtensions)
    {
        LogSeparator("Building vs extension '{0}'", vsExtension);

        var projectFileName = GetProjectFileName(vsExtension);
        
        var msBuildSettings = new MSBuildSettings {
            Verbosity = Verbosity.Quiet,
            //Verbosity = Verbosity.Diagnostic,
            ToolVersion = MSBuildToolVersion.Default,
            Configuration = ConfigurationName,
            MSBuildPlatform = MSBuildPlatform.x86, // Always require x86, see platform for actual target platform
            PlatformTarget = PlatformTarget.MSIL
        };

        ConfigureMsBuild(msBuildSettings, vsExtension);
        
        // Note: we need to set OverridableOutputPath because we need to be able to respect
        // AppendTargetFrameworkToOutputPath which isn't possible for global properties (which
        // are properties passed in using the command line)
        var outputDirectory = GetProjectOutputDirectory(vsExtension);
        Information("Output directory: '{0}'", outputDirectory);
        msBuildSettings.WithProperty("OverridableOutputPath", outputDirectory);
        msBuildSettings.WithProperty("PackageOutputPath", OutputRootDirectory);

        MSBuild(projectFileName, msBuildSettings);
    }
}

//-------------------------------------------------------------

private void PackageVsExtensions()
{
    if (!HasVsExtensions())
    {
        return;
    }

    // No packaging required
}

//-------------------------------------------------------------

private async Task DeployVsExtensionsAsync()
{
    if (!HasVsExtensions())
    {
        return;
    }

    foreach (var vsExtension in VsExtensions)
    {
        if (!ShouldDeployProject(vsExtension))
        {
            Information("Vs extension '{0}' should not be deployed", vsExtension);
            continue;
        }

        LogSeparator("Deploying vs extension '{0}'", vsExtension);

        // var packageToPush = string.Format("{0}/{1}.{2}.nupkg", OutputRootDirectory, tool, VersionNuGet);
        // var nuGetRepositoryUrls = GetToolsNuGetRepositoryUrls(tool);
        // var nuGetRepositoryApiKeys = GetToolsNuGetRepositoryApiKeys(tool);


        await NotifyAsync(vsExtension, string.Format("Deployed to Visual Studio Gallery"), TargetType.VsExtension);
    }
}

//-------------------------------------------------------------

Task("UpdateInfoForVsExtensions")
    .IsDependentOn("Clean")
    .Does(() =>
{
    UpdateSolutionAssemblyInfo();
    UpdateInfoForVsExtensions();
});

//-------------------------------------------------------------

Task("BuildVsExtensions")
    .IsDependentOn("UpdateInfoForVsExtensions")
    .Does(() =>
{
    BuildVsExtensions();
});

//-------------------------------------------------------------

Task("PackageVsExtensions")
    .IsDependentOn("BuildVsExtensions")
    .Does(() =>
{
    PackageVsExtensions();
});

//-------------------------------------------------------------

Task("DeployVsExtensions")
    .IsDependentOn("PackageVsExtensions")
    .Does(async () =>
{
    await DeployVsExtensionsAsync();
});