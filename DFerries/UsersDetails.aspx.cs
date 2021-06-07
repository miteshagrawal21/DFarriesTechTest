using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiddleTier;
using System.Data;
namespace DFerries
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        private void LoadAllUsers()
        {
            clsUsers obj = new clsUsers();
            grdUsers.DataSource = obj.LoadUsers();
            grdUsers.DataBind();

            grdUsers.HeaderRow.Cells[0].Text = " Select ";
            grdUsers.HeaderRow.Cells[1].Text = " User Id ";
            grdUsers.HeaderRow.Cells[2].Text = " First Name ";
            grdUsers.HeaderRow.Cells[3].Text = " Last Name ";
            grdUsers.HeaderRow.Cells[4].Text = " Birth Date ";

        }

        protected void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strUserId = grdUsers.Rows[grdUsers.SelectedIndex].Cells[1].Text;
            DisplayUser(strUserId);
        }

        private void DisplayUser(string strUserId)
        {
            clsUsers objUser = new clsUsers();
            DataSet objDataset = objUser.LoadUser(strUserId);
            
            string strId = objDataset.Tables[0].Rows[0][0].ToString();
            string strFirstName = objDataset.Tables[0].Rows[0][1].ToString();
            string strLastName = objDataset.Tables[0].Rows[0][2].ToString();
            string strDob = objDataset.Tables[0].Rows[0][3].ToString();

            txtUserId.Text = strId;
            txtFirstName.Text = strFirstName;
            txtLastName.Text = strLastName;
            txtDob.Text = strDob.Substring(0,10);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            clsUsers objUser = new clsUsers();
            objUser.FirstName = txtFirstName.Text;
            objUser.LastName = txtLastName.Text;
            objUser.DOB = txtDob.Text;
            objUser.UserId = Convert.ToInt32(txtUserId.Text);

            objUser.Update(txtUserId.Text);

            LoadAllUsers();
            ClearData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            clsUsers objUser = new clsUsers();
            objUser.UserId = Convert.ToInt32(txtUserId.Text);
            objUser.Delete(txtUserId.Text);

            LoadAllUsers();
            ClearData();

        }

        public void ClearData()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDob.Text = "";
        }
    }
}