namespace $safeprojectname$.Views
{
    using Orchestra;
    using System;

    public partial class RibbonView 
    {
        protected override void OnLoaded(EventArgs e)
        {
            base.OnLoaded(e);

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