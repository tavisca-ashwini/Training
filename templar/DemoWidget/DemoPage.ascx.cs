using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Tavisca.Templar.Contract;

namespace DemoWidget
{
    public partial class DemoPage : System.Web.UI.UserControl,IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                var state = Host.GetState();
                var xstate = XElement.Parse(state);

                var xday = xstate.Element("Day");
                if (xday != null)
                {
                    var day = 0;
                    int.TryParse(xday.Value, out day);
                    if (day == 1)
                    {
                        Label1.Text = "Simple Calculator is selected";
                    }
                    else
                        Label1.Text = "Scientific Calculator is selected";
                }
            } 
        }

        public void HideSettings()
        {
            pnlSettings.Visible = false; //Hide settings panel

            //var xmlState = XElement.Parse(GetState(Host));
            //xmlState.RemoveAll();
            //xmlState.Add(new XElement("Day", CheckBox1.SelectedValue));  //update state with latest changes from UI
            //Host.SaveState(xmlState.ToString());
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            pnlSettings.Visible = true;

            //render settings value from database.
            //var xday = GetStateElement("Day");
            //if (xday != null)
            //{
            //    var day = 0;
            //    int.TryParse(xday.Value, out day);
            //    foreach (ListItem item in CheckBox1.Item)
            //    {
            //        var value = 0;
            //        int.TryParse(item.Value, out value);
            //        if (day == value)
            //            item.Selected = true;
            //        else
            //            item.Selected = false;
            //    }
            //}
        }

        public XElement GetStateElement(String elementName)
        {
            var xstate = XElement.Parse(GetState(Host));
            var xelmnt = xstate.Element(elementName);
            if (xelmnt != null)
            {
                return xelmnt;
            }
            return null;
        }

        public string GetState(IWidgetHost host)
        {
            var state = host.GetState();
            if (string.IsNullOrEmpty(state))
                state = "<state></state>";
            return state;
        }
    }
}