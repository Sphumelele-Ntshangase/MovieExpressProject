<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="MEWeb.Profile.Transactions" %>

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
              var ContainerTab = PageTab.AddTab("Cart");
              {
                var RowContentDiv = ContainerTab.Helpers.DivC("row");
                {

                  #region Left Column / Data
                  var LeftColRight = RowContentDiv.Helpers.DivC("col-md-9");
                  {

                    var CardDiv = LeftColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = CardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Purchases");
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
                      var ContentDiv = CardDiv.Helpers.DivC("ibox-content");
                      {
                        var Headings = ContentDiv.Helpers.DivC("row");
                        {
                          var LeftColContentDiv = Headings.Helpers.DivC("col-md-12");
                          {
                            LeftColContentDiv.Helpers.HTML("<b>NOTICE: </b>Clicking <b>Remove</b>, deletes the movie from the list.");
                            LeftColContentDiv.AddBinding(Singular.Web.KnockoutBindingString.visible, c => ViewModel.FoundUserMoviesInd == true);
                            //create a table using bootstrap
                            var PurchaseTable = LeftColContentDiv.Helpers.BootstrapTableFor<MELib.Movies.UserMovie>((c) => c.UserMovieList, false, false, "");
                            var FirstRow = PurchaseTable.FirstRow;
                            {
                              var MovieTitle = FirstRow.AddColumn("Title");
                              {
                                var MovieTitleText = MovieTitle.Helpers.Span(c => c.MovieTitle);
                                MovieTitle.Style.Width = "450px";
                              }
                              //var MoviePriceCol = FirstRow.AddColumn("Price");
                              //{
                              //  MoviePriceCol.AddBinding(Singular.Web.KnockoutBindingString.text, a => a.Price);
                              //  var MoviePriceValue = MoviePriceCol.Helpers.Span(c => c.Price);
                              //  MoviePriceCol.Style.Width = "450px";
                              //}
                              var editCol = FirstRow.AddColumn("Action");
                              {
                                editCol.Style.Width = "300px";
                                editCol.Style.TextAlign = Singular.Web.TextAlign.center;

                                var deleteButton = editCol.Helpers.Button("Remove", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                                deleteButton.AddClass("btn-danger btn btn-outline");
                                deleteButton.AddBinding(Singular.Web.KnockoutBindingString.click, "DeleteMovie($data)");
                                deleteButton.Tooltip = "Remove from purchases";
                              }
                            }
                            //LeftColContentDiv.AddBinding(Singular.Web.KnockoutBindingString.value, a => a.Movie.Price);
                          }
                        }
                      }
                    }
                    #endregion

                    #region Right Column / Filters
                    var RowColRight = RowContentDiv.Helpers.DivC("col-md-3");
                    {

                      //var AnotherCardDiv = RowColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                      //{
                      //  var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                      //  {
                      //    CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                      //    CardTitleDiv.Helpers.HTML().Heading5("Filter Criteria");
                      //  }
                      //  var CardTitleToolsDiv = CardTitleDiv.Helpers.DivC("ibox-tools");
                      //  {
                      //    var aToolsTag = CardTitleToolsDiv.Helpers.HTMLTag("a");
                      //    aToolsTag.AddClass("collapse-link");
                      //    {
                      //      var iToolsTag = aToolsTag.Helpers.HTMLTag("i");
                      //      iToolsTag.AddClass("fa fa-chevron-up");
                      //    }
                      //  }
                      //}
                      //var ContentDiv = AnotherCardDiv.Helpers.DivC("ibox-content");
                      //{
                      //  var RowContentDiv1 = ContentDiv.Helpers.DivC("row");
                      //  {
                      //    var ColContentDiv = RowContentDiv1.Helpers.DivC("col-md-12");
                      //    {
                      //      var MovieTitleContentDiv = RowContentDiv1.Helpers.DivC("col-md-12");
                      //      {
                      //        MovieTitleContentDiv.Helpers.LabelFor(c => c.MovieTitle);
                      //        var MovieTitleEditor = MovieTitleContentDiv.Helpers.EditorFor(c => c.MovieTitle);
                      //        MovieTitleEditor.AddClass("form-control marginBottom20 filterBox");
                      //        MovieTitleEditor.AddBinding(Singular.Web.KnockoutBindingString.id, "MovieTitle");
                      //      }
                      //    }
                      //    var MovieGenreContentDiv = RowContentDiv1.Helpers.DivC("col-md-12");
                      //    {

                      //      MovieGenreContentDiv.Helpers.LabelFor(c => ViewModel.MovieGenreID);
                      //      var ReleaseFromDateEditor = MovieGenreContentDiv.Helpers.EditorFor(c => ViewModel.MovieGenreID);
                      //      ReleaseFromDateEditor.AddClass("form-control marginBottom20 ");

                      //      var FilterBtn = MovieGenreContentDiv.Helpers.Button("Apply Filter", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                      //      {
                      //        FilterBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterMovies($data)");
                      //        FilterBtn.AddClass("btn btn-primary btn-outline pull-right");
                      //      }

                      //    }
                      //  }
                      //}
                      var TotalCardDiv = RowColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                      {
                        var CardTitleDiv1 = TotalCardDiv.Helpers.DivC("ibox-title");
                        {
                          CardTitleDiv1.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                          CardTitleDiv1.Helpers.HTML().Heading5("Total: ");
                        }
                        var CardTitleToolsDiv1 = CardTitleDiv1.Helpers.DivC("ibox-tools");
                        {
                          var aToolsTag = CardTitleToolsDiv1.Helpers.HTMLTag("a");
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
                            MovieGenreContentDiv.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Total purchase is: R " + c.UserAccount.TotalPurchased + " and " + c.UserMovieList.Count + " items.");
                          }
                        }
                      }
                      var CheckoutContentDiv = TotalCardDiv.Helpers.DivC("ibox-content");
                      {
                        var RowContentDiv2 = CheckoutContentDiv.Helpers.DivC("row");
                        {
                          var BackToMoviesBtn = RowContentDiv2.Helpers.Button("Add More Movies", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          {
                            BackToMoviesBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "BackToMovies()");
                            BackToMoviesBtn.AddClass("btn btn-primary btn-outline pull-left");
                          }
                          var CheckoutBtn = RowContentDiv2.Helpers.Button("Checkout", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          {
                            CheckoutBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "Checkout()");
                            CheckoutBtn.AddClass("btn btn-primary btn-outline pull-right");
                          }
                        }
                      }

                    }
                    #endregion
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

    //var FilterMovies = function (obj) {
    //  //alert('Movie Genre ID ' + obj.MovieGenreID());

    //  ViewModel.CallServerMethod('FilterMovies', { MovieGenreID: obj.MovieGenreID(), ShowLoadingBar: true }, function (result) {
    //    if (result.Success) {
    //      MEHelpers.Notification("Movies filtered successfully.", 'center', 'info', 1000);
    //      ViewModel.MovieList.Set(result.Data); // returns movies matching the genre
    //    }
    //    else {
    //      MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
    //    }
    //  })
    //};

    var Checkout = function () { // deduct the price when the user clicks the button
      if (ViewModel.UserAccount().TotalPurchased() <= ViewModel.UserAccount().Balance()) {
        var newBalance = ViewModel.UserAccount().Balance() - ViewModel.UserAccount().TotalPurchased(); // deduct price from the balance
        ViewModel.UserAccount().Balance(newBalance); // set the account balance to the new one
        var jsonBalance = ViewModel.UserAccount().Serialise(); // change to json format

        ViewModel.CallServerMethod('AddToCart', { Account: jsonBalance, ShowLoadingBar: true }, function (result) {
          if (result.Success) {
            ViewModel.UserMovieList.Set(result.Data);
            ViewModel.UserAccount.Set(result.Data);
            alert("Total purchase has been deducted");
            window.location = '../Profile/DepositFunds.aspx';
          }
          else {
            MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
          }
        });
      }
      else {
        MEHelpers.Notification("Total purchase is more than the account balance you have", 'center', 'warning', 5000);
      }
    };

    var BackToMovies = function () {
      window.location = '../Movies/Movies.aspx';
    }

    var DeleteMovie = function (obj) {
      console.log(obj.MovieID());

      MEHelpers.QuestionDialogYesNo("Are you sure you would like to delete this item?", 'center',
        function () { // Yes
          var totalPrice = ViewModel.UserAccount().TotalPurchased() - obj.Price();
          ViewModel.UserAccount().TotalPurchased(totalPrice);
          var jsonBalance = ViewModel.UserAccount().Serialise();

          ViewModel.CallServerMethod('DeleteMovie', { MovieID: obj.MovieID(), Account: jsonBalance, ShowLoadingBar: true }, function (result) {
            if (result.Success) {
              ViewModel.UserMovieList.Set(result.Data);
              ViewModel.UserAccount.Set(result.Data);
              MEHelpers.Notification("Item deleted successfully.", 'center', 'success', 5000);
            }
            else {
              MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
            }
          })
        },
        function () { // No
        })
    };



  </script>
</asp:Content>
