using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COM.DTO;
using DAL.DAO;
using COM;

namespace BUS
{
    public class CustomerHandler
    {
        public static bool CreateNewCustomer(Customer Customer)
        {
            try
            {
                return CustomerDAO.Add(Customer);
            }
            catch (Exception ex)
            {
                Logger.getInstance().log(ex.ToString());
                return false;
            }
        }
    }
}
