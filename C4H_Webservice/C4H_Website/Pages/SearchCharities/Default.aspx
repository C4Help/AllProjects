<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="C4H_Website.Pages.SearchCharities.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html lang="en">

<script>

    function SearchButton_Click() {
        var query = document.getElementById("Search_TextBox").value;
        var province = document.getElementById("Location_Combobox").value;
        var loose = document.getElementById("loose_search_radio").checked;
        window.location.href = "./?query=" + query + "&province=" + province + "&loose=" + loose;
    }

    function ChangePage_Click() {
        var query = document.getElementById("Search_TextBox").value;
        var province = document.getElementById("Location_Combobox").value;
        var loose = document.getElementById("loose_search_radio").checked;
        var page = document.getElementById("page_combobox").value;
        window.location.href = "./?query=" + query + "&province=" + province + "&loose=" + loose + "&page=" + page;
    }

    function NextPage_Click() {
        var query = document.getElementById("Search_TextBox").value;
        var province = document.getElementById("Location_Combobox").value;
        var loose = document.getElementById("loose_search_radio").checked;
        var page = document.getElementById("page_combobox").value;
        page = parseInt(page) + 1;
        window.location.href = "./?query=" + query + "&province=" + province + "&loose=" + loose + "&page=" + page;
    }

    function PreviousPage_Click() {
        var query = document.getElementById("Search_TextBox").value;
        var province = document.getElementById("Location_Combobox").value;
        var loose = document.getElementById("loose_search_radio").checked;
        var page = document.getElementById("page_combobox").value;
        page = parseInt(page) - 1;
        window.location.href = "./?query=" + query + "&province=" + province + "&loose=" + loose + "&page=" + page;
    }

</script>

<!-- BEGIN HEAD -->
<% Response.Write(C4H_Website.Managers.DesignManager.GenerateHeadHTML("Charities Page", "../../")); %>
<!-- END HEAD -->


<link rel="stylesheet" media="all" href="../../template/assets/map/jquery-jvectormap-1.2.2.css"/>
<script src="../../template/assets/map/jquery-1.8.2.js"></script>
<script src="../../template/assets/map/jquery-jvectormap-1.2.2.min.js"></script>
<script src="../../template/assets/map/jquery-jvectormap-world-mill-en.js"></script>
<script src="../../template/assets/map/jquery-jvectormap-ca-lcc-en.js"></script>
<script type="text/javascript" src="https://www.google.com/jsapi"></script>

<!-- BEGIN BODY -->
<body onload="drawChart()">
    <!-- BEGIN HEADER -->
    <% Response.Write(C4H_Website.Managers.DesignManager.GenerateNavigationMenuHTML("../../")); %>
    <!-- END HEADER -->
    
    <!-- BEGIN BREADCRUMBS -->   
        <div class="row breadcrumbs margin-bottom-40">
            <div class="container">
                <div class="col-md-4 col-sm-4">
                    <h1>Charities</h1>
                </div>
                <div class="col-md-8 col-sm-8">
                    <ul class="pull-right breadcrumb">
                        <li><a href="../../">Home</a></li>
                        <li><a href="">Pages</a></li>
                        <li class="active">Charities</li>
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
                   <form class="form-inline" action="#">
                        <div class="col-md-3">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-map-marker"></i>
                                </span>
								<!-- START LOCATION COMBOBOX -->
                                <div runat="server" id="location_div">
                                </div>
								<!-- END LOCATION COMBOBOX -->
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="input-group">
                                    <div class="input-cont">
                                        <input id="Search_TextBox"  runat="server" type="text" placeholder="Search..." class="form-control" />
                                        <br />
                                        <font color="grey">You can search by: names, locations, and interests</font>
                                    </div>
                                    <span class="input-group-btn" >
                                        <button  type="button" class="btn green" style="margin-top:-18px" onclick="SearchButton_Click()">
                                            Search &nbsp; <i class="m-icon-swapright m-icon-white"></i>
                                        </button>
                                    </span>
                            </div>
                        </div>
                        
                    </form>
                    <!-- END INFO BLOCK -->
                    <div id="accordion1" class="panel-group" runat="server" >
                     </div>       
				</div>

				<div class="col-md-4 col-sm-4 sidebar">
                    <h2 class="no-top-space">Advanced Options</h2>
                    <address>
                        <input type="radio" runat="server" name="search_radio" id="loose_search_radio" /> <strong>Loose Search</strong> [Default]<br>
                         It presents the results that satisfy any of your search words
                    </address>
                    <address>
                        <input type="radio" runat="server" name="search_radio" id="strong_search_radio" /><strong>Strong Search</strong><br>
                         All of your search words should match the results
                    </address>
                    <div class="space10"></div>
                          
                    <h2 class="no-top-space">Search Summary</h2>
                    <br />
                    <div id="mapChart" style="width: 350px; height: 300px;"></div>
                    <center><strong>Geographical distribution of charities</strong></center>

                    <div style="padding-left:-40px;" id="designationChart" style="width: 900px; height:400px"></div>
                    <center><strong>Charities designations</strong></center>
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

