using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WAService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WAService" in both code and config file together.
    public class WAService : IWAService
    {
        public bool VerifyingPassword(string userName, string password)
        {
            return UserManager.VerifyingPassword(userName, password);
        }
        public bool AddUserInFile(string nameUser, string password)
        {
            return FileManager.AddUserInFile(nameUser, password);
        }
        public bool DeleteUserFromFile(string nameUser)
        {
            return FileManager.DeleteUserFromFile(nameUser);
        }
        public IList<Worklist> GetWorklistsForUser(string userLogin)
        {
            //return FileManager.GetWorklistsForUser(UserManager.GetUserOnLogin(userLogin));
            return FileManager.GetWorklistsForUser(userLogin);
        }
        public bool AddWorklistInFile(string masterUserLogin, string loginUser, string passwordUser)
        {
            return FileManager.AddWorklistInFile(masterUserLogin, loginUser, passwordUser);
        }
        public bool DeleteWorklistFromFile(string masterUserLogin, string loginUser)
        {
            return FileManager.DeleteWorklistFromFile(masterUserLogin, loginUser);
        }
        public void EditWorklist(string masterUserLogin, string oldUserLogin, string newUserLogin, string newUserPassword)
        {
            UserManager.EditWorklist(masterUserLogin, oldUserLogin, newUserLogin, newUserPassword);
        }
        public bool EditUser(string userLogin, string newUserLogin, string newUserPassword)
        {
           return UserManager.EditUser(userLogin, newUserLogin, newUserPassword);
        }
        public void ChangeMasterUserForWorklists(string oldMasterUser, string newMasterUser)
        {
            UserManager.ChangeMasterUserForWorklists(oldMasterUser, newMasterUser);
        }
        public bool DeleteAllWorklistForUser(string masterUserLogin)
        {
            return FileManager.DeleteAllWorklistForUser(masterUserLogin);
        }

    }
}
