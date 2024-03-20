<%@ Page Title="Popcorn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataTables.aspx.cs" Inherits="MEWeb.Examples.DataTables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/JSLINQ.js"></script>
    <link href="../Theme/Singular/Custom/home.css" rel="stylesheet" />
    <link href="../Theme/Singular/Custom/customstyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
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
                            var HomeContainerTab = AssessmentsTab.AddTab("Basic Examples");
                            {
                                var Row = HomeContainerTab.Helpers.DivC("row margin0");
                                {
                                    var RowCol = Row.Helpers.DivC("col-md-12");
                                    {
                                        RowCol.Helpers.HTML().Heading2("Data Tables");
                                        RowCol.Helpers.HTMLTag("p").HTML = "An example below.";

                                        var MovieList = RowCol.Helpers.BootstrapTableFor<MELib.Movies.Movie>((c) => c.MovieList, false, false, "");
                                        {
                                            var MovieListRow = MovieList.FirstRow;
                                            {
                                                var MovieTitle = MovieListRow.AddColumn("Title");
                                                {
                                                    var MovieTitleText = MovieTitle.Helpers.Span(c => c.MovieTitle);
                                                }
                                                var MovieGenre = MovieListRow.AddColumn("Genre");
                                                {
                                                    var MovieGenreText = MovieGenre.Helpers.Span(c => c.MovieGenreID);
                                                }
                                                var MovieDescription = MovieListRow.AddColumn("Description");
                                                {
                                                    var MovieDescriptionText = MovieDescription.Helpers.Span(c => c.MovieDescription);
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
        Singular.OnPageLoad(function () {
            $("#menuItem4").addClass("active");
            $("#menuItem4 > ul").addClass("in");
        });
    </script>

</asp:Content>
