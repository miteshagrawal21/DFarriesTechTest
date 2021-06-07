using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DFarriesDal
    {
        public DataSet getUsers()
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            SqlConnection objConnection = new SqlConnection(Connectionstring);
            objConnection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConnection;
            cmd.CommandText = "spGetAllUsers";
            cmd.CommandType = CommandType.StoredProcedure;

            DataSet objDataset = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(cmd);

            objAdapter.Fill(objDataset);

            objConnection.Close();
            return objDataset;
        }

        public DataSet getUser(string userId)
        {
            // open a connection
            string Connectionstring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            SqlConnection objConnection = new SqlConnection(Connectionstring);
            objConnection.Open();

            // Fire the command object
            SqlCommand objCommand = new SqlCommand("Select * from Users where Id='"
                                  + userId + "'",
                                  objConnection);
            DataSet objDataset = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);

            objAdapter.Fill(objDataset);

            objConnection.Close();
            return objDataset;
        }

        public bool InsertUser(string strFirstName, string strLastName, string strDob)
        {
            // Open connection
            string Connectionstring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            SqlConnection objConnection = new SqlConnection(Connectionstring);
            objConnection.Open();
            try
            {

                // Command insert fire
                string strInsertCommand = "Insert into Users (FirstName, LastName, DOB) Values ('" + strFirstName + "','";
                strInsertCommand = strInsertCommand + strLastName + "',convert(datetime,'";
                strInsertCommand = strInsertCommand + strDob+ "',103))";

                SqlCommand objCommand = new SqlCommand(strInsertCommand, objConnection);
                objCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objConnection.Close();
            }

        }

        public bool UpdateUser(string strUserId,
                                string strFirstName,
                                string strLastName,
                                string strDob)
        {
            // Open connection
            string Connectionstring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            SqlConnection objConnection = new SqlConnection(Connectionstring);
            objConnection.Open();

            string strUpdateCommand = "Update Users set FirstName='" + strFirstName + "',";
            strUpdateCommand = strUpdateCommand + " LastName = '" + strLastName + "',";
            strUpdateCommand = strUpdateCommand + " DOB = convert(datetime,'" + strDob + "',103)";
            strUpdateCommand = strUpdateCommand + " Where Id='" + strUserId + "'";

            SqlCommand objCommand = new SqlCommand(strUpdateCommand, objConnection);
            objCommand.ExecuteNonQuery();

            // close connection
            objConnection.Close();

            return true;
        }

        public bool DeleteUser(string strUserId)
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            SqlConnection objConnection = new SqlConnection(Connectionstring);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("Delete from Users where Id='"
                                    + strUserId + "'",
                                    objConnection);

            objCommand.ExecuteNonQuery();
            objConnection.Close();
            return true;
        }

    }
}
