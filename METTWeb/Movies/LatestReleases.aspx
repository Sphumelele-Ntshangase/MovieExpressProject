﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LatestReleases.aspx.cs" Inherits="MEWeb.Movies.LatestReleases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- Add page specific styles and JavaScript classes below -->
  <link href="../Theme/Singular/Custom/home.css" rel="stylesheet" />
  <link href="../Theme/Singular/Custom/customstyles.css" rel="stylesheet" />
  <style>
    .movie-border {
      border-radius: 5px;
      border: 2px solid #DEDEDE;
      padding: 15px;
      margin: 5px;
    }

    div.item {
      vertical-align: top;
      display: inline-block;
      text-align: center;
      padding-bottom: 25px;
    }

    .caption {
      display: block;
      padding-bottom: 5px;
    }
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
  <!-- Placeholder not used in this example -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <%
    using (var h = this.Helpers)
    {
      var MainHDiv = h.DivC("row pad-top-10");
      {
        var PanelContainer = MainHDiv.Helpers.DivC("col-md-12 p-n-lr");
        {
          var HomeContainer = PanelContainer.Helpers.DivC("tabs-container");
          {
            var AssessmentsTab = HomeContainer.Helpers.TabControl();
            {
              AssessmentsTab.Style.ClearBoth();
              AssessmentsTab.AddClass("nav nav-tabs");
              var HomeContainerTab = AssessmentsTab.AddTab("Movies");
              {
                var Row = HomeContainerTab.Helpers.DivC("row margin0");
                {
                  var RowColLeft = Row.Helpers.DivC("col-md-9");
                  {
                    var AnotherCardDiv = RowColLeft.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Latest Releases");
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
                          var ColContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                          {
                            var MoviesWatchedDiv = ColContentDiv.Helpers.ForEach<MELib.Movies.Movie>(c => c.MovieList);
                            {

                              // Using Knockout Binding
                              // <img width="16px" height="16px" data-bind="attr:{src: imagePath}" />
                              MoviesWatchedDiv.Helpers.HTML("<div class='item'>");
                              MoviesWatchedDiv.Helpers.HTML("<img data-bind=\"attr:{src: $data.MovieImageURL()} \" class='movie-border'/>");
                              MoviesWatchedDiv.Helpers.HTML("<b><span data-bind=\"text: $data.MovieTitle() \"  class='caption'></span></b>");
                              // MoviesWatchedDiv.Helpers.HTML("<span data-bind=\"text: $data.MovieGenreID() \"  class='caption'></span>");
                              MoviesWatchedDiv.Helpers.HTML("<span data-bind=\"text: $data.ReleaseDate() \"  class='caption'></span>");
                            }
                            var WatchBtn = MoviesWatchedDiv.Helpers.Button("Watch Now", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                            {
                              WatchBtn.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Play Trailer");
                              WatchBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "RentMovie($data)");
                              WatchBtn.AddClass("btn btn-primary btn-outline");
                            }
                            MoviesWatchedDiv.Helpers.HTML("</div>");
                          }

                          var ColContentDiv1 = RowContentDiv.Helpers.DivC("col-md-12");
                          {
                            //ColContentDiv.AddBinding(Singular.Web.KnockoutBindingString.visible, c => ViewModel.FoundUserMoviesInd == true);
                            // Place Content Here
                            //ColContentDiv.Helpers.HTML("<br><p>[ You have not watched any movies, follow the link below to browse available movies. ]</p>");

                            // Browse Movies Button
                            var BroweseBtn = ColContentDiv1.Helpers.Button("Find Movie", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                            {
                              BroweseBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FindMovies()");
                              BroweseBtn.AddClass("btn btn-primary btn-outline pull-right");
                            }
                          }
                        }
                      }
                    }
                  }

                  var RowColRight = Row.Helpers.DivC("col-md-3");
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
                        var RowContentDiv = ContentDiv.Helpers.DivC("row");
                        {
                          //var ColContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                          //{
                          //  var MovieTitleContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                          //  {
                          //    MovieTitleContentDiv.Helpers.LabelFor(c => c.ReleaseFromDate);
                          //    var MovieTitleEditor = MovieTitleContentDiv.Helpers.EditorFor(c => c.ReleaseFromDate);
                          //    MovieTitleEditor.AddClass("form-control marginBottom20 filterBox");
                          //    //MovieTitleEditor.AddBinding(Singular.Web.KnockoutBindingString.DateAndTimeEditor, "ReleaseFromDate");
                          //  }
                          //  var FilterBtn = MovieTitleContentDiv.Helpers.Button("Apply Filter", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          //  {
                          //    FilterBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterByReleaseDate($data)");
                          //    FilterBtn.AddClass("btn btn-primary btn-outline pull-right");
                          //  }

                          //}
                          var MovieGenreContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                          {
                            MovieGenreContentDiv.Helpers.LabelFor(c => ViewModel.MovieGenreID);
                            var ReleaseFromDateEditor = MovieGenreContentDiv.Helpers.EditorFor(c => ViewModel.MovieGenreID);
                            ReleaseFromDateEditor.AddClass("form-control marginBottom20 ");

                            var FilterBtn = MovieGenreContentDiv.Helpers.Button("Apply Filter", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                            {
                              FilterBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterMovies($data)");
                              FilterBtn.AddClass("btn btn-primary btn-outline pull-right");
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
    }
  %>
  <script type="text/javascript">
    // Place page specific JavaScript here or in a JS file and include in the HeadContent section
    Singular.OnPageLoad(function () {
      $("#menuItem1").addClass('active');
      $("#menuItem1 > ul").addClass('in');
    });

    var RentMovie = function (obj) {
      ViewModel.CallServerMethod('RentMovie', { MovieID: obj.MovieID(), ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          window.location = result.Data;
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }
      })
    }

    var FilterMovies = function (obj) {

      ViewModel.CallServerMethod('FilterMovies', { MovieGenreID: obj.MovieGenreID(), ShowLoadingBar: true }, function (result) {
        if (result.Success) {
          //MEHelpers.Notification("Movies filtered successfully.", 'center', 'info', 1000);
          ViewModel.MovieList.Set(result.Data);
        }
        else {
          MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
        }
      })
    };

    var FindMovies = function () {
      window.location = '../Movies/Movies.aspx';
    }

  </script>
</asp:Content>
