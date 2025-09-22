﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.model;

namespace Page_Navigation_App.viewmodel
{
    class ProductsVM : utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public string ProductAvailability
        { 
            get { return _pageModel.ProductStatus; }
            set { _pageModel.ProductStatus = value; OnPropertyChanged(); }
        }

        public ProductsVM()
        {
            _pageModel = new PageModel();
            ProductAvailability = "Out of Stock";
        }
    }
}
