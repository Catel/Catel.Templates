# This script copies the item and project templates to the template projects so
# they can be uploaded to the visual studio gallery

$projectTemplates = @{
    "Catel.WPF.Application" = "Catel.ProjectTemplates.WPF.Application\ProjectTemplates\CSharp\Windows\";
    "Orchestra.MahApps.Application" = "Orchestra.ProjectTemplates.MahApps.Application\ProjectTemplates\CSharp\Windows\";
    "Orchestra.Ribbon.Fluent.Application" = "Orchestra.ProjectTemplates.Ribbon.Fluent.Application\ProjectTemplates\CSharp\Windows\";
 }

$itemTemplates = @{
    "Catel.ViewModel" = "Catel.ItemTemplates.ViewModel\ItemTemplates\CSharp\General\";
    "Catel.WPF.DataWindow" = "Catel.ItemTemplates.WPF.DataWindow\ItemTemplates\CSharp\WPF\";
    "Catel.WPF.UserControl" = "Catel.ItemTemplates.WPF.UserControl\ItemTemplates\CSharp\WPF\";
}

$sourceDirectory = "templates\C#\"
$targetDirectory = "src\"

foreach ($templateName in $projectTemplates.Keys)
{
    $templateTarget = $projectTemplates[$templateName]

    $source = $sourceDirectory + "ProjectTemplates\" + $templateName
    $target = $targetDirectory + $templateTarget + $templateName + ".zip"

    Write-Host Copying project template $templateName to $target

    Compress-Archive -Path $source\* -CompressionLevel Fastest -DestinationPath $target -Force
}

foreach ($templateName in $itemTemplates.Keys)
{
    $templateTarget = $itemTemplates[$templateName]

    $source = $sourceDirectory + "ItemTemplates\" + $templateName
    $target = $targetDirectory + $templateTarget + $templateName + ".zip"

    Write-Host Copying item template $templateName to $target

    Compress-Archive -Path $source\* -CompressionLevel Fastest -DestinationPath $target -Force
}