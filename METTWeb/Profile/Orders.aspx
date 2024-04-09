<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MEWeb.Profile.Orders" %>

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
                                  var MovieTitleText = MovieTitle.Helpers.Span(c => c.MovieTitle);
                                }
                                var MovieGenre = MovieListRow.AddColumn("Price");
                                {
                                  var MovieGenreText = MovieGenre.Helpers.Span(c => c.Price);
                                }
                              }
                              var MoviPaginationColContainer = MovieColContentDiv.Helpers.DivC("pagination-container");
                              {
                              }
                            }
                            var MoviePaginationColContainer = MovieColContentDiv.Helpers.DivC("pagination-container");
                            {
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
          }
        }
      }
    }
  %>
  <script type="text/javascript">
    // Place page specific JavaScript here or in a JS file and include in the HeadContent section
    Singular.OnPageLoad(function () {
      $("#menuItem2").addClass('active');
      $("#menuItem2 > ul").addClass('in');
    });

    var ReadMore = function () {
      window.open('https://getbootstrap.com/docs/4.4/layout/grid/', '_blank');
    }

    var ReadMoreKnockoutJS = function () {
      window.open('https://knockoutjs.com/index.html', '_blank');
    }
  </script>
</asp:Content>
