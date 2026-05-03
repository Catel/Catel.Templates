namespace $safeprojectname$.Views
{
    using Catel.MVVM;
    using Catel.Services;
    using System;

    public partial class MainView
    {
        public MainView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService, IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}