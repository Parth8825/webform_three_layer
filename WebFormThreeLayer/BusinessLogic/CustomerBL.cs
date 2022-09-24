﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;

namespace BusinessLogic
{
    public class CustomerBL
    {
        public int InsertNewCustomer(CustomerBO newCustomer)
        {
            try
            {
                CustomerDA dataAccess = new CustomerDA();
                return dataAccess.InsertCustomer(newCustomer);
            }
            catch
            {
                return 0;
            }
        }
    }
}