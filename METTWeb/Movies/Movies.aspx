<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MEWeb.Movies.Movies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- Add page specific styles and JavaScript classes below -->
  <link href="../Theme/Singular/Custom/home.css" rel="stylesheet" />
  <link href="../Theme/Singular/Custom/customstyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
  <!-- Placeholder not used in this example -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <%
    using (var h = this.Helpers)
    {
      var MainContent = h.DivC("row pad-top-10");
      {
        var MainContainer = MainContent.Helpers.DivC("col-md-12 p-n-lr");
        {
          var PageContainer = MainContainer.Helpers.DivC("tabs-container");
          {
            var PageTab = PageContainer.Helpers.TabControl();
            {
              PageTab.Style.ClearBoth();
              PageTab.AddClass("nav nav-tabs");
              var ContainerTab = PageTab.AddTab("Available Movies");
              {
                var RowContentDiv = ContainerTab.Helpers.DivC("row");
                {
                  var ColContentDiv = RowContentDiv.Helpers.DivC("col-md-9");
                  {
                    var MoviesDiv = ColContentDiv.Helpers.BootstrapTableFor<MELib.Movies.Movie>((c) => c.MovieList, false, false, "");
                    {
                      var Rows = MoviesDiv.FirstRow;
                      {
                        var MovieTitle = Rows.AddColumn("Title");
                        {
                          var MovieTitleText = MovieTitle.Helpers.Span(c => c.MovieTitle);
                          MovieTitle.Style.Width = "250px";
                        }
                        var MovieDescription = Rows.AddColumn("Description");
                        {
                          var MovieDescriptionText = MovieDescription.Helpers.Span(c => c.MovieDescription);
                        }
                        var MovieRating = Rows.AddColumn("Add to Wishlist");
                        {
                          MovieRating.Style.Width = "50px";
                          var WatchBtn = MovieRating.Helpers.Button("", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.plus);
                          WatchBtn.AddClass("btn btn-primary btn-outline");
                          WatchBtn.Tooltip = "Add to your wishlist";

                          WatchBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "Wishlist()");

                        }
                        var MovieAction = Rows.AddColumn("Movie Price");
                        {
                          var MoviePriceValue = MovieAction.Helpers.Span(c => c.Price);
                        }
                        var editCol = Rows.AddColumn("Action");
                        {
                          editCol.Style.Width = "150px";
                          editCol.Style.TextAlign = Singular.Web.TextAlign.center;

                          var AddButton = editCol.Helpers.Button("Add to Cart", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.shoppingCart);
                          AddButton.AddClass("btn btn-danger btn-outline");
                          AddButton.AddBinding(Singular.Web.KnockoutBindingString.click, "GoToCart($data)");
                          AddButton.Tooltip = "Add to basket";
                        }
                      }
                    }
                  }
                  var RowColRight = RowContentDiv.Helpers.DivC("col-md-3");
                  {

                    var AnotherCardDiv = RowColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Filter Criteria");
                      }
                      var CardTitleToolsDiv = CardTitleDiv.Helpers.DivC("ibox-tools");
                      {
                        var aToolsTag = CardTitleToolsDiv.Helpers.HTMLTag("a");
                        aToolsTag.AddClass("collapse-link");
                        {
                          var iToolsTag = aToolsTag.Helpers.HTMLTag("i");
                          iToolsTag.AddClass("fa fa-chevron-up");
                        }
                      }
                      var ContentDiv = AnotherCardDiv.Helpers.DivC("ibox-content");
                      {
                        var RowContentDiv1 = ContentDiv.Helpers.DivC("row");
                        {

                          var MovieTitleContentDiv = RowContentDiv1.Helpers.DivC("col-md-12");
                          {
                            MovieTitleContentDiv.Helpers.LabelFor(c => ViewModel.MovieTitle);
                            var MovieTitleEditor = MovieTitleContentDiv.Helpers.EditorFor(c => ViewModel.MovieTitle);
                            MovieTitleEditor.AddClass("form-control marginBottom20 filterBox");
                          }
                          var FilterBtn = MovieTitleContentDiv.Helpers.Button("Apply Filter", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          {
                            FilterBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterMovieTitle($data)");
                            FilterBtn.AddClass("btn btn-primary btn-outline pull-right");
                          }

                          var MovieGenreContentDiv = RowContentDiv1.Helpers.DivC("col-md-12");
                          {
                            MovieGenreContentDiv.Helpers.LabelFor(c => ViewModel.MovieGenreID);
                            var ReleaseFromDateEditor = MovieGenreContentDiv.Helpers.EditorFor(c => ViewModel.MovieGenreID);
                            ReleaseFromDateEditor.AddClass("form-control marginBottom20 filterBox");

                            var FilterBtn1 = MovieGenreContentDiv.Helpers.Button("Apply Filter", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                            {
                              FilterBtn1.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterMovies($data)");
                              FilterBtn1.AddClass("btn btn-primary btn-outline pull-right");
                            }
                          }
                        }
                      }
                    }
                    var TotalCardDiv = RowColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = TotalCardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Total: ");
                      }
                      var CardTitleToolsDiv = CardTitleDiv.Helpers.DivC("ibox-tools");
                      {
                        var aToolsTag = CardTitleToolsDiv.Helpers.HTMLTag("a");
                        aToolsTag.AddClass("collapse-link");
                        {
                          var iToolsTag = aToolsTag.Helpers.HTMLTag("i");
                          iToolsTag.AddClass("fa fa-chevron-up");
                        }
                      }
                    }
                    var TotalContentDiv = TotalCardDiv.Helpers.DivC("ibox-content");
                    {
                      var RowContentDiv2 = TotalContentDiv.Helpers.DivC("row");
                      {
                        var MovieGenreContentDiv = RowContentDiv2.Helpers.DivC("col-md-12");
                        {
                          MovieGenreContentDiv.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Total purchase is: R " + c.UserAccount.TotalPurchased + " and " + c.UserMovieList.Count + " item(s).");
                        }
                      }
                    }
                    var CheckoutContentDiv = TotalCardDiv.Helpers.DivC("ibox-content");
                    {
                      var RowContentDiv2 = CheckoutContentDiv.Helpers.DivC("row");
                      {
                        var ResetBtn = RowContentDiv2.Helpers.Button("Reset Total", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                        {
                          ResetBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "ClearTotal()");
                          ResetBtn.AddClass("btn btn-primary btn-outline pull-left");
                        }
                        var CheckoutBtn = RowContentDiv2.Helpers.Button("Go to Cart", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                        {
                          CheckoutBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "Navigate()");
                          CheckoutBtn.AddClass("btn btn-primary btn-outline pull-right");
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
  %>
  <script type="text/javascript">
    // Place page specific JavaScript here or in a JS file and include in the HeadContent section
    Singular.OnPageLoad(function () {
      $("#menuItem1").addClass('active');
      $("#menuItem1 > ul").addClass('in');
    });

    var GoToCart = function (obj) {
      
      // ADD MOVIE TO CART

      MEHelpers.QuestionDialogYesNo("Are you sure you would like to add this item?", 'center',
        function () { // Yes
          ViewModel.CallServerMethod('AddMovie', { MovieID: obj.MovieID(), ShowLoadingBar: true }, function (result) {
            if (result.Success) {
              ViewModel.UserMovieList.Set(result.Data);
              MEHelpers.Notification("Item added successfully.", 'center', 'success', 5000);
            }
            else {
              MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
            }
          })
        },
        function () { // No
          var totalPrice = ViewModel.UserAccount().TotalPurchased() - obj.Price();
          totalPrice = Number(totalPrice.toFixed(2));
          ViewModel.UserAccount().TotalPurchased(totalPrice);
          var jsonBalance = ViewModel.UserAccount().Serialise();

          ViewModel.CallServerMethod('AddToCart', { Account: jsonBalance, ShowLoadingBar: true }, function (result) {
            if (result.Success) {
              ViewModel.UserAccount.Set(result.Data);
            }
            else {
              MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
            }

          })
        }
      );

      // ADDING price of purchased items
      var totalPrice = ViewModel.UserAccount().TotalPurchased() + obj.Price(); // add price to the total
      totalPrice = Number(totalPrice.toFixed(2));
      ViewModel.UserAccount().TotalPurchased(totalPrice); // set the total balance to the new one
      var jsonBalance = ViewModel.UserAccount().Serialise(); // change to json format

      ViewModel.CallServerMethod('AddToCart', { Account: jsonBalance, ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          ViewModel.UserAccount.Set(result.Data);
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }

      })
    };

    var Navigate = function () {
      window.location = '../Profile/Transactions.aspx';

    };

    var Wishlist = function () {
      MEHelpers.Notification("Movie successfully added to wishlist", 'center', 'success', 5000);
    };

    //var WatchMovie = function (obj) {

    //  MEHelpers.QuestionDialogYesNo("Are you sure you would like to watch this movie?", 'center',
    //    function () { // Yes
    //      ViewModel.CallServerMethod('WatchMovie', { MovieID: obj.MovieID(), ShowLoadingBar: true }, function (result) {
    //        if (result.Success) {
    //          MEHelpers.Notification("Item deleted successfully.", 'center', 'success', 5000);
    //        }
    //        else {
    //          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
    //        }
    //      })
    //    },
    //    function () { // No
    //      window.location = "../Movies/Movies.aspx"; // or remove dialog
    //    })
    //};

    var ClearTotal = function () {// reset total to 0
      var totalPrice = 0;
      ViewModel.UserAccount().TotalPurchased(totalPrice);
      var jsonBalance = ViewModel.UserAccount().Serialise();

      ViewModel.CallServerMethod('AddToCart', { Account: jsonBalance, ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          ViewModel.UserAccount.Set(result.Data);
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }

      })
    };

    var FilterMovies = function (obj) {

      ViewModel.CallServerMethod('FilterMovies', { MovieGenreID: obj.MovieGenreID(), ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          //MEHelpers.Notification("Movies filtered successfully.", 'center', 'info', 1000);
          ViewModel.MovieList.Set(result.Data); // returns movies matching the genre
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }
      })
    };

    var FilterMovieTitle = function (obj) {
      ViewModel.CallServerMethod('FilterMovieTitle', { MovieTitle: obj.MovieTitle(), ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          //MEHelpers.Notification("Movies filtered successfully.", 'center', 'info', 1000);
          ViewModel.MovieList.Set(result.Data);
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }
      })
    };

  </script>
</asp:Content>
