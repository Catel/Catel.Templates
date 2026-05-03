namespace $rootnamespace$
{
    using Catel.Services;
    using System;

    public partial class $safeitemname$
    {
        public $safeitemname$(IServiceProvider serviceProvider, IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService)
        {
            InitializeComponent();
        }    
    }
}
