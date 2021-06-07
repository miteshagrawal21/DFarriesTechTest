using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace MiddleTier
{
    public class clsUsers
    {
        private int _UserId = 0;
        //private DateTime _DOB = DateTime.Now;
        private string _DOB = "";
        private string _FirstName = "";
        private string _LastName = "";

        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public string DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }

        public DataSet LoadUsers()
        {
            DFarriesDal obj = new DFarriesDal();
            return obj.getUsers();
        }

        public DataSet LoadUser(string userId)
        {
            DFarriesDal obj = new DFarriesDal();
            return obj.getUser(userId);
        }


        //Insert record to SQL DB
        public void Save()
        {
            DFarriesDal obj = new DFarriesDal();
            obj.InsertUser(_FirstName, _LastName, _DOB);
        }

        public int countVowels(string strName)
        {
            int total = 0;

            for (int i = 0; i < strName.Length; i++)
            {
                if (strName[i] == 'a' || strName[i] == 'e' || strName[i] == 'i' || strName[i] == 'o' || strName[i] == 'u')
                {
                    total++;
                }
            }
            return total;
        }

        public void Update(string _UserId)
        {
            DFarriesDal obj = new DFarriesDal();
            obj.UpdateUser(_UserId,
                           _FirstName,
                           _LastName,
                           _DOB
                );
        }

        public void Delete(string _UserId)
        {
            DFarriesDal obj = new DFarriesDal();
            obj.DeleteUser(_UserId);
        }

    }
}
