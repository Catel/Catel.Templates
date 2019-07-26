namespace $rootnamespace$
{
    using $rootnamespace$.ViewModels;
    
    public sealed partial class $safeitemname$
    {
        public $safeitemname$()
        {
            InitializeComponent();
        }
        
        internal $safeitemname$Model VM
        {
            get { return ViewModel as $safeitemname$Model; }
        }
    }
}