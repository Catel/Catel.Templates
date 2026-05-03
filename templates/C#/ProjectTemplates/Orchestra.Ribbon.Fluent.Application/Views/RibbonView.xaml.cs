namespace $safeprojectname$.Views
{
    using Catel.MVVM;
    using Catel.Services;
    using Orchestra;
    using System;

    public partial class RibbonView 
    {
        public RibbonView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService, IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();

            ribbon.AddAboutButton();
        }
        
        protected override void OnViewModelChanged()
        {
            base.OnViewModelChanged();

#pragma warning disable WPF0041
            backstageTabControl.DataContext = ViewModel;
#pragma warning restore WPF0041
        }
    }
}