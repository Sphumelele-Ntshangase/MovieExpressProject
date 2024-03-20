<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Categories.aspx.cs" Inherits="MEWeb.Examples.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

  <script type="text/javascript" src="../Scripts/JSLINQ.js"></script>
  <link href="../Theme/Singular/METTCustomCss/home.css" rel="stylesheet" />
  <link href="../Theme/Singular/METTCustomCss/assessment.css" rel="stylesheet" />
  <link href="../Theme/Singular/css/badges.css" rel="stylesheet" />
  <link href="../Theme/Singular/css/assessment.css" rel="stylesheet" />
  <script type="text/javascript" src="../Scripts/accesscheck.js"></script>

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
              var HomeContainerTab = AssessmentsTab.AddTab("Movies");
              {
                var Row = HomeContainerTab.Helpers.DivC("row margin0");
                {
                  var RowCol = Row.Helpers.DivC("col-md-12");
                  {

                  }
                }
              }
            }
          }
        }
      }
    }

  %>
</asp:Content>
