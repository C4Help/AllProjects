<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="C4H_Website.ContactUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!-- BEGIN HEAD -->
<% Response.Write(C4H_Website.Managers.DesignManager.GenerateHeadHTML("Contact Us Page", "./")); %>
<!-- END HEAD -->

<!-- BEGIN BODY -->
<body>
    
    <!-- BEGIN HEADER -->
    <% Response.Write(C4H_Website.Managers.DesignManager.GenerateNavigationMenuHTML("./")); %>
    <!-- END HEADER -->

    <!-- BEGIN PAGE CONTAINER -->  
    <div class="page-container">
	
        <!-- BEGIN BREADCRUMBS -->   
        <div class="row breadcrumbs">
            <div class="container">
                <div class="col-md-4 col-sm-4">
                    <h1>Contact</h1>
                </div>
                <div class="col-md-8 col-sm-8">
                    <ul class="pull-right breadcrumb">
                        <li><a href="./">Home</a></li>
                        <li><a href="">Pages</a></li>
                        <li class="active">Contact</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- END BREADCRUMBS -->

		<!-- BEGIN GOOGLE MAP -->
		<div class="row">
			<div id="map" class="gmaps margin-bottom-40" style="height:400px;"></div>
		</div>
		<!-- END GOOGLE MAP -->

		<!-- BEGIN CONTAINER -->   
		<div class="container min-hight">
			<div class="row">
				<div class="col-md-9 col-sm-9">
					<h2>Contact Form</h2>
					<div class="space20"></div>
					<!-- BEGIN FORM-->
					<form action="#" class="horizontal-form margin-bottom-40" role="form">
						<div class="form-group">
							<label class="control-label">Name</label>
							<div class="col-lg-12">
								<input type="text" class="form-control" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label" >Email <span class="color-red">*</span></label>
							<div class="col-lg-12">
								<input type="text" class="form-control" >
							</div>
						</div>
						<div class="form-group">
							<label class="control-label" >Message</label>
							<div class="col-lg-12">
								<textarea class="form-control" rows="8"></textarea>
							</div>
						</div>
						<button type="submit" class="btn btn-default theme-btn"><i class="icon-ok"></i> Send</button>
						<button type="button" class="btn btn-default">Cancel</button>
					</form>
					<!-- END FORM-->                  
				</div>

				<div class="col-md-3 col-sm-3">
					<h2>Our Contacts</h2>
					<address>
						<strong>University of Calgary</strong><br>
						2500 University Dr. NW<br>
						Calgary, Alberta, Canada T2N 1N4<br>
						<abbr title="Phone">P:</abbr> (403) 401-2747
					</address>
					<address>
						<strong>Email</strong><br>
						<a href="mailto:zarour.omar@gmail.com">zarour.omar@gmail.com</a><br>
					</address>

					<div class="clearfix margin-bottom-30"></div>

					<h2>About Us</h2>
					<p>Team Members</p>
					<ul class="list-unstyled">
						<li><i class="fa fa-check"></i> Alper Aksac</li>
						<li><i class="fa fa-check"></i> Konstantinos Xylogiannopoulos</li>
						<li><i class="fa fa-check"></i> Omar Zarour </li>
						<li><i class="fa fa-check"></i> Omar Addam</li>
					</ul>                                
				</div>            
			</div>
		</div>
		<!-- END CONTAINER -->

	</div>
    <!-- END PAGE CONTAINER -->  

    <!-- START FOOTER -->
    <% Response.Write(C4H_Website.Managers.DesignManager.GenerateFooterHTML("./")); %>
    <!-- END FOOTER -->
</body>
<!-- END BODY -->
</html>