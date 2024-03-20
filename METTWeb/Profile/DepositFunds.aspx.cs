using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MELib.Accounts;
using MELib.Maintenance;
using MELib.Security;
using Singular.Emails;
using Singular.Web;

namespace MEWeb.Profile
{
  public partial class DepositFunds : MEPageBase<DepositFundsVM>
  {
  }
  public class DepositFundsVM : MEStatelessViewModel<DepositFundsVM>
  {
    MEIdentity identity = MEWebSecurity.CurrentIdentity();

    public UserAccount UserAccount { get; set; }
    public int UserID { get; set; }
    public decimal Balance { get; set; }
    public Email EmailAddress { get; set; }

    
    public DepositFundsVM()
    {

    }
    protected override void Setup()
    {
      base.Setup();
      
      UserAccount = UserAccountList.GetUserAccountList(identity.UserID).FirstOrDefault();
    }

    [WebCallable]
    public Result AddBalance(UserAccount Account)
    {
      Result store = new Result();

      if (Account != null && Account.IsValid)
      {
        Singular.SaveHelper SavedBalanceSaveHelper = Account.TrySave(typeof(UserAccountList)); // specify the type of list where the user balance will be saved
        UserAccount SavedUserAccount = (UserAccount)SavedBalanceSaveHelper.SavedObject;

        if (SavedBalanceSaveHelper.Success) 
        {
          store.Data = SavedUserAccount;
          store.Success = true;
        }
        else
        {
          store.ErrorText = "Problem with updating the balance";
          store.Success = false;
        }
      }
      else
      {
        store.ErrorText = "Account provided is invalid";
        store.Success = false;
      }
      return store;
    }
  }
}

