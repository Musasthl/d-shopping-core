using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COM.DTO;
using BUS;
using COM;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer newCust = new Customer();
            newCust.Address = "";
            newCust.CreatedDate = DateTime.Today;
            newCust.Email = "dang@email.com";
            newCust.Name = "Example";
            newCust.Password = Encrypt.EncodePassword("123456");
            newCust.Phone = "0123456";
            newCust.Usename = "dang";
            CustomerHandler.CreateNewCustomer(newCust);
            Logger.getInstance().log("dang");
        }
    }
}
