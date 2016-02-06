using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WAService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWAService" in both code and config file together.
    [ServiceContract]
    public interface IWAService
    {
        [OperationContract]
        bool VerifyingPassword(string userName, string password);
        [OperationContract]
        bool AddUserInFile(string nameUser, string password);
        [OperationContract]
        IList<Worklist> GetWorklistsForUser(string userLogin);
        [OperationContract]
        bool AddWorklistInFile(string masterUserLogin, string loginUser, string passwordUser);
        [OperationContract]
        bool DeleteWorklistFromFile(string masterUserLogin, string loginUser);
        [OperationContract]
        void EditWorklist(string masterUserLogin, string oldUserLogin, string newUserLogin, string newUserPassword);
        [OperationContract]
        bool EditUser(string userLogin, string newUserLogin, string newUserPassword);
        [OperationContract]
        void ChangeMasterUserForWorklists(string oldMasterUser, string newMasterUser);
        [OperationContract]
        bool DeleteAllWorklistForUser(string masterUserLogin);
        [OperationContract]
        bool DeleteUserFromFile(string nameUser);
    }
}
