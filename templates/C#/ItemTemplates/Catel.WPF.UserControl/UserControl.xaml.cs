namespace $rootnamespace$
{
    using Catel.MVVM;
    using Catel.Services;
    using System;

    public partial class $safeitemname$
    {
        public $safeitemname$(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService, IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}
