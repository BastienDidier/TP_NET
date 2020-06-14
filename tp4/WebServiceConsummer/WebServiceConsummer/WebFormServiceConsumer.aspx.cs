using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceConsummer
{
    public partial class WebFormServiceConsumer : System.Web.UI.Page
    {
        private MyWebServiceReference.WebServiceHelloWorld myWS;
        protected void Page_Load(object sender, EventArgs e)
        {
            myWS = new MyWebServiceReference.WebServiceHelloWorld();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = myWS.HelloWorld();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            this.Label2.Text = myWS.Hello(this.TextBox1.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Label4.Text = myWS.Add(int.Parse(TextBox2.Text), int.Parse(TextBox3.Text)).ToString();
        }
    }
}