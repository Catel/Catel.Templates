# This script copies the item and project templates from 
# %documents%\Visual Studio 2019\Templates to the /templates
# directory so they can be checked in into source control

$vsVersion = "2019"
$vsName = "Visual Studio " + $vsVersion
$vsSnippetsPath = [Environment]::GetFolderPath('MyDocuments') + "\" + $vsName + "\Code Snippets\Visual C#\Catel\"
$sourceDirectory = "snippets\C#\"

$snippets = Get-ChildItem -Path $vsSnippetsPath -File -Name

Write-Host Using snippets path: $vsSnippetsPath

foreach ($snippet in $snippets)
{
    $source = $vsSnippetsPath + $snippet
    $target = $sourceDirectory + $snippet

    Write-Host Copying snippet $snippet to $target

    if (Test-Path $target)
    {
        Get-ChildItem -Path $target -Recurse | Remove-Item -force -recurse
        Remove-Item $target
    }
    
    Copy-Item $source -Filter * -Destination $target -Recurse
}