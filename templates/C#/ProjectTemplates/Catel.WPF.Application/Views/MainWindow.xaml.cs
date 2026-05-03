namespace $safeprojectname$.Views
{
    using Catel.Services;
    using System;

    public partial class MainWindow
    {
        public MainWindow(IServiceProvider serviceProvider, IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService)
        {
            InitializeComponent();
        }
    }
}
