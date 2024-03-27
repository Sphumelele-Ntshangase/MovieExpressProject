using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using MELib.Accounts;
using MELib.Movies;
using MELib.Security;
using MEWeb.Movies;
using Singular.Web;
using Singular.Web.Data;

namespace MEWeb.Profile
{
  public partial class Transactions : MEPageBase<TransactionsVM>
  {
  }
  public class TransactionsVM : MEStatelessViewModel<TransactionsVM>
  {
    MEIdentity identity = MEWebSecurity.CurrentIdentity();
    public TransactionsVM()
    {

    }

    public MELib.Movies.Movie Movie { get; set; }    
    public UserAccount UserAccount { get; set; }
    public MELib.Movies.UserMovieList UserMovieList { get; set; }

    public int MovieID { get; set; }
    
    public bool FoundUserMoviesInd { get; set; }


    [Singular.DataAnnotations.DropDownWeb(typeof(MELib.RO.ROMovieGenreList), UnselectedText = "Select", ValueMember = "MovieGenreID", DisplayMember = "Genre")] //this enabled a list of genres on the site
    [Display(Name = "Genre")]
    public int? MovieGenreID { get; set; }

    protected override void Setup()
    {
      base.Setup();

      UserAccount = UserAccountList.GetUserAccountList(identity.UserID).FirstOrDefault();
      //UserAccount.UserName = MELib.CommonData.Lists.ROUserList.GetItem(identity.UserID).FullName; // Another way of getting a user name
      Movie = MELib.Movies.MovieList.GetMovieList().FirstOrDefault();
      
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
    public Result AddToCart(UserAccount Account)
    {
      Result store = new Result();

      if (Account != null && Account.IsValid)
      {
        Singular.SaveHelper SavedBalanceSaveHelper = Account.TrySave(typeof(UserAccountList)); // specify the type of list where the user balance will be saved
        UserAccount SavedUserAccount = (UserAccount)SavedBalanceSaveHelper.SavedObject;

        if (SavedBalanceSaveHelper.Success)
        {
          store.Data = UserMovieList.GetUserMovieList(MovieID);
          store.Success = true;
        }
        else
        {
          store.ErrorText = "Could not deduct the amount";
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
    public Result UpdateBalance(UserAccount Account)
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
          store.ErrorText = "Could not deduct the amount";
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
    public static Result DeleteMovie(int MovieID)
    {
      MEIdentity identity = MEWebSecurity.CurrentIdentity();
      Result sr = new Result();
      try
      {
        UserMovie UserMovieStatus = MELib.Movies.UserMovieList.GetUserMovieList().FirstOrDefault(c => c.MovieID == MovieID);
        UserMovieStatus.MovieID = MovieID;
        UserMovieStatus.UserID = identity.UserID;
        UserMovieStatus.IsActiveInd = false;
        UserMovieStatus.DeletedBy = identity.UserID;
        UserMovieStatus.DeletedDate = DateTime.Now;

        if (UserMovieStatus != null && UserMovieStatus.IsValid)
        {
          Singular.SaveHelper SavedMovieStatusSaveHelper = UserMovieStatus.TrySave(typeof(UserMovieList));
          UserMovie SavedMovieStatus = (UserMovie)SavedMovieStatusSaveHelper.SavedObject;

          if (SavedMovieStatusSaveHelper.Success)
          {
            sr.Data = UserMovieList.GetUserMovieList();
            sr.Success = true;
          }
          else
          {
            sr.ErrorText = "Could not delete the movie";
            sr.Success = false;
          }
        }
        else
        {
          sr.ErrorText = "Account provided is invalid";
          sr.Success = false;
        }
      }
      catch (Exception e)
      {
        sr.Data = "Movie not deleted";
        sr.Success = false;
      }
      return sr;
    }
  }
}

