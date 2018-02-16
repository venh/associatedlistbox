using System;
using System.Linq;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class AssociatedListBoxUC : System.Web.UI.UserControl
{
    #region Page_Load and OnInit

    protected void Page_Load(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        lblStatus.Visible = false;
    }

    /// <summary>
    /// assign css to the buttons
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl css = new System.Web.UI.HtmlControls.HtmlGenericControl("link");
        css.Attributes["rel"] = "stylesheet";
        css.Attributes["type"] = "text/css";
        css.Attributes["href"] = StyleLocation;
        Page.Header.Controls.Add(css);
        base.OnInit(e);
    }

    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public bool DisableAvailableAssociatedList
    {
        set
        {
            lstBoxAvailable.Enabled = value;
            lstBoxAssociated.Enabled = value;
            btnAdd.Enabled = value;
            btnRemove.Enabled = value;
            btnUp.Visible = value;
            btnDown.Visible = value;
        }
    }

    /// <summary>
    /// location of the Css
    /// </summary>
    public string StyleLocation { get; set; }

    /// <summary>
    /// Hide show re-oder buttons
    /// </summary>
    public bool ReorderButtonsVisibility
    {
        set
        {
            btnUp.Visible = value;
            btnDown.Visible = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the Text Field of Available List Box
    /// </summary>
    public string AvailableListBoxTextField
    {
        get
        {
            return (lstBoxAvailable.DataTextField);
        }
        set
        {
            lstBoxAvailable.DataTextField = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the Value Field of Available List Box
    /// </summary>
    public string AvailableListBoxValueField
    {
        get
        {
            return (lstBoxAvailable.DataValueField);
        }
        set
        {
            lstBoxAvailable.DataValueField = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the Text of Header Label for Available List Box
    /// </summary>
    public string AvailableListBoxLabelHeader
    {
        get
        {
            return (lblAvailable.Text);
        }
        set
        {
            lblAvailable.Text = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the DataSource of Available List Box
    /// </summary>
    public object AvailableListBoxDataSource
    {
        get
        {
            return (lstBoxAvailable.DataSource);
        }
        set
        {
            lstBoxAvailable.DataSource = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the Text Field of Associated List Box
    /// </summary>
    public string AssociatedListBoxTextField
    {
        get
        {
            return (lstBoxAssociated.DataTextField);
        }
        set
        {
            lstBoxAssociated.DataTextField = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the Value Field of Associated List Box
    /// </summary>
    public string AssociatedListBoxValueField
    {
        get
        {
            return (lstBoxAssociated.DataValueField);
        }
        set
        {
            lstBoxAssociated.DataValueField = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the Text of Header Label for Associated List Box
    /// </summary>
    public string AssociatedListBoxLabelHeader
    {
        get
        {
            return (lblAssociated.Text);
        }
        set
        {
            lblAssociated.Text = value;
        }
    }

    /// <summary>
    /// Property to Get and Set the DataSource of Associated List Box
    /// </summary>
    public object AssociatedListBoxDataSource
    {
        get
        {
            return (lstBoxAssociated.DataSource);
        }
        set
        {
            lstBoxAssociated.DataSource = value;
        }
    }

    /// <summary>
    /// Property to Get the items from the To (Associated) List Box
    /// </summary>
    public ListItemCollection AssociatedListBoxOutput
    {
        get
        {
            if (lstBoxAssociated.Items.Count > 0)
            {
                return (lstBoxAssociated.Items);
            }
            return null;
        }
    }

    #endregion

    #region Event Handlers

    /// <summary>
    /// Remove Button Click Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstBoxAssociated.SelectedIndex == -1)
            {
                DisplayStatus("Please select single/multiple item(s) to Remove", Color.Red);
                return;
            }
            else
            {
                DisplayStatus("", Color.Transparent);
            }

            AddListItems(lstBoxAssociated, lstBoxAvailable);
            RemoveListItems(lstBoxAssociated, lstBoxAvailable);
        }
        catch (Exception ex)
        {
            DisplayStatus(ex.Message, Color.Red);
        }
    }

    /// <summary>
    /// Add Button Click Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstBoxAvailable.SelectedIndex == -1)
            {
                DisplayStatus("Please select single/multiple item(s) to Associate", Color.Red);
                return;
            }
            else
            {
                DisplayStatus("", Color.Transparent);
            }
            AddListItems(lstBoxAvailable, lstBoxAssociated);
            RemoveListItems(lstBoxAvailable, lstBoxAssociated);
        }
        catch (Exception ex)
        {
            DisplayStatus(ex.Message, Color.Red);
        }
    }

    /// <summary>
    /// Up Button Click Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (lstBoxAssociated.SelectedIndex == -1)
        {
            DisplayStatus("Please select single/multiple item(s) to Move Up", Color.Red);
            return;
        }
        else
        {
            DisplayStatus("", Color.Transparent);
        }
        if (lstBoxAssociated.SelectedIndex > 0)
        {
            int[] sel = lstBoxAssociated.GetSelectedIndices();
            lstBoxAssociated.Items.Insert(sel[sel.Length - 1] + 1, lstBoxAssociated.Items[sel[0] - 1]);
            lstBoxAssociated.Items.RemoveAt(sel[0] - 1);
        }
        else
        {
            DisplayStatus("Item at position 1 cannot be moved further up. Please select any item from position 2 or below to move up.", Color.Red);
            return;
        }
    }

    /// <summary>
    /// Down Button Click Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDown_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstBoxAssociated.SelectedIndex == -1)
            {
                DisplayStatus("Please select single/multiple item(s) to Move Down", Color.Red);
                return;
            }
            else
            {
                DisplayStatus("", Color.Transparent);
            }
            if (lstBoxAssociated.SelectedIndex != -1)
            {
                if (lstBoxAssociated.SelectedIndex == (lstBoxAssociated.Items.Count - 1))
                {
                    DisplayStatus("Item at last position cannot be moved further down. Please select any item from position second last or above to move down.", Color.Red);
                    return;
                }
                else
                {
                    int[] selIndices = lstBoxAssociated.GetSelectedIndices();
                    if (lstBoxAssociated.Items[lstBoxAssociated.Items.Count - 1] != lstBoxAssociated.Items[selIndices[selIndices.Length - 1]])
                    {
                        lstBoxAssociated.Items.Insert(selIndices[0], lstBoxAssociated.Items[selIndices[selIndices.Length - 1] + 1]);
                        lstBoxAssociated.Items.RemoveAt(selIndices[selIndices.Length - 1] + 2);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DisplayStatus(ex.Message, Color.Red);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Method to Reorder items in Associated ist Box. Accepts Default Value as string.
    /// </summary>
    /// <param name="defVal"></param>
    public void ReorderAssociatedList(string strDefVal)
    {
        if (string.IsNullOrEmpty(strDefVal))
            return;
        if (lstBoxAssociated.Items.Count > 1)
        {
            foreach (ListItem lstItem in lstBoxAssociated.Items)
            {
                if (strDefVal == lstItem.Value)
                {
                    lstBoxAssociated.Items.Remove(lstItem);
                    lstBoxAssociated.Items.Insert(0, lstItem);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Method to check if the Associated List is empty or not. Returns a boolean.
    /// </summary>
    /// <returns></returns>
    public bool IsAssociatedListBoxEmpty()
    {
        bool bResult = false;
        if (lstBoxAssociated.Items.Count == 0)
        {
            bResult = true;
        }
        return bResult;
    }

    /// <summary>
    /// Method to Clear Available or Associated List Box
    /// </summary>
    /// <param name="strList"></param>
    public void ClearList(string strList)
    {
        ListBox lstBox = null;
        if (strList == "Available")
        {
            lstBox = lstBoxAvailable;
        }
        else if (strList == "Associated")
        {
            lstBox = lstBoxAssociated;
        }
        foreach (ListItem lstItem in lstBox.Items)
        {
            lstBox.Items.Remove(lstItem);
            ClearList(strList);
            break;
        }
    }

    /// <summary>
    /// Method to Bind the Available List Box.
    /// </summary>
    public void BindAvailableListBox()
    {
        lstBoxAvailable.ClearSelection();
        lstBoxAvailable.DataSource = this.AvailableListBoxDataSource;
        lstBoxAvailable.DataTextField = this.AvailableListBoxTextField;
        lstBoxAvailable.DataValueField = this.AvailableListBoxValueField;
        lstBoxAvailable.DataBind();

        if (lstBoxAssociated.Items.Count != 0)
        {
            foreach (ListItem lstItemAssociated in lstBoxAssociated.Items)
            {
                lstBoxAvailable.Items.Remove(lstItemAssociated);
            }
        }
    }

    /// <summary>
    /// Method to Bind the Associated List Box.
    /// </summary>
    public void BindAssociatedListBox()
    {
        lstBoxAssociated.ClearSelection();
        lstBoxAssociated.DataSource = this.AssociatedListBoxDataSource;
        lstBoxAssociated.DataTextField = this.AssociatedListBoxTextField;
        lstBoxAssociated.DataValueField = this.AssociatedListBoxValueField;
        lstBoxAssociated.DataBind();
    }

    /// <summary>
    /// Method to remove Available List Box items
    /// </summary>
    public void RemoveAvailableListItems()
    {
        RemoveListItems(lstBoxAvailable, lstBoxAssociated);
    }

    /// <summary>
    /// Method to remove common (intersecting) list items from Associated List Box
    /// </summary>
    public void RemoveCommonAssociatedListItems()
    {
        RemoveCommonListItems(lstBoxAvailable, lstBoxAssociated);
    }

    #endregion

    #region Private Helper Methods

    /// <summary>
    /// Method to Add List Items from Available to Associated List Box
    /// </summary>
    /// <param name="lstAvailable"></param>
    /// <param name="lstAssociated"></param>
    private void AddListItems(ListBox lstAvailable, ListBox lstAssociated)
    {
        if (lstAvailable.SelectedIndex != -1)
        {
            int[] selIndices = lstAvailable.GetSelectedIndices();
            foreach (int index in selIndices)
            {
                lstAssociated.Items.Add(lstAvailable.Items[index]);
            }
            var items = from item in lstAssociated.Items.OfType<ListItem>()
                        orderby item.Text ascending
                        select item;
            lstAssociated.DataSource = null;
            lstAssociated.DataBind();
            lstAssociated.DataSource = items.ToList<ListItem>();
            lstAssociated.DataTextField = "Text";
            lstAssociated.DataValueField = "Value";
            lstAssociated.DataBind();
            lstAssociated.SelectedIndex = 0;
            items = null;
        }
    }

    /// <summary>
    /// Inernal Method to Remove List Items from Associated List Box and add back to Available List Box
    /// </summary>
    /// <param name="lstAvailable"></param>
    /// <param name="lstAssociated"></param>
    private void RemoveListItems(ListBox lstAvailable, ListBox lstAssociated)
    {
        foreach (ListItem lstItem in lstAssociated.Items)
        {
            lstAvailable.Items.Remove(lstItem);
        }
    }

    /// <summary>
    ///  Private Method to remove common (intersecting) list items from Associated List Box
    /// </summary>
    /// <param name="lstAvailable"></param>
    /// <param name="lstAssociated"></param>
    private void RemoveCommonListItems(ListBox lstAvailable, ListBox lstAssociated)
    {
        bool itemExists = true;
        foreach (ListItem lstItemAssociated in lstAssociated.Items)
        {
            foreach (ListItem lstItemAvailable in lstAvailable.Items)
            {
                if (lstItemAssociated.Text == lstItemAvailable.Text)
                {
                    itemExists = false;
                    break;
                }
            }
            if (itemExists)
            {
                lstAssociated.Items.Remove(lstItemAssociated);
                RemoveCommonListItems(lstBoxAvailable, lstBoxAssociated);
                break;
            }
            itemExists = true;
        }
    }

    /// <summary>
    /// Method called internally to Display status, either Success or Failure.
    /// </summary>
    /// <param name="strMsg"></param>
    /// <param name="color"></param>
    private void DisplayStatus(string strMsg, Color color)
    {
        lblStatus.Text = strMsg;
        lblStatus.ForeColor = color;
        lblStatus.Visible = true;
    }

    #endregion
}