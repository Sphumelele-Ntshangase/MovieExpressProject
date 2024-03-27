using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using MELib.Accounts;
using MELib.Movies;
using MELib.Security;
using Singular;
using Singular.SmsSending;
using Singular.Web;

namespace MEWeb.Movies
{
  public partial class Movies : MEPageBase<MoviesVM>
  {
  }
  public class MoviesVM : MEStatelessViewModel<MoviesVM>
  {
    MEIdentity identity = MEWebSecurity.CurrentIdentity();
    public MELib.Movies.MovieList MovieList { get; set; }
    public MELib.Movies.UserMovieList UserMovieList { get; set; }

    public decimal Price { get; set; }

    // Filter Criteria
    public string MovieTitle { get; set; }

    public UserAccount UserAccount { get; set; }

    /// <summary>
    /// Gets or sets the Movie Genre ID
    /// </summary>
    [Singular.DataAnnotations.DropDownWeb(typeof(MELib.RO.ROMovieGenreList), UnselectedText = "Select", ValueMember = "MovieGenreID", DisplayMember = "Genre")]
    [Display(Name = "Genre")]
    public int? MovieGenreID { get; set; }

    public MoviesVM()
    {

    }
    protected override void Setup()
    {
      base.Setup();

      UserAccount = UserAccountList.GetUserAccountList(identity.UserID).FirstOrDefault();
      MovieList = MELib.Movies.MovieList.GetMovieList();
      UserMovieList = MELib.Movies.UserMovieList.GetUserMovieList();
    }

    //[WebCallable(LoggedInOnly = true)]
    //public string RentMovie(int MovieID)
    //{
    //  var url = $"../Movies/Movie.aspx?MovieId={HttpUtility.UrlEncode(Singular.Encryption.EncryptString(MovieID.ToString()))}";
    //  return url;
    //}

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

    //[WebCallable]
    //public static Result WatchMovie(int MovieID)
    //{
    //  Result sr = new Result();
    //  try
    //  {

    //    // ToDo Check User Balance
    //    // ToDo Insert Data in Transactions
    //    sr.Success = true;
    //  }
    //  catch (Exception e)
    //  {
    //    sr.Data = e.InnerException;
    //    sr.Success = false;
    //  }
    //  return sr;
    //}

    [WebCallable]
    public Result FilterMovies(int MovieGenreID)
    {
      Result sr = new Result();
      try
      {
        sr.Data = MELib.Movies.MovieList.GetMovieList(MovieGenreID);
        sr.Success = true;
      }
      catch (Exception e)
      {
        WebError.LogError(e, "Page: LatestReleases.aspx | Method: FilterMovies", $"(int MovieGenreID, ({MovieGenreID})");
        sr.Data = e.InnerException;
        sr.ErrorText = "Could not filter movies by category.";
        sr.Success = false;
      }
      return sr;
    }

    [WebCallable]
    public Result FilterMovieTitle(string MovieTitle)
    {
      Result sr = new Result();
      try
      {
        sr.Data = MELib.Movies.MovieList.GetMovieList().FirstOrDefault(a => a.MovieTitle == MovieTitle);
        sr.Success = true;
      }
      catch (Exception e)
      {
        WebError.LogError(e, "Page: LatestReleases.aspx | Method: FilterMovieTitle", $"(string MovieTitle, ({MovieTitle})");
        sr.Data = e.InnerException;
        sr.ErrorText = "Could not filter movies by category.";
        sr.Success = false;
      }
      return sr;
    }

    [WebCallable]
    public static Result AddMovie(int MovieID)
    {
      MEIdentity identity = MEWebSecurity.CurrentIdentity();
      Result sr = new Result();
      try
      {
        UserMovie userMovie = new UserMovie(); // DECLARING USER MOVIE, creating an object, add a new record
        // setting these columns to have these values
        userMovie.MovieID = MovieID;
        userMovie.UserID = identity.UserID;
        userMovie.IsActiveInd = true;
        userMovie.WatchedDate = DateTime.Now;

        if (userMovie != null && userMovie.IsValid)
        {
          Singular.SaveHelper SavedUserMoviesSaveHelper = userMovie.TrySave(typeof(UserMovieList)); // specify the type of list where the user balance will be saved
          UserMovie SavedUserMovies = (UserMovie)SavedUserMoviesSaveHelper.SavedObject;

          if (SavedUserMoviesSaveHelper.Success)
          {
            sr.Data = UserMovieList.GetUserMovieList();
            sr.Success = true;
          }
          else
          {
            sr.ErrorText = "Could not add the movie to transactions";
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
        sr.Data = "Movie not added";
        sr.Success = false;
      }
      return sr;
    }

  }
}

