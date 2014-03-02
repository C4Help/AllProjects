<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharityProfilePage.aspx.cs" Inherits="C4H_Website.Pages.SearchCharities.CharityProfilePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<!-- BEGIN HEAD -->
<% Response.Write(C4H_Website.Managers.DesignManager.GenerateHeadHTML("Charities Profile Page", "../../")); %>
<!-- END HEAD -->

<!-- BEGIN BODY -->
<body>
    <!-- BEGIN HEADER -->
    <% Response.Write(C4H_Website.Managers.DesignManager.GenerateNavigationMenuHTML("../../")); %>
    <!-- END HEADER -->
  
    <!-- BEGIN BREADCRUMBS -->   
        <div class="row breadcrumbs margin-bottom-40">
            <div class="container">
                <div class="col-md-4 col-sm-4">
                    <h1>Charity Profile</h1>
                </div>
                <div class="col-md-8 col-sm-8">
                    <ul class="pull-right breadcrumb">
                        <li><a href="../../">Home</a></li>
                        <li><a href="">Pages</a></li>
                        <li><a runat="server" id="charity_search_link" href="javascript:history.back()">Charities Search</a></li>
                        <li class="active">Charity Profile</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- END BREADCRUMBS -->

		<!-- BEGIN CONTAINER -->   
		<div class="container  margin-bottom-40">
			<div class="row">
				<div class="col-md-8 col-sm-8">

                    <!-- BEGIN INFO BLOCK -->               
                    <h2><span runat="server" id="Charity_Name_Label">Name</span></h2>
                    <h4>Reg Number: <span runat="server" id="Charity_RegNumber_Label">reg number</span></h4>

                    <br />
                    <table width = "100%">
                        <tr>
                            <td>
                                <h4>Category</h4>
                                <strong>Type: </strong> <span runat="server" id="Charity_CategoryType_Label">name</span><br />
                                <strong>Description: </strong> <span runat="server" id="Charity_CategoryDescription_Label">description</span>
                            </td>
                            <td style="padding-left:130px">
                                <h4>Designation</h4>
                                <strong>Description: </strong> <span runat="server" id="Charity_Designation_Label">description</span>
                            </td>
                        </tr>
                    </table>
                    <!-- END LISTS -->
                    <!-- END INFO BLOCK -->
                    
                    <table width="100%">
                        <tr>
                            <td width="50%" valign="top" style="padding-right:30px">
                                <h2>Our Programs</h2>
                                <div class="row front-lists-v1">
                                    <div class="col-md-12">
                                        <ul class="list-unstyled" runat="server" id="Charity_Program_List">
                                            <li><i class="fa fa-check"></i> Officia deserunt molliti</li>
                                            <li><i class="fa fa-check"></i> Consectetur adipiscing </li>
                                            <li><i class="fa fa-check"></i> Deserunt fpicia</li>
                                        </ul>
                                    </div>
                                </div>
                            </td>
                            <td width="50%" valign="top" style="padding-left:30px">
                                <h2>Countries</h2>
                                <div class="row front-lists-v1">
                                    <div class="col-md-12">
                                        <ul class="list-unstyled" runat="server" id="Charity_Country_List">
                                            <li><i class="fa fa-check"></i> Officia deserunt molliti</li>
                                            <li><i class="fa fa-check"></i> Consectetur adipiscing </li>
                                            <li><i class="fa fa-check"></i> Deserunt fpicia</li>
                                        </ul>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>

				</div>

				<div class="col-md-4 col-sm-4 sidebar" style="margin-top:60px">
                    <h2 class="no-top-space">Address</h2>
                    <table>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Province</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_Province_Label">Province</span></td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>City</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_City_Label">City</span></td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Address 1</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_Address1_Label">Address 1</span></td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Address 2</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_Address2_Label">Address 2</span></td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Postal Code</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_PostalCode_Label">Postal Code</span></td>
                        </tr>
                    </table>

                    <div class="space10"></div>
                    
                    <h2 class="no-top-space">Contact Information</h2>
                    <table>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Email</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_Email_Label">Email</span></td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Phone</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_Phone_Label">Phone</span></td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Website</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px"><span runat="server" id="Charity_Website_Label">Website</span></td>
                        </tr>
                    </table>
                    <div class="space10"></div>

                    <h2 class="no-top-space">Followers</h2>
                    <table>
                        <tr>
                            <td align="right" style="padding-bottom:10px"><strong>Count</strong></td>
                            <td style="padding-left:20px;padding-bottom:10px">0</td>
                        </tr>
                    </table>
                    <div class="space10"></div>
                          
				</div>            
			</div>
		</div>
		<!-- END CONTAINER -->

	</div>
    <!-- END PAGE CONTAINER --> 

    <!-- START FOOTER -->
    <% Response.Write(C4H_Website.Managers.DesignManager.GenerateFooterHTML("../../")); %>
    <!-- END FOOTER -->
</body>
<!-- END BODY -->
</html>


