# This script copies the item and project templates from 
# /templates to the %documents%\Visual Studio 2019\Templates
# directory so they can be edited and tested

$projectTemplates = "Catel.WPF.Application"
$itemTemplates = "Catel.ViewModel", "Catel.WPF.DataWindow", "Catel.WPF.UserControl"

$vsVersion = "2019"
$vsName = "Visual Studio " + $vsVersion
$vsTemplatesPath = [Environment]::GetFolderPath('MyDocuments') + "\" + $vsName + "\Templates\"
$sourceDirectory = "templates\C#\"

Write-Host Using templates path: $vsTemplatesPath

$projectTemplatesPath = $vsTemplatesPath + "ProjectTemplates\Visual C#\"
$itemTemplatesPath = $vsTemplatesPath + "ItemTemplates\Visual C#\"

foreach ($projectTemplate in $projectTemplates)
{
    $source = $sourceDirectory + "ProjectTemplates\" + $projectTemplate
    $target = $projectTemplatesPath + $projectTemplate

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
    $source = $sourceDirectory + "ItemTemplates\" + $itemTemplate
    $target = $itemTemplatesPath + $itemTemplate

    Write-Host Copying item template $itemTemplate to $target

    if (Test-Path $target)
    {
        Get-ChildItem -Path $target -Recurse | Remove-Item -force -recurse
        Remove-Item $target
    }
    
    Copy-Item $source -Filter * -Destination $target -Recurse
}