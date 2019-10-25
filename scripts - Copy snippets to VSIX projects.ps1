# This script copies the item and project templates to the template projects so
# they can be uploaded to the visual studio gallery

$sourceDirectory = "snippets\C#\"
$targetDirectory = "src\Catel.CodeSnippets\Snippets\CSharp\Catel\"
$snippets = Get-ChildItem -Path $sourceDirectory -File -Name

Write-Host Using snippets path: $sourceDirectory

foreach ($snippet in $snippets)
{
    $source = $sourceDirectory + $snippet
    $target = $targetDirectory + $snippet

    Write-Host Copying snippet $snippet to $target

    if (Test-Path $target)
    {
        Get-ChildItem -Path $target -Recurse | Remove-Item -force -recurse
        Remove-Item $target
    }
    
    Copy-Item $source -Filter * -Destination $target -Recurse
}