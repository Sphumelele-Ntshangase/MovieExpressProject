<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MEWeb.Profile.Profile" %>

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
              var ContainerTab = PageTab.AddTab("Profile Information");
              {
                var RowContentDiv = ContainerTab.Helpers.DivC("row");
                {

                  #region Left Column / Data
                  var LeftColRight = RowContentDiv.Helpers.DivC("col-md-4");
                  {
                    var CardDiv1 = LeftColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                    {
                      var CardTitleDiv = CardDiv1.Helpers.DivC("ibox-title");
                      {
                        CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                        CardTitleDiv.Helpers.HTML().Heading5("Profile Picture");
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
                      //picture icon
                      var ContentDiv = CardDiv1.Helpers.DivC("ibox-content");
                      {
                        var EditPicture = ContentDiv.Helpers.DivC("row");
                        {
                          EditPicture.Helpers.HTML("<div class='circlecenter'><div class='circlecontaineruser circlecenter'><span class='fas fa-user fa-lg fa-fw' style='font-size:64px;'></span></div></div>");
                          var ChangePicBtn = EditPicture.Helpers.Button("Change Picture", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                          {
                            // Change Picture Button
                            ChangePicBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "ChangePic()");
                            ChangePicBtn.AddClass("btn btn-primary btn-outline pull-right");
                          }
                        }


                      }
                    }
                    #endregion

                    #region Middle Column / Data
                    var MidColRight = RowContentDiv.Helpers.DivC("col-md-4");
                    {

                      var CardDiv2 = MidColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                      {
                        var CardTitleDiv = CardDiv2.Helpers.DivC("ibox-title");
                        {
                          CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                          CardTitleDiv.Helpers.HTML().Heading5("User Details");

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
                        var ContentDiv = CardDiv2.Helpers.DivC("ibox-content");
                        {
                          var ChangeDetails = ContentDiv.Helpers.DivC("row");
                          {
                            var MidColContentDiv = ChangeDetails.Helpers.DivC("col-md-12");
                            {
                              //showing details
                              MidColContentDiv.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Name: " + c.UserAccount.UserName);

                              var dialog = ChangeDetails.Helpers.Dialog(c => c.EditingUser != null, c => (c.EditingUser != null) ? "Edit Profile Details" : "Edit User", "CancelEdit");
                              {
                                dialog.Style.Width = "600";
                                //dialog.Style.PaddingAll("10");

                                var dialogContent = dialog.Helpers.With<MELib.Security.User>(c => c.EditingUser);
                                {

                                  var loginName = dialogContent.Helpers.DivC("row");
                                  {
                                    var loginNameLabel = loginName.Helpers.LabelFor(c => c.LoginName);
                                    {
                                      loginNameLabel.AddBinding(Singular.Web.KnockoutBindingString.enable, c => c.IsNew);
                                      loginNameLabel.AddBinding(Singular.Web.KnockoutBindingString.visible, c => !c.IsNew);
                                      loginNameLabel.AddClass("control-label");
                                    }

                                    var loginNameEditor = loginName.Helpers.EditorFor(c => c.LoginName);
                                    {
                                      loginNameEditor.AddBinding(Singular.Web.KnockoutBindingString.enable, c => c.IsNew);
                                      loginNameEditor.AddBinding(Singular.Web.KnockoutBindingString.visible, c => !c.IsNew);
                                      loginNameEditor.AddClass("form-control");
                                    }
                                  }

                                  var userName = dialogContent.Helpers.DivC("row");
                                  {
                                    var userNameLabel = userName.Helpers.LabelFor(c => c.FirstName);
                                    {
                                      userNameLabel.AddClass("control-label");
                                    }
                                    var userNameEditor = userName.Helpers.EditorFor(c => c.FirstName);
                                    {
                                      userNameEditor.AddClass("form-control");
                                    }
                                  }

                                  var Surname = dialogContent.Helpers.DivC("row");
                                  {
                                    var SurnameLabel = Surname.Helpers.LabelFor(c => c.Surname);
                                    {
                                      SurnameLabel.AddClass("control-label");
                                    }
                                    var SurnameEditor = Surname.Helpers.EditorFor(c => c.Surname);
                                    {
                                      SurnameEditor.AddClass("form-control");
                                    }
                                  }

                                  var emailAddress = dialogContent.Helpers.DivC("row m-b");
                                  {
                                    var emailAddressLabel = Surname.Helpers.LabelFor(c => c.EmailAddress);
                                    {
                                      emailAddressLabel.AddClass("control-label");
                                    }
                                    var emailAddressEditor = Surname.Helpers.EditorFor(c => c.EmailAddress);
                                    {
                                      emailAddressEditor.AddClass("form-control");
                                    }
                                  }                                  
                                }

                                dialog.AddConfirmationButtons("Save", "SaveUser()", "Cancel");
                              }
                            }

                            var EditDetailsButton = MidColContentDiv.Helpers.DivC("row");
                            {
                              if (Singular.Security.Security.HasAccess("Security.Manage Users"))
                              {
                              // Change Details Button
                              var ChangeDetailsBtn = ChangeDetails.Helpers.Button("Edit Details", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                              ChangeDetailsBtn.AddClass("btn btn-primary btn-outline pull-right");
                              ChangeDetailsBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "EditUser($data)");
                              }
                            }
                          }
                        }

                      }
                    }
                    #endregion

                    #region Right Column / Filters
                    var RightColRight = RowContentDiv.Helpers.DivC("col-md-4");
                    {

                      var CardDiv3 = RightColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                      {
                        var CardTitleDiv = CardDiv3.Helpers.DivC("ibox-title");
                        {
                          CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                          CardTitleDiv.Helpers.HTML().Heading5("Account Information");
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
                        var ContentDiv = CardDiv3.Helpers.DivC("ibox-content");
                        {
                          var AddingFunds = ContentDiv.Helpers.DivC("row");
                          {
                            var LeftColContentDiv = AddingFunds.Helpers.DivC("col-md-12 marginBottom20");
                            {
                              // Place Content Here
                              LeftColContentDiv.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Your Current Balance is: R " + c.UserAccount.Balance);
                            }
                          }
                          var AddingFundsButton = ContentDiv.Helpers.DivC("row");
                          {
                            var FundAccountBtn = AddingFundsButton.Helpers.Button("Deposit Funds", Singular.Web.ButtonMainStyle.NoStyle, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                            {
                              // Fund Account Button
                              FundAccountBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FundAccount()");
                              FundAccountBtn.AddClass("btn btn-primary btn-outline pull-right");
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
    }
  %>
  <script type="text/javascript">
    // Place page specific JavaScript here or in a JS file and include in the HeadContent section
    Singular.OnPageLoad(function () {
      $("#menuItem1").addClass('active');
      $("#menuItem1 > ul").addClass('in');
    });

    var ChangePic = function () {
      // have a save button
      // also has to call CancelEdit()
    }

    var EditUser = function (ROUser) {

      if (ROUser) {
        //Edit
        ViewModel.CallServerMethod('GetUser', { UserID: ROUser.UserID(), ShowLoadingBar: true }, function (result) {
          if (result.Success) {
            ViewModel.EditingUser.Set(result.Data);
          }
        });

      } else {
        //New
        ViewModel.EditingUser.Set();
        ViewModel.EditingUser().Password('12345678');//This will be set to random on server side.
      }

    }

    var SaveUser = function () {

      if (ViewModel.EditingUser() != null) {
        ViewModel.EditingUser().LoginName(ViewModel.EditingUser().EmailAddress());
        var jsonUser = ViewModel.EditingUser.Serialise();

        ViewModel.CallServerMethod('SaveUser', { User: jsonUser, ShowLoadingBar: true }, function (result) {
          if (result.Success) {
            ViewModel.UserListPageManager().Refresh();
            ViewModel.EditingUser.Clear();

            METTHelpers.Notification("User has been saved successfully", 'center', 'success', 5000);
          } else {

            METTHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
          }
        });
      };
    }

    var CancelEdit = function () {
      ViewModel.EditingUser.Clear();
    }

    var FundAccount = function () {
      window.location = '../Profile/DepositFunds.aspx';
    }

  </script>
</asp:Content>
