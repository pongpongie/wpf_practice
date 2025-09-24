using Page_Navigation_App.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.viewmodel
{
    class TransactionsVM : utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public decimal TransactionAmount
        {
            get {  return _pageModel.TransactionValue; }
            set { _pageModel.TransactionValue = value; OnPropertyChanged(); }
        }

        public TransactionsVM()
        {
            _pageModel = new PageModel();
            TransactionAmount = 5638;
        }
    }
}
