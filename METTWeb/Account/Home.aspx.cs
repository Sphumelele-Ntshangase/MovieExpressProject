using System;
using Singular.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web.Data;
using MELib.RO;
using MELib.Security;
using Singular;
using MELib.Accounts;
using MELib.Movies;

namespace MEWeb.Account
{
  public partial class Home : MEPageBase<HomeVM>
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  }
  public class HomeVM : MEStatelessViewModel<HomeVM>
  {
    // Declare your page variables/properties here
    MEIdentity identity = MEWebSecurity.CurrentIdentity();

    public MELib.Movies.MovieList MovieList { get; set; }

    public bool FoundUserMoviesInd { get; set; }

    public string LoggedInUserName { get; set; }

    public UserAccount UserAccount { get; set; }
    public DateTime ReleaseFromDate { get; set; }

    public MELib.Movies.UserMovieList UserMovieList { get; set; }

    public HomeVM()
    {

    }

    protected override void Setup()
    {
      base.Setup();

      // On page load initiate/set your data/variables and or properties here
      MovieList = MELib.Movies.MovieList.GetMovieList();
      UserMovieList = MELib.Movies.UserMovieList.GetUserMovieList();

      if (UserMovieList.Count() > 0)
      {
        FoundUserMoviesInd = true;
      }
      else
      {
        FoundUserMoviesInd = false;
      }


      LoggedInUserName = Singular.Security.Security.CurrentIdentity.UserName;

      UserAccount = UserAccountList.GetUserAccountList(identity.UserID).FirstOrDefault();
      UserAccount.UserName = MELib.CommonData.Lists.ROUserList.GetItem(identity.UserID).FullName;
    }

    [WebCallable(LoggedInOnly = true)]
    public string RentMovie(int MovieID)
    {
      var url = $"../Movies/Movie.aspx?MovieId={HttpUtility.UrlEncode(Singular.Encryption.EncryptString(MovieID.ToString()))}";
      return url;
    }

    // Place your page's WebCallable methods here

    // Example WebCallable Method called GetSomeData layout/structure

    /// <summary>
    /// This is a very basic example of a WebCallable method
    /// </summary>
    /// <param name="SomeReferenceID"></param>
    /// <returns></returns>
    [Singular.Web.WebCallable(LoggedInOnly = true)]
    public static Singular.Web.Result GetSomeData(int SomeReferenceID)
    {
      Result sr = new Result();
      try
      {
        // Perform some action here and return the result
        // sr.Data = "";
        sr.Success = true;
      }
      catch (Exception e)
      {
        sr.Data = e.InnerException;
        sr.Success = false;
      }
      return sr;
    }

    [WebCallable]
    public Result FilterByReleaseDate(DateTime ReleaseDate)
    {
      Result sr = new Result();
      try
      {
        sr.Data = MELib.Movies.MovieList.GetMovieList().Where(a => a.ReleaseDate == ReleaseDate);
        sr.Success = true;
      }
      catch (Exception e)
      {
        WebError.LogError(e, "Page: Home.aspx | Method: FilterByReleaseDate", $"(DateTime ReleaseDate, ({ReleaseDate})");
        sr.Data = e.InnerException;
        sr.ErrorText = "Could not filter movies by released date.";
        sr.Success = false;
      }
      return sr;
    }
  }
}


