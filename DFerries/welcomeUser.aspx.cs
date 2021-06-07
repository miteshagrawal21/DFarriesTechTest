using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiddleTier;
namespace DFerries
{
    public partial class welcomeUser : System.Web.UI.Page
    {
        string strFName = "";
        string strLName = "";
        string strDob = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page previouspage = Page.PreviousPage;
            if (previouspage != null && previouspage.IsCrossPagePostBack)
            {
                strFName = ((TextBox)previouspage.FindControl("txtFirstName")).Text;
                strLName = ((TextBox)previouspage.FindControl("txtLastName")).Text;
                strDob = ((TextBox)previouspage.FindControl("txtDob")).Text;

                clsUsers objUser = new clsUsers();
                objUser.FirstName = strFName;
                objUser.LastName = strLName;
                objUser.DOB = strDob;
                objUser.Save(); 

                labWelcome.Text = strFName;
                labVowels.Text = countVowels().ToString();
                labAge.Text = CalculateAge(strDob).ToString();
                labDays.Text = FindDaysToNextBirthday(strDob).ToString();

                grd14days.DataSource = before14Days(strDob);
                grd14days.DataBind();

                grd14days.HeaderRow.Cells[0].Text = "14 Days before next Birthday";

                string strPara = "";
                foreach(GridViewRow gr in grd14days.Rows)
                {
                    HyperLink hp = new HyperLink();
                    hp.Text = gr.Cells[0].Text;
                    strPara = Convert.ToDateTime(gr.Cells[0].Text).ToString("MMMM") + "-" + Convert.ToDateTime(gr.Cells[0].Text).ToString("dd");
                    hp.NavigateUrl = "https://www.historynet.com/today-in-history/" + strPara;
                    gr.Cells[0].Controls.Add(hp);
                }

                //before14Days(strDob);
            }
        }

        private int countVowels()
        {
            int cntvowels = 0;
            clsUsers obj = new clsUsers();
            cntvowels = obj.countVowels(strFName);
            return cntvowels;
        }

        private int CalculateAge(string strDob)
        {
            int age = 0;
            DateTime dateOfBirth = Convert.ToDateTime(strDob);
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private int FindDaysToNextBirthday(string strDob)
        {
            DateTime birthday = Convert.ToDateTime(strDob);
            DateTime today = DateTime.Today;
            DateTime next = birthday.AddYears(today.Year - birthday.Year);

            if (next < today)
                next = next.AddYears(1);
            //if (!DateTime.IsLeapYear(next.Year + 1))
            //    next = next.AddYears(1);
            //else
            //    next = new DateTime(next.Year + 1, birthday.Month, birthday.Day);

            int numDays = (next - today).Days;
            return numDays;
        }

        private List<string> before14Days(string strDob)
        {
            List<string> dt14Days = new List<string>();

            DateTime dtDob = Convert.ToDateTime(strDob);

            DateTime nextDob = new DateTime(DateTime.Now.Year, dtDob.Month, dtDob.Day);

            TimeSpan fortnight = TimeSpan.FromDays(1);
            for (int i = 0; i < 14; i++)
            {
                nextDob -= fortnight;
                string strLinkDt = nextDob.Month.ToString() + "-" + nextDob.Day.ToString();

                dt14Days.Add(nextDob.ToString(" dd ddd MMM yyyy"));
            }

            return dt14Days;
        }

    }

}