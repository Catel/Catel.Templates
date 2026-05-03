namespace $safeprojectname$.Views
{
    using Catel.MVVM;
    using Catel.Services;
    using System;

    public partial class StatusBarView
    {
        public StatusBarView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService, IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}