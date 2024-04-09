using MELib.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEWeb.Profile
{
  public partial class Orders : MEPageBase<OrdersVM>
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }

  public class OrdersVM : MEStatelessViewModel<OrdersVM>
  {
    MEIdentity identity = MEWebSecurity.CurrentIdentity();

    public MELib.Movies.UserMovieList UserMovieList { get; set; }

    public bool FoundUserMoviesInd { get; set; }

    public OrdersVM()
    {
    }

    protected override void Setup()
    {
      base.Setup();

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
  }
}