namespace $safeprojectname$.Services
{
    using System.Windows;
    using Catel;
    using Catel.MVVM;
    using Catel.Services;
    using global::MahApps.Metro.Controls;
    using global::MahApps.Metro.IconPacks;
    using Orchestra;
    using Orchestra.Models;
    using Orchestra.Services;
    using Orchestra.ViewModels;
    using Orchestra.Views;
    using Views;

    public class MahAppsService : IMahAppsService
    {
        public WindowCommands GetRightWindowCommands()
        {
            var windowCommands = new WindowCommands();

            var settingsButton = WindowCommandHelper.CreateWindowCommandButton(new PackIconMaterial { Kind = PackIconMaterialKind.Settings }, "settings");
            //settingsButton.SetCurrentValue(System.Windows.Controls.Primitives.ButtonBase.CommandProperty, _commandManager.GetCommand(AppCommands.Settings.General));
            windowCommands.Items.Add(settingsButton);

            return windowCommands;
        }

        public FlyoutsControl GetFlyouts()
        {
            return null;
        }

        public FrameworkElement GetMainView()
        {
            return new MainView();
        }

        public FrameworkElement GetStatusBar()
        {
            return null;
        }

        public AboutInfo GetAboutInfo()
        {
            return new AboutInfo();
        }
    }
}