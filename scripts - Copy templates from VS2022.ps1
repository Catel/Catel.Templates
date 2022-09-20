# This script copies the item and project templates from 
# %documents%\Visual Studio 2022\Templates to the /templates
# directory so they can be checked in into source control

$projectTemplates = "Catel.WPF.Application", "Orchestra.Shell.MahApps.Application", "Orchestra.Shell.Ribbon.Fluent.Application"
$itemTemplates = "Catel.ViewModel", "Catel.WPF.DataWindow", "Catel.WPF.UserControl"

$vsVersion = "2022"
$vsName = "Visual Studio " + $vsVersion
$vsTemplatesPath = [Environment]::GetFolderPath('MyDocuments') + "\" + $vsName + "\Templates\"
$sourceDirectory = "templates\C#\"

Write-Host Using templates path: $vsTemplatesPath

$projectTemplatesPath = $vsTemplatesPath + "ProjectTemplates\Visual C#\"
$itemTemplatesPath = $vsTemplatesPath + "ItemTemplates\Visual C#\"

foreach ($projectTemplate in $projectTemplates)
{
    $source = $projectTemplatesPath + $projectTemplate
    $target = $sourceDirectory + "ProjectTemplates\" + $projectTemplate

    Write-Host Copying project template $projectTemplate to $target

    if (Test-Path $target)
    {
        Get-ChildItem -Path $target -Recurse | Remove-Item -force -recurse
        Remove-Item $target
    }
    
    Copy-Item $source -Filter * -Destination $target -Recurse
}

foreach ($itemTemplate in $itemTemplates)
{
    $source = $itemTemplatesPath + $itemTemplate
    $target = $sourceDirectory + "ItemTemplates\" + $itemTemplate

    Write-Host Copying item template $itemTemplate to $target

    if (Test-Path $target)
    {
        Get-ChildItem -Path $target -Recurse | Remove-Item -force -recurse
        Remove-Item $target
    }
    
    Copy-Item $source -Filter * -Destination $target -Recurse
}