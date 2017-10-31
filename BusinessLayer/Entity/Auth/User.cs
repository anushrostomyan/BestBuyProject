using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataAccess;
using BusinessLayer.Entity.Auth;
using BusinessLayer.Enums;

namespace BusinessLayer.Entity
{
    public class User
    {
        public int? ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string TellNumber { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public Sex? Sex { get; private set; }
        public DateTime?  BirthDate { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public UserType? TypeOfUser { get; private set; } = UserType.User;
        public Status? Status { get; private set; }
        public int? ProcessingErrorID { get; private set; }   
        

        public User()
        {

        }

        public User(string Fname,string Lname,string UserName,string Password,string Email,Sex sex)
        {            
            this.FirstName = Fname;
            this.LastName = Lname;
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.Sex = sex;
        }

        public User(int? id = null, string fname = null, string lname = null, 
                    string telnumber = null, string email = null, string address = null,
                    Sex? sex = null, DateTime? birthDate = null,string username = null,
                    string password = null, int? ProcessingErrorID = null,UserType? user = null)
        {
            this.ID = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.TellNumber = telnumber;
            this.Email = email;
            this.UserName = username;
            this.Password = password;
            this.Address = address;
            this.Sex = sex;
            this.BirthDate = birthDate;
            this.ProcessingErrorID = ProcessingErrorID;
            this.TypeOfUser = user;
        }

        User Init(Dictionary<string, object> element)
        {
            this.ID = (int?)element["ID"];
            this.FirstName = (string)element["FirstName"];
            this.LastName = (string)element["LastName"];
            this.Password = (string)element["Password"];
            this.UserName = (string)element["UserName"];
            this.Address = (string)element["Address"];
            this.BirthDate = (DateTime?)element["BirthDate"];
            this.Email = (string)element["Email"];
            this.Sex = (Sex?)(byte?)element["Sex"];
            this.TellNumber = (string)element["TellNumber"];
            this.Status = (Status?)(byte?)element["Status"];

            return this;
        }

        public User GetById(int id)
        {
            try
            {
                List<SPParam> par = new List<SPParam>(1);
                par.Add(new SPParam("ID", id));
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetById", par);
                if (result != null && result.Count != 0)
                {
                    Dictionary<string, object> element = result[0];
                    this.Init(element);

                }
                return this;
            }
            catch (Exception ex)
            {
                this.ProcessingErrorID = 0;
                return this;
            }

        }

        public List<User> GetAllUsers()
        {
            DbDataAccess db = new DbDataAccess();
            List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllUsers", new List<SPParam>());
            List<User> userlist = new List<User>();
            foreach (var user in result)
            {
                User _user = new User();
                userlist.Add(_user.Init(user));
            }
            return userlist;
        }
        
        public User Login()
        {
            User userResult = null;
            try
            {
                Security security = new Security();   
                
                string hashedPassowrd = security.CalculateMD5Hash(this.Password);
                List<SPParam> par = new List<SPParam>(2);
                //par.Add(new SPParam("Uname", this.UserName.ToLower()));
                //par.Add(new SPParam("Pass", hashedPassowrd));
                par.Add(new SPParam("Uname", this.UserName));
                par.Add(new SPParam("Pass", this.Password));
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("Login", par);
                if (result != null && result.Count != 0)
                {
                    Dictionary<string, object> element = result[0];
                    User user = new User();
                    userResult = user.Init(element);

                }
                return userResult;
            }
            catch(Exception ex)
            {
                return userResult = new User(ProcessingErrorID: 0);
            }
            
        }

        public void AddUser()
        {                        
            try
            {
                Security security = new Security();
                DbDataAccess db = new DbDataAccess();
                string hashedPassowrd = security.CalculateMD5Hash(this.Password);
                List<SPParam> param = new List<SPParam>();
                
               
                param.Add(new SPParam("FirstName", this.FirstName));
                param.Add(new SPParam("LastName", this.LastName));
                param.Add(new SPParam("Username", this.UserName.ToLower()));
                param.Add(new SPParam("Password", hashedPassowrd));
                param.Add(new SPParam("Email", this.Email));
                param.Add(new SPParam("Address", this.Address));
                param.Add(new SPParam("TellNumber", this.TellNumber));
                param.Add(new SPParam("BirthDate", this.BirthDate));
                param.Add(new SPParam("Sex", this.Sex != null ? (byte?)this.Sex : null ));
                param.Add(new SPParam("UserType",(byte)this.TypeOfUser));

                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UserAdd", param);
                if (result == null)
                {
                    ProcessingErrorID = 1;
                }
                                
            }
            catch (Exception ex)
            {
                throw new Exception("User Add Exception");               
            }
                      
        }

    }
}
