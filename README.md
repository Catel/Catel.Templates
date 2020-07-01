Catel.Templates
===============

This repository contains the item and project templates for Catel.

The easiest way to get the code snippets is by installing them via the <a href="https://marketplace.visualstudio.com/items?itemName=Catel.Catel-CodeSnippets" target="_blank">Visual Studio Marketplace</a>.

## Code Snippets

### Log

Generates a static `ILog` instance for the current class.

Usage: `log`

Output:

```
private static readonly ILog Log = LogManager.GetCurrentClassLogger();
```

### Model

Creates a new model based on the `ModelBase` class.

Usage: `model`

Output:

```
[Serializable]
public class MyModel : ModelBase
{
    public MyModel()
    {
    }

    // TODO: Define your custom properties here using the 'modelprop' code snippet
}

```

### Model property

Creates a model property for a class based on `ModelBase`.

Usage: `modelprop` or `modelpropfody`

Output:

```
public string FirstName
{
    get { return GetValue<string>(FirstNameProperty); }
    set { SetValue(FirstNameProperty, value); }
}

public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), null);
```

### Model property with change notifications

Creates a model property for a class based on `ModelBase` and includes a property change notification method.

Usage: `modelpropchanged` or `modelpropchangedfody`

Output:

```
public string FirstName
{
    get { return GetValue<string>(FirstNameProperty); }
    set { SetValue(FirstNameProperty, value); }
}

public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), null, (sender, e) => ((ContainingClass)sender).OnFirstNameChanged());

private void OnFirstNameChanged()
{
    // TODO: Implement logic
}
```

### View model

Creates a view model class based on the `ViewModelBase`.

Usage: `vm`

Output:

```
public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
    }

    public override string Title { get { return "Main"; } }

    // TODO: Register properties using 'vmprop'
    // TODO: Register properties that represent models using 'vmpropmodel'
    // TODO: Register properties that map to models using 'vmpropviewmodeltomodel'
    // TODO: Register commands using 'vmcommand', 'vmcommandwithcanexecute', 'vmtaskcommand' or 'vmtaskcommandwithcanexecute'

    protected override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        // TODO: Add initialization logic like subscribing to events
    }

    protected override async Task CloseAsync()
    {
        // TODO: Add uninitialization logic like unsubscribing from events

        await base.CloseAsync();
    }
}
```

### View model property

Creates a view model class based on the `ViewModelBase`.

Usage: `vmprop` or `vmpropfody`

Output:

```
public string FirstName
{
    get { return GetValue<string>(FirstNameProperty); }
    set { SetValue(FirstNameProperty, value); }
}

public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), null);
```

### View model property with change notifications

Creates a view model property for a class based on `ViewModelBase` and includes a property change notification method.

Usage: `vmpropchanged` or `vmpropchangedfody`

Output:

```
public string FirstName
{
    get { return GetValue<string>(FirstNameProperty); }
    set { SetValue(FirstNameProperty, value); }
}

public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string), null, (sender, e) => ((ContainingClass)sender).OnFirstNameChanged());

private void OnFirstNameChanged()
{
    // TODO: Implement logic
}
```

### View model property as model

Creates a view model property decorated with the `Model` attribute.

Usage: `vmpropmodel` or `vmpropmodelfody`

Output:

```
[Model]
public Human Person
{
    get { return GetValue<Human>(PersonProperty); }
    private set { SetValue(PersonProperty, value); }
}

public static readonly PropertyData PersonProperty = RegisterProperty(nameof(Person), typeof(Human));
```

### View model property with view model to model mapping

Creates a view model property with a mapping to a model.

Usage: `vmpropviewmodeltomodel` or `vmpropviewmodeltomodelfody`

Output:

```
[ViewModelToModel(nameof(Person))]
public string FirstName
{
    get { return GetValue<string>(FirstNameProperty); }
    set { SetValue(FirstNameProperty, value); }
}

public static readonly PropertyData FirstNameProperty = RegisterProperty(nameof(FirstName), typeof(string));
```

### View model command

Creates a view model command with an execute method.

Usage: `vmcommand`

Output:

```
public Command MyCommand { get; private set; }

// TODO: Move code below to constructor
MyCommand = new Command(OnMyCommandExecute);
// TODO: Move code above to constructor

private void OnMyCommandExecute()
{
    // TODO: Handle command logic here
}
```

### View model command with can execute

Creates a view model command with an execute and can execute method.

Usage: `vmcommandwithcanexecute`

Output:

```
public Command MyCommand { get; private set; }

// TODO: Move code below to constructor
MyCommand = new Command(OnMyCommandExecute, OnMyCommandCanExecute);
// TODO: Move code above to constructor

private bool OnMyCommandCanExecute()
{
    return true;
}

private void OnMyCommandExecute()
{
    // TODO: Handle command logic here
}
```

### View model task command

Creates a view model task-based command with an execute method.

Usage: `vmtaskcommand`

Output:

```
public TaskCommand MyCommand { get; private set; }

// TODO: Move code below to constructor
MyCommand = new TaskCommand(OnMyCommandExecuteAsync);
// TODO: Move code above to constructor

private async Task OnMyCommandExecuteAsync()
{
    // TODO: Handle command logic here
}
```

### View model task command with can execute

Creates a view model task-based command with an execute and can execute method.

Usage: `vmtaskcommandwithcanexecute`

Output:

```
public TaskCommand MyCommand { get; private set; }

// TODO: Move code below to constructor
MyCommand = new TaskCommand(OnMyCommandExecuteAsync, OnMyCommandCanExecute);
// TODO: Move code above to constructor

private bool OnMyCommandCanExecute()
{
    return true;
}

private async Task OnMyCommandExecuteAsync()
{
    // TODO: Handle command logic here
}
```

## Templates

TODO: Describe all templates

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