using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Dictionary<int, string> dictItems = new Dictionary<int, string>(10);
                for (int i = 0; i < 10; i++)
                {
                    dictItems.Add(i + 1, "Item " + (i + 1).ToString());
                }
                clb.AvailableListBoxDataSource = dictItems;
                clb.AvailableListBoxTextField = "Value";
                clb.AvailableListBoxValueField = "Key";
                clb.BindAvailableListBox();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}