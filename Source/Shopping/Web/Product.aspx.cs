using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;

namespace Web
{
    public partial class Product : System.Web.UI.Page
    {
        private string ProductCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductCode = Request.QueryString[COM.CONST.PARAM.PRODUCT];
            }
            catch (Exception ex)
            {
                COM.Logger.getInstance().log("Get Product Error (Product.aspx) : " + ex);
                Response.Redirect("/Error/InvalidRequest.aspx");
                return;
            }
            // Product currentProduct = ProductHandler.getCurrentProduct(ProductCode);
            
        }

        private void LoadProduct(Product currentProduct)
        {

        }



    }
}