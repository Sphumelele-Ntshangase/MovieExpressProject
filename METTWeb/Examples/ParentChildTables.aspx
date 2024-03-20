<%@ Page Title="Popcorn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParentChildTables.aspx.cs" Inherits="MEWeb.Examples.ParentChildTables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- Add page specific styles and JavaScript classes below -->
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
                    RowCol.Helpers.HTML().Heading2("Parent Child Tables");
                    RowCol.Helpers.HTMLTag("p").HTML = "An example below.";

                    #region Categories

                    var CategoriesDiv = RowCol.Helpers.Div();
                    {
                      var Categoies = CategoriesDiv.Helpers.BootstrapTableFor<MELib.Categories.Category>((c) => c.CategoriesList, false, false, "", true);
                      var CategoriesFirstRow = Categoies.FirstRow;
                      {
                        var CategoryName = CategoriesFirstRow.AddReadOnlyColumn(c => c.CategoryName);
                        {
                          CategoryName.HeaderText = "Threat Category";
                        }
                      }
                      var SubCategories = Categoies.AddChildTable<MELib.Categories.SubCategory>((c) => c.SubCategoryList, false, false, "");
                      {
                        var SubCategoriesFirstRow = SubCategories.FirstRow;
                        {
                          var SubCategoryName = SubCategoriesFirstRow.AddReadOnlyColumn(c => c.SubCategoryName);
                          {
                          }
                          var SubCategoryDescription = SubCategoriesFirstRow.AddReadOnlyColumn(c => c.SubCategoryDescription);
                          {
                            SubCategoryDescription.HeaderText = "Description";
                          }
                        }
                        var EditCol = SubCategoriesFirstRow.AddColumn("Action");
                        {
                          // Add Buttons Here
                        }
                      }
                    }
                  }
                }

                //var ThreatsDivPagedDiv = RowCol.Helpers.Div();
                //{

                //  var Threats = ThreatsDivPagedDiv.Helpers.BootstrapTableFor<MELib.ThreatCategories.ThreatCategory>((c) => c.ThreatsList, false, false, "", true);

                //  var ThreatsTableFirstRow = Threats.FirstRow;
                //  {
                //    var ThreatName = ThreatsTableFirstRow.AddReadOnlyColumn(c => c.ThreatCategoryName);
                //    {
                //      ThreatName.HeaderText = "Threat Category";
                //    }
                //  }
                //  var ThreatsItems = Threats.AddChildTable<MELib.ThreatSubCategories.ThreatSubCategory>((c) => c.ThreatSubCategoryList, false, false, "");
                //  {
                //    var ThreatsItemsTableFirstRow = ThreatsItems.FirstRow;
                //    {
                //      var ThreatsItemName = ThreatsItemsTableFirstRow.AddReadOnlyColumn(c => c.ThreatSubCategoryName);
                //      {
                //        ThreatsItemName.HeaderText = "Threat";
                //      }
                //      var ThreatsItemDescription = ThreatsItemsTableFirstRow.AddReadOnlyColumn(c => c.ThreatSubCategoryDescription);
                //      {
                //        ThreatsItemDescription.HeaderText = "Description";
                //      }
                //      var EditCol = ThreatsItemsTableFirstRow.AddColumn("Action");
                //      {
                //        var AddBtn = EditCol.Helpers.Button("Do Something", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                //        {
                //          AddBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "JavaScriptFunction($data)");
                //          AddBtn.AddClass("btn btn-outline btn-info btn");
                //        }
                //      }
                //    }
                //  }
                //}
              }
              #endregion
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
