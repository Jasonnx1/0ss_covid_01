using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BillingManagement.Models
{
    public interface IClosable : ICommand
    {

        void Close();
        
    }
}
