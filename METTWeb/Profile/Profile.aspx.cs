using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MELib.Accounts;
using MELib.RO;
using MELib.Security;
using MEWeb.Maintenance;
using Singular.Security;
using Singular.Web;
using Singular.Web.Data;

namespace MEWeb.Profile
{
  public partial class Profile : MEPageBase<ProfileVM>
  {
  }
  public class ProfileVM : MEStatelessViewModel<ProfileVM>
  {
    MEIdentity identity = MEWebSecurity.CurrentIdentity();


    public UserAccount UserAccount { get; set; }

    public decimal Balance { get; set; }
    public PagedDataManager<UsersVM> UserListPageManager { get; set; }
    public ROUserPagedList.Criteria UserCriteria { get; set; }
    public ROUserPagedList UserList { get; set; }
    public ROUser UserID { get; set; }

    public MELib.Security.User EditingUser { get; set; }


    public ProfileVM()
    {
      this.UserListPageManager = new PagedDataManager<UsersVM>((c) => c.UserList, (c) => c.UserCriteria, "UserName", 20);
      this.UserCriteria = new ROUserPagedList.Criteria();
      this.UserList = new ROUserPagedList();
    }

    protected override void Setup()
    {
      base.Setup();

      UserAccount = UserAccountList.GetUserAccountList(identity.UserID).FirstOrDefault();
      UserAccount.UserName = MELib.CommonData.Lists.ROUserList.GetItem(identity.UserID).FullName;
      UserAccount.Balance = UserAccount.Balance;

      this.ValidationDisplayMode = ValidationDisplayMode.Controls | ValidationDisplayMode.SubmitMessage;

      this.UserList = (ROUserPagedList)UserListPageManager.GetInitialData();
    }

    [WebCallable] // Indicates that this method can be called remotely
    public static MELib.Security.User GetUser(int userId)
    {
      return MELib.Security.UserList.GetUserList(userId).FirstOrDefault(); // Retrieve the user object with the specified userId
    }

    [WebCallable(Roles = new string[] { "Security.Manage Users" })] 
    public static Result SaveUser(MELib.Security.User user)
    {
      if (user.SecurityGroupUserList.Count == 0)
      {
        //add a default security group of General User
        SecurityGroupUser securityGroupUser = SecurityGroupUser.NewSecurityGroupUser();
        securityGroupUser.SecurityGroupID = ROSecurityGroupList.GetROSecurityGroupList(true).FirstOrDefault(c => c.SecurityGroup == "General User")?.SecurityGroupID;
        user.SecurityGroupUserList.Add(securityGroupUser);
      }

      user.LoginName = user.EmailAddress;

      Result results = new Singular.Web.Result();
      Result Saveresults = user.SaveUser(user);
      MELib.Security.User SavedUser = (MELib.Security.User)Saveresults.Data; // Retrieve saved user object from the result

      if (SavedUser != null)
      {
        results.Success = true;
        results.Data = SavedUser;
      }
      else
      {
        results.Success = false;
        results.ErrorText = Saveresults.ErrorText;
      }
      return results;
    }
  }
}

