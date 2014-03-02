<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="C4H_Website.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html lang="en">

<script>

    function SearchButton_Click() {
        var query = document.getElementById("Search_TextBox").value;
        var province = document.getElementById("Location_Combobox").value;
        window.location.href = "./Pages/SearchCharities/?query=" + query + "&province=" + province;
    }

</script>

<!-- BEGIN HEAD -->
<% Response.Write(C4H_Website.Managers.DesignManager.GenerateHeadHTML("Home Page", "./")); %>
<!-- END HEAD -->

<!-- BEGIN BODY -->
<body>
    <!-- BEGIN HEADER -->
    <% Response.Write(C4H_Website.Managers.DesignManager.GenerateNavigationMenuHTML("./")); %>
    <!-- END HEADER -->

    <!-- BEGIN PAGE CONTAINER -->  
    <div class="page-container">
        <!-- BEGIN REVOLUTION SLIDER -->    
        <div class="fullwidthbanner-container slider-main">
            <div class="fullwidthabnner">
                <ul style="display:none;">            
                        <!-- THE FIRST SLIDE -->
                        <li data-transition="fade" data-slotamount="1" data-masterspeed="0" data-delay="0" data-thumb="template/assets/img/sliders/revolution/thumbs/thumb2.jpg">
                            <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                            <img src="template/assets/img/sliders/revolution/bg1.png" alt="">
                            
                            <div class="caption lfl slide_title slide_item_left"
                                 data-x="0"
                                 data-y="125"
                                 data-speed="400"
                                 data-start="1500"
                                 data-easing="easeOutExpo">
                                Connect<strong><font color="DarkRed">4</font></strong>Help
                            </div>
                            <div class="caption lfl slide_subtitle slide_item_left"
                                 data-x="0"
                                 data-y="200"
                                 data-speed="400"
                                 data-start="2000"
                                 data-easing="easeOutExpo">
                                Connect with what matters to you
                            </div>
                            <div class="caption lfb"
                                 data-x="640"
                                 data-y="-120"
                                 data-speed="700"
                                 data-start="1000"
                                 data-easing="easeOutExpo">
                                <img src="template/assets/img/sliders/revolution/moto.png" height="700" alt="Image 1">
                            </div>
                        </li>
                </ul>
                <div class="tp-bannertimer tp-bottom"></div>
            </div>
        </div>
        <!-- END REVOLUTION SLIDER -->

        <!-- BEGIN CONTAINER -->
        <div class="container">
            <div class="row service-box">
                <div class="col-md-6 col-sm-6">
                    <div class="form-group">
                        <label class="control-label col-md-6"><h4>Choose your location?</h4></label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-map-marker"></i>
                                </span>
								<!-- START LOCATION COMBOBOX -->
                                <% Response.Write(C4H_Website.Managers.DesignManager.GenerateProvinceCombobox()); %>
								<!-- END LOCATION COMBOBOX -->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6">
                    <div class="row search-form-default">
                        <div class="col-md-12">
                            <form class="form-inline" action="#">
                                <div class="input-group">
                                        <div class="input-cont">
                                            <input id="Search_TextBox" type="text" placeholder="Search..." class="form-control" />
                                        </div>
                                        <span class="input-group-btn">
                                            <button  type="button" class="btn green" onclick="SearchButton_Click()">
                                                Search &nbsp; <i class="m-icon-swapright m-icon-white"></i>
                                            </button>
                                        </span>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>       
            </div>
        </div>
        <!-- END PAGE CONTAINER -->

        <!-- BEGIN PAGE CONTENT-->
        <div class="row">
            <div class="col-md-12">
                
            </div>
            <!--end tabbable-->
        </div>
        <!-- END PAGE CONTENT-->

        <!-- BEGIN CONTAINER -->
                <div class="container">
                    <!-- BEGIN SERVICE BOX -->
                    <div class="row service-box">
                        <div class="col-md-4 col-sm-4">
                            <div class="service-box-heading">
                                <em><i class="fa fa-search blue"></i></em>
                                <span>Search</span>
                            </div>
                            <p>We allow users and charities to do  search in tens of thousands of Registered Canadian Charities records. </p>
                            <p>Our Search tool retreives the most suitable match based on the search keyword. </p>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <div class="service-box-heading">
                                <em><i class="fa fa-check red"></i></em>
                                <span>Match</span>
                            </div>
                            <p>Donors offer their skills and interests. We recommend them the best charities that match their combination of skills and interests.</p>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <div class="service-box-heading">
                                <em><i class="fa fa-compress green"></i></em>
                                <span>Connect</span>
                            </div>
                            <p>We give the Donor the opporunity to follow a charity and becomes one of its fans. Anytime, the charity can poke its army of followers to help build the comuunity.</p>
                        </div>
                    </div>
                    <!-- END SERVICE BOX -->
                    <div class="clearfix"></div>
                    <div class="clearfix"></div>
                    <!-- BEGIN TABS AND TESTIMONIALS -->
                    <div class="row mix-block">
                        <!-- TABS -->
                        <div class="col-md-7 tab-style-1 margin-bottom-20">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tab-1" data-toggle="tab">Your skills matter</a></li>
                                <li><a href="#tab-2" data-toggle="tab">Charities Inneed</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane row fade in active" id="tab-1">
                                    <div class="col-md-3">
                                        <a href="template/assets/img/photos/skills.jpg" class="fancybox-button" title="Image Title" data-rel="fancybox-button">
                                            <img class="img-responsive" src="template/assets/img/photos/skills.jpg" alt="" />
                                        </a>
                                    </div>
                                    <div class="col-md-9">
                                        <p class="margin-bottom-10">Donors, donation is not always about money. You can still help your comunity by sharing your experience. Your skills are valued by many charities.</p>
                                        <p><a class="more" href="#">Sign up <i class="icon-angle-right"></i></a> now at connect4help to find charities that value your skills the most.</p>
                                    </div>
                                </div>
                                <div class="tab-pane row fade" id="tab-2">
                                    <div class="col-md-9">
                                        <p class="margin-bottom-10">Charities, </p>
                                        <p>Contact us now to activate your account and start recruiting your army of donors.</p>
                                    </div>
                                    <div class="col-md-3">
                                        <a href="template/assets/img/photos/volunteers.jpg" class="fancybox-button" title="Image Title" data-rel="fancybox-button">
                                            <img class="img-responsive" src="template/assets/img/photos/volunteers.jpg" alt="" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END TABS -->
                        <!-- TESTIMONIALS -->
                        <div class="col-md-5 testimonials-v1">
                            <div id="myCarousel" class="carousel slide">
                                <!-- Carousel items -->
                                <div class="carousel-inner">
                                    <div class="active item">
                                        <span class="testimonials-slide">Connect4Help is an easy solution to solve everyday short-term needs of charities and individuals needing specific help. Episodic volunteerism is on the rise, especially with the Millennial generation, Being able to promote unique volunteer opportunities to individuals through mobile devices bridges the gap between those agencies that need support and the people that have the time and talent to fill those needs.  Thank you for developing this much needed solution!</span>
                                        <div class="carousel-info">
                                            <img class="pull-left" src="template/assets/img/people/gena.jpg" alt="" />
                                            <div class="pull-left">
                                                <span class="testimonials-name">Gena Rotstein</span>
                                                <span class="testimonials-post">CEO, Dexterity Ventures Inc. <br /><a href="http://www.place2give.ca/">Place2Give.ca</a></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Carousel nav -->
                                <a class="left-btn" href="#myCarousel" data-slide="prev"></a>
                                <a class="right-btn" href="#myCarousel" data-slide="next"></a>
                            </div>
                        </div>
                        <!-- END TESTIMONIALS -->
                    </div>
                    <!-- END TABS AND TESTIMONIALS -->

                </div>
                <!-- END PAGE CONTAINER -->

                <!-- START FOOTER -->
                <% Response.Write(C4H_Website.Managers.DesignManager.GenerateFooterHTML("./")); %>
                <!-- END FOOTER -->
</body>
<!-- END BODY -->
</html>
