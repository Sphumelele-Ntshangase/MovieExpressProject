<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="MEWeb.Movies.Movie" %>

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
                  var ColContentDiv = RowContentDiv.Helpers.DivC("col-md-12");
                  {

                    var VideoContainer = ColContentDiv.Helpers.HTMLTag("video controls");
                    {

                      VideoContainer.Helpers.HTML("<source src='../Media/Videos/Silver Fox Intro.mp4' type='video/mp4'>");
                      //var VideoSource = VideoContainer.Helpers.HTMLTag("source", true);
                      //{
                      //  VideoSource.AddBinding(Singular.Web.KnockoutBindingString.attr, "{ type : 'video/mp4' }");
                      //  VideoSource.AddBinding(Singular.Web.KnockoutBindingString.src, "../Media/Videos/Sample.mp4");
                      ////  //PageRowColRight.Helpers.HTML("<source src='../Videos/01 2021 Creating a basic Aspx Page from a MasterPage in Visual Studio.mp4' type='video/mp4'>");
                      //}
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


  </script>
</asp:Content>
