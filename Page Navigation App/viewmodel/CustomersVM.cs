﻿using Page_Navigation_App.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.viewmodel
{
    class CustomersVM : utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public int CustomerID
        {
            get { return _pageModel.CustomerCount; }
            set { _pageModel.CustomerCount = value; OnPropertyChanged(); }
        }

        public CustomersVM()
        {
            _pageModel = new PageModel();
            CustomerID = 100528;
        }
    }
}
