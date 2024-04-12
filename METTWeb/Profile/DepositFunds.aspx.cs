using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MELib.Accounts;
using MELib.Maintenance;
using MELib.Movies;
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
    public string PostalAddress { get; set; }
    public Calendar Calendar { get; set; }
    public MELib.Security.User EditingUser { get; set; }
    public string FullName { get; set; }
    public int CardNo { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int CardCode { get; set; }

    public MELib.Movies.UserMovieList UserMovieList { get; set; }

    public bool FoundUserMoviesInd { get; set; }

    public DepositFundsVM()
    {

    }
    protected override void Setup()
    {
      base.Setup();
      
      UserAccount = UserAccountList.GetUserAccountList(identity.UserID).FirstOrDefault();

      UserMovieList = MELib.Movies.UserMovieList.GetUserMovieList();

      if (UserMovieList.Count() > 0)
      {
        FoundUserMoviesInd = true;
      }
      else
      {
        FoundUserMoviesInd = false;
      }
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

    [WebCallable]
    public Result AddToCart(UserAccount Account)
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

