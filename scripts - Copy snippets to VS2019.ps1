# This script copies the item and project templates from 
# /snippets to the %documents%\Visual Studio 2019\Code Snippets
# directory so they can be edited and tested

$vsVersion = "2019"
$vsName = "Visual Studio " + $vsVersion
$vsSnippetsPath = [Environment]::GetFolderPath('MyDocuments') + "\" + $vsName + "\Code Snippets\Visual C#\My Code Snippets\Catel\"
$sourceDirectory = "snippets\C#\"

$snippets = Get-ChildItem -Path $sourceDirectory -File -Name

Write-Host Using snippets path: $vsSnippetsPath

[system.io.directory]::CreateDirectory($vsSnippetsPath)

foreach ($snippet in $snippets)
{
    $source = $sourceDirectory + $snippet
    $target = $vsSnippetsPath + $snippet

    Write-Host Copying snippet $snippet to $target

    if (Test-Path $target)
    {
        Get-ChildItem -Path $target -Recurse | Remove-Item -force -recurse
        Remove-Item $target
    }
    
    Copy-Item $source -Filter * -Destination $target -Recurse
}