<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepositFunds.aspx.cs" Inherits="MEWeb.Profile.DepositFunds" %>

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
              var ContainerTab = PageTab.AddTab("Deposits & Checkout");
              {
                var RowContentDiv = ContainerTab.Helpers.DivC("row");
                {

                  #region Left Column / Data
                  var RowColLeft = RowContentDiv.Helpers.DivC("col-md-6");
                  {

                    var AnotherCardDiv = RowColLeft.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Deposit Funds");
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


                    var ContentDiv = AnotherCardDiv.Helpers.DivC("ibox-content");
                    {
                      var AddingFunds = ContentDiv.Helpers.DivC("row");
                      {
                        var RowDiv = AddingFunds.Helpers.DivC("col-md-12 marginBottom20");
                        {
                          // Show current balance
                          RowDiv.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Your Current Balance is: R " + c.UserAccount.Balance);
                        }
                        var LeftColContentDiv = AddingFunds.Helpers.DivC("col-md-12 marginBottom20");
                        {

                          //non-functional buttons for payment methods
                          LeftColContentDiv.Helpers.HTML("<p>Payment Method:</p>");

                          var first = LeftColContentDiv.Helpers.Button("PayPal", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.paypal);
                          first.AddClass("btn btn-info btn-outline");
                          first.AddBinding(Singular.Web.KnockoutBindingString.click, "PayPal()");

                          var second = LeftColContentDiv.Helpers.Button("Visa", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.cc_visa);
                          second.AddClass("btn btn-info btn-outline");
                          second.AddBinding(Singular.Web.KnockoutBindingString.click, "Visa()");

                          var third = LeftColContentDiv.Helpers.Button("MasterCard", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.cc_mastercard);
                          third.AddClass("btn btn-info btn-outline");
                          third.AddBinding(Singular.Web.KnockoutBindingString.click, "MasterCard()");

                          var LabelAmount = LeftColContentDiv.Helpers.HTML("<p><br>Enter Amount:</p>");
                          var createEditor = LeftColContentDiv.Helpers.DivC("row");
                          {
                            var editorSize = createEditor.Helpers.DivC("col-md-6");
                            {
                              var labelEditor = editorSize.Helpers.EditorFor(a => a.Balance);
                              {
                                var EnteredAmount = labelEditor.AddClass("form-control marginBottom20 text-left");
                              }
                            }
                          }
                          var RightColContentDiv = AddingFunds.Helpers.DivC("col-md-12");
                          {
                            // Fund Account Button
                            var AddFunds = RightColContentDiv.Helpers.Button("Add Funds", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                            {
                              AddFunds.AddBinding(Singular.Web.KnockoutBindingString.click, "AddBalance($data)");
                              AddFunds.AddClass("btn btn-primary btn-outline pull-right");
                            }
                          }
                        }
                      }
                    }
                  }
                  #endregion

                  #region Checkout Column / Filters
                  var MiddleColRight = RowContentDiv.Helpers.DivC("col-md-6");
                  {
                    var AnotherCardDiv = MiddleColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Checkout");
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
                    var ContentDiv = AnotherCardDiv.Helpers.DivC("ibox-content");
                    {
                      ContentDiv.Helpers.HTML("<p><h4>Tickets Delivery Options:</h4></p>");
                      var CheckoutRow = ContentDiv.Helpers.DivC("row");
                      {
                        var RowDiv = CheckoutRow.Helpers.DivC("col-md-12");
                        {

                        }
                        var LeftColContentDiv = CheckoutRow.Helpers.DivC("col-md-12");
                        {
                          LeftColContentDiv.Helpers.HTML("<input type=\"radio\" id=\"collection\" name=\"option\" value=\"collect\"><label for=\"collect\">Collection</label>");
                          var createEditor = LeftColContentDiv.Helpers.DivC("row");
                          {
                            var editorSize = createEditor.Helpers.DivC("col-md-6");
                            {
                              editorSize.Helpers.HTML("<label for=\"start\">Choose date:</label><br><input type=\"date\" id=\"start\" name=\"collect-date\" value=\"yyyy-mm-dd\" min=\"2024-04-01\" max=\"2024-12-31\" />");
                            }
                          }
                        }
                        var MidColContentDiv = CheckoutRow.Helpers.DivC("col-md-12 marginBottom20");
                        {
                          LeftColContentDiv.Helpers.HTML("<br><input type=\"radio\" id=\"delivery\" name=\"option\" value=\"deliver\"><label for=\"deliver\">Delivery</label>");
                          //var first = MidColContentDiv.Helpers.Button("Enter Address", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          //first.AddClass("btn btn-info btn-outline");
                          //first.AddBinding(Singular.Web.KnockoutBindingString.click, "EnterAddress($data)");
                          var LabelAmount = MidColContentDiv.Helpers.HTML("<label for=\"start\">Enter Address:</label>");
                          var createEditor = MidColContentDiv.Helpers.DivC("row");
                          {
                            var editorSize = createEditor.Helpers.DivC("col-md-6");
                            {
                              var labelEditor = editorSize.Helpers.EditorFor(a => a.PostalAddress, "e.g., 11 Imam Haron Rd, Claremont, Cape Town, 7708");
                              {
                                var EnteredAmount = labelEditor.AddClass("form-control text-left");
                              }
                            }
                          }
                        }
                        var RightColContentDiv = CheckoutRow.Helpers.DivC("col-md-12");
                        {
                          // Fund Account Button
                          var AddFunds = RightColContentDiv.Helpers.Button("Complete Order", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          {
                            AddFunds.AddBinding(Singular.Web.KnockoutBindingString.click, "CompleteOrder()");
                            AddFunds.AddClass("btn btn-primary btn-outline pull-right");
                          }

                        }
                      }
                    }
                  }
                  #endregion
                  #region Right Column / Data
                  var RowColRight = RowContentDiv.Helpers.DivC("col-md-6");
                  {
                  }
                  #endregion
                }
              }
              var TabHeading = PageTab.AddTab("Orders History");
              {
                var MainRow = TabHeading.Helpers.DivC("row margin0");
                {
                  var MainCol = MainRow.Helpers.DivC("col-md-12");
                  {
                    MainCol.Helpers.HTML("<p>Below, you will find movies you have ordered tickets for.</p>");
                    MainCol.Helpers.HTML("<p></br></p>");
                  }
                }
                // Create another row with columns
                var FirstRow = TabHeading.Helpers.DivC("row margin0");
                {
                  var RowCol = FirstRow.Helpers.DivC("col-md-12");
                  {
                    var AnotherCardDiv = RowCol.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("History");
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
                        var RowContentDiv = ContentDiv.Helpers.DivC("row");
                        {

                          // Show if Movies Watched USe Knockout Binding and Property on ViewModel
                          var MovieColContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                          {
                            var UserMovieList = MovieColContentDiv.Helpers.BootstrapTableFor<MELib.Movies.UserMovie>((c) => c.UserMovieList, false, false, "");
                            {
                              var MovieListRow = UserMovieList.FirstRow;
                              {
                                var MovieTitle = MovieListRow.AddColumn("Title");
                                {
                                  //var MovieTitleText = MovieTitle.Helpers.Span(c => c.MovieTitle);
                                }
                                var MovieGenre = MovieListRow.AddColumn("Price");
                                {
                                  //var MovieGenreText = MovieGenre.Helpers.Span(c => c.Price);
                                }
                              }
                              var MoviPaginationColContainer = MovieColContentDiv.Helpers.DivC("pagination-container");
                              {
                              }
                            }
                          }

                          // Show If No Movies Watched
                          var ColContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                          {

                          }
                        }

                      }
                    }
                  }
                }
              }
            }
            //var ContainerTab1 = PageTab.AddTab("Orders");
            //{

            //}
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

    var AddBalance = function (inputElement) {
      if (ViewModel.Balance() > 0) {
        var newBalance = ViewModel.UserAccount().Balance() + inputElement.Balance(); // add entered amount to the balance
        newBalance = Number(newBalance.toFixed(2));
        ViewModel.UserAccount().Balance(newBalance); // set the account balance to the new one
        var jsonBalance = ViewModel.UserAccount().Serialise(); // change to json format

        ViewModel.CallServerMethod('AddBalance', { Account: jsonBalance, ShowLoadingBar: true }, function (result) {
          if (result.Success) {
            ViewModel.UserAccount.Set(result.Data);
            MEHelpers.Notification("Balance Updated", 'center', 'success', 5000);
            ViewModel.Balance(0);
          }
          else {
            MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
          }

        });
      }
      else {
        MEHelpers.Notification("Enter a value greater than 0", 'center', 'warning', 5000);
      }

    }

    var PayPal = function () {

    }
    var Visa = function () {

    }
    var MasterCard = function () {

    }

    var CompleteOrder = function () {
      // reset total purchase to 0
      var totalPrice = 0;
      ViewModel.UserAccount().TotalPurchased(totalPrice);
      var jsonBalance = ViewModel.UserAccount().Serialise();

      ViewModel.CallServerMethod('AddBalance', { Account: jsonBalance, ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          ViewModel.UserAccount.Set(result.Data);
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }

      });

      if (confirm("Order Completed! Click Ok to go back home")) {
        window.location = window.location = '../Account/Home.aspx';
      }
      else {
        //window.location = window.location = '../Profile/DepositFunds.aspx';
      }


    }

  </script>
</asp:Content>
