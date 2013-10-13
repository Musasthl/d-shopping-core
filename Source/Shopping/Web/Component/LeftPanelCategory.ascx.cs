using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COM.DTO;

namespace Web.Component
{
    public partial class LeftPanelCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Category> ParentCategory = BUS.CategoryHandler.getAllParentCategory();
            PanelCategory.Controls.Add(new LiteralControl("<table>"));

            foreach (Category cat in ParentCategory)
            {
                PanelCategory.Controls.Add(new LiteralControl("<tr><td>"+ cat.Name +"</td></tr>"));
                if (cat.Categories != null)
                {
                    foreach(Category childCat in cat.Categories)
                        PanelCategory.Controls.Add(new LiteralControl("<tr><td>" +"    -  " + childCat.Name + "</td></tr>"));
                }
            }

            PanelCategory.Controls.Add(new LiteralControl("</table>"));
        }
    }
}