using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceExternConsumerCalculatrice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private myCalculator.Calculator mycalc;

        protected void Page_Load(object sender, EventArgs e)
        {
            mycalc = new myCalculator.Calculator();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = mycalc.Add(int.Parse(TextBox1.Text), int.Parse(TextBox2.Text)).ToString();
        }
    }
}