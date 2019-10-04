Catel.Templates
===============

This repository contains the item and project templates for Catel.

## How to ensure local templates show up

Open the Visual Studio command prompt in administrator mode and run the command below:

```
devenv /installvstemplates
```

## How to contribute?

We love improvements to the templates via contributions. Below
is a guide that should help you set up your environment.

1. Copy the templates from the repository to VS 2019

Use the `scripts - Copy templates to VS2019.ps1` script or manually copy the templates from `/templates/` to `%documents%\Visual Studio 2019\`.

**Note that they should be put in the right directory. If you are not sure, always use the script.**

2. Update and test the templates

To customize the templates, edit the files in `%documents%\Visual Studio 2019\Templates`.

Once customized, you can directly test them in Visual Studio.

3. Copy the changes back

To copy the updated templates back to the solution, use the script `scripts - Copy templates from VS2019.ps1` or manually copy the templates from `%documents%\Visual Studio 2019\` to `/templates/`.

4. Zip the templates and copy the templates to the VSIX projects

To zip and copy the templates, use the script `scripts - Copy templates to VSIX projects.ps1`

5. Create a PR (Pull Request) with the changes for review.