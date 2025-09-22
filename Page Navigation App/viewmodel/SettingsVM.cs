using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.model;

namespace Page_Navigation_App.viewmodel
{
    class SettingsVM : utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        
        public bool Settings
        {
            get { return _pageModel.LocationStatus; }
            set { _pageModel.LocationStatus = value; OnPropertyChanged(); }
        }

        public SettingsVM()
        {
            _pageModel = new PageModel();
            Settings = true;
        }
    }
}
