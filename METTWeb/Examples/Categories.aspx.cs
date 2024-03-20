using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MELib;


namespace MEWeb.Examples
{

  public partial class Categories : MEPageBase<CategoriesVM>
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  }
  public class CategoriesVM : MEStatelessViewModel<CategoriesVM>
  {

    public CategoriesVM()
    {

    }

    protected override void Setup()
    {
      base.Setup();
    }
  }
}


