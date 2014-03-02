using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C4H_Website.Managers
{
    public static class DesignManager
    {

        public static string GenerateHeadHTML(string PageName, string Root)     
        {
            string HeadHTML = "";
            HeadHTML += "<head>";
                HeadHTML += "<meta charset=\"utf-8\" />";
                HeadHTML += "<title>C4H | " + PageName + "</title>";
                HeadHTML += "<meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\" />";

               //BEGIN GLOBAL MANDATORY STYLES         
                HeadHTML += "<link href=\"" + Root + "template/assets/plugins/font-awesome/css/font-awesome.min.css\" rel=\"stylesheet\" type=\"text/css\"/>";
                HeadHTML += "<link href=\"" + Root + "template/assets/plugins/bootstrap/css/bootstrap.min.css\" rel=\"stylesheet\" type=\"text/css\"/>";
               //END GLOBAL MANDATORY STYLES
   
               //BEGIN PAGE LEVEL PLUGIN STYLES --> 
                HeadHTML += "<link href=\"" + Root + "template/assets/plugins/fancybox/source/jquery.fancybox.css\" rel=\"stylesheet\" /> ";
                HeadHTML += "<link rel=\"stylesheet\" href=\"template/assets/plugins/revolution_slider/css/rs-style.css\" media=\"screen\">";
                HeadHTML += "<link rel=\"stylesheet\" href=\"template/assets/plugins/revolution_slider/rs-plugin/css/settings.css\" media=\"screen\"> ";
                HeadHTML += "<link href=\"" + Root + "template/assets/plugins/bxslider/jquery.bxslider.css\" rel=\"stylesheet\" /> ";      
               //END PAGE LEVEL PLUGIN STYLES -->

               //BEGIN THEME STYLES --> 
                HeadHTML += "<link href=\"" + Root + "template/assets/css/style-metronic.css\" rel=\"stylesheet\" type=\"text/css\"/>";
                HeadHTML += "<link href=\"" + Root + "template/assets/css/style.css\" rel=\"stylesheet\" type=\"text/css\"/>";
                HeadHTML += "<link href=\"" + Root + "template/assets/css/themes/blue.css\" rel=\"stylesheet\" type=\"text/css\" id=\"style_color\"/>";
                HeadHTML += "<link href=\"" + Root + "template/assets/css/style-responsive.css\" rel=\"stylesheet\" type=\"text/css\"/>";
                HeadHTML += "<link href=\"" + Root + "template/assets/css/custom.css\" rel=\"stylesheet\" type=\"text/css\"/>";
               //END THEME STYLES -->

                HeadHTML += "<link rel=\"shortcut icon\" href=\"" + Root + "template/assets/img/favicon.ico\" />";
            HeadHTML += "</head>";

            return HeadHTML;
        }
        public static string GenerateNavigationMenuHTML(string Root)            
        {
            string HTML = "";

            HTML = "<div class=\"header navbar navbar-default navbar-static-top\">";
		        HTML += "<div class=\"container\">";
			        HTML += "<div class=\"navbar-header\">";
				        //<!-- BEGIN RESPONSIVE MENU TOGGLER -->
				        HTML += "<button class=\"navbar-toggle btn navbar-btn\" data-toggle=\"collapse\" data-target=\".navbar-collapse\">";
					        HTML += "<span class=\"icon-bar\"></span>";
					        HTML += "<span class=\"icon-bar\"></span>";
					        HTML += "<span class=\"icon-bar\"></span>";
                        HTML += "</button>";
				        //<!-- END RESPONSIVE MENU TOGGLER -->
				        //<!-- BEGIN LOGO (you can use logo image instead of text)-->
                        HTML += "<a class=\"navbar-brand\" href=\"" + Root + "\">";
					        HTML += "<img src=\"" + Root + "template/assets/img/logo.png\" id=\"logoimg\" alt=\"\" width=\"100\">";
				        HTML += "</a>";
				        //<!-- END LOGO -->
			        HTML += "</div>";
		
			        //<!-- BEGIN TOP NAVIGATION MENU -->
			        HTML += "<div class=\"navbar-collapse collapse\">";
				        HTML += "<ul class=\"nav navbar-nav\">";
					        HTML += "<li><a href=\"" + Root + "\">Home</a></li>";
                            HTML += "<li><a href=\"" + Root + "Pages/SearchCharities/\">Charities</a></li>";

                            HTML += "<li><a href=\"" + Root + "ContactUs.aspx\">Contact</a></li>";
                    
                    
				        HTML += "</ul>";                
			        HTML += "</div>";
			        //<!-- BEGIN TOP NAVIGATION MENU -->
		        HTML += "</div>";
            HTML += "</div>";

            return HTML;
        }
        public static string GenerateFooterHTML(string Root)                    
        {
            string HTML = "";

            //<!-- BEGIN FOOTER -->
            HTML += "<div class=\"footer\">";
                HTML += "<div class=\"container\">";
                    HTML += "<div class=\"row\">";
                        HTML += "<div class=\"col-md-4 col-sm-4 space-mobile\">";
                            //<!-- BEGIN ABOUT -->
                            HTML += "<h2>About us</h2>";
                            HTML += "<p class=\"margin-bottom-30\">We are a group of students from University of Calgary. We are eager to use our skills in computer science to help our surrounding community.</p>";
                            HTML += "<p class=\"margin-bottom-30\">Connect4Help is just our first step to building a social network that uses the open data provided by the government of Canada.</p>";
                            
                            //<!-- END ABOUT -->
                            HTML += "<h2>Our team</h2>";
                            //<!-- BEGIN BLOG PHOTOS STREAM -->
                            HTML += "<div class=\"blog-photo-stream margin-bottom-30\">";
                                HTML += "<ul class=\"list-unstyled\">";
                                    HTML += "<li><a href=\"#\"><img src=\"" + Root + "template/assets/img/people/omarz.jpg\" alt=\"\"></a></li>";
                                    HTML += "<li><a href=\"#\"><img src=\"" + Root + "template/assets/img/people/omara.jpg\" alt=\"\"></a></li>";
                                    HTML += "<li><a href=\"#\"><img src=\"" + Root + "template/assets/img/people/alpera.jpg\" alt=\"\"></a></li>";
                                    HTML += "<li><a href=\"#\"><img src=\"" + Root + "template/assets/img/people/kostasx.jpg\" alt=\"\"></a></li>";
                                HTML += "</ul>";
                            HTML += "</div>";
                            //<!-- END BLOG PHOTOS STREAM -->
                        HTML += "</div>";
                        HTML += "<div class=\"col-md-4 col-sm-4\">";
                        HTML += "</div>";
                        HTML += "<div class=\"col-md-4 col-sm-4\">";
                            //<!-- BEGIN CONTACTS -->
                            HTML += "<h2>Contact Us</h2>";
                            HTML += "<address class=\"margin-bottom-40\">";
                                HTML += "University of Calgary <br />";
                                HTML += "2500 University Dr. NW <br />";
                                HTML += "Calgary, Alberta, Canada T2N 1N4 <br />";
                                HTML += "P: (403) 401-2747 <br />";
                                HTML += "Email: <a href=\"mailto:zarour.omar@gmail.com\">zarour.omar@gmail.com</a>";
                            HTML += "</address>";
                            //<!-- END CONTACTS -->
                            //<!-- BEGIN SUBSCRIBE -->
                            HTML += "<h2>Monthly Newsletter</h2>";
                            HTML += "<p>Subscribe to our newsletter and stay up to date with the latest news and deals!</p>";
                            HTML += "<form action=\"#\" class=\"form-subscribe\">";
                                HTML += "<div class=\"input-group input-large\">";
                                    HTML += "<input class=\"form-control\" type=\"text\">";
                                    HTML += "<span class=\"input-group-btn\">";
                                        HTML += "<button class=\"btn theme-btn\" type=\"button\">SUBSCRIBE</button>";
                                    HTML += "</span>";
                                HTML += "</div>";
                            HTML += "</form>";
                            //<!-- END SUBSCRIBE -->
                        HTML += "</div>";
                    HTML += "</div>";
                HTML += "</div>";
            HTML += "</div>";
            //<!-- END FOOTER -->
            //<!-- BEGIN COPYRIGHT -->
            HTML += "<div class=\"copyright\">";
                HTML += "<div class=\"container\">";
                    HTML += "<div class=\"row\">";
                        HTML += "<div class=\"col-md-8 col-sm-8\">";
                            HTML += "<p>";
                                HTML += "<span class=\"margin-right-10\">2014 - Connect4Help</span>";
                            HTML += "</p>";
                        HTML += "</div>";
                        HTML += "<div class=\"col-md-4 col-sm-4\">";
                            HTML += "<ul class=\"social-footer\">";
                            HTML += "</ul>";
                        HTML += "</div>";
                    HTML += "</div>";
                HTML += "</div>";
            HTML += "</div>";
            //<!-- END COPYRIGHT -->

            //<!-- Load javascripts at bottom, this will reduce page load time -->
            //<!-- BEGIN CORE PLUGINS(REQUIRED FOR ALL PAGES) -->
            HTML += "<!--[if lt IE 9]>";
            HTML += "<script src=\"" + Root + "template/assets/plugins/respond.min.js\"></script>";
            HTML += "<![endif]-->";
            HTML += "<script src=\"" + Root + "template/assets/plugins/jquery-1.10.2.min.js\" type=\"text/javascript\"></script>";
            HTML += "<script src=\"" + Root + "template/assets/plugins/jquery-migrate-1.2.1.min.js\" type=\"text/javascript\"></script>";
            HTML += "<script src=\"" + Root + "template/assets/plugins/bootstrap/js/bootstrap.min.js\" type=\"text/javascript\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/back-to-top.js\"></script>";
            //<!-- END CORE PLUGINS -->
            //<!-- BEGIN PAGE LEVEL JAVASCRIPTS(REQUIRED ONLY FOR CURRENT PAGE) -->
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/fancybox/source/jquery.fancybox.pack.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/revolution_slider/rs-plugin/js/jquery.themepunch.plugins.min.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/revolution_slider/rs-plugin/js/jquery.themepunch.revolution.min.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/bxslider/jquery.bxslider.min.js\"></script>";
            HTML += "<script src=\"" + Root + "template/assets/scripts/app.js\"></script>";
            HTML += "<script src=\"" + Root + "template/assets/scripts/index.js\"></script>";
            HTML += "<script src=\"" + Root + "template/assets/scripts/custom/components-dropdowns.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/bootstrap-select/bootstrap-select.min.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/select2/select2.min.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/jquery-multi-select/js/jquery.multi-select.js\"></script>";
            //HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/plugins/gmaps/gmaps.js\"></script>";
            HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/scripts/contact-us.js\"></script>";
            //HTML += "<script type=\"text/javascript\" src=\"" + Root + "template/assets/scripts/components-dropdowns.js\"></script>";
            HTML += "<script src='https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false'></script>";

            HTML += "<script type=\"text/javascript\">";
                HTML += "jQuery(document).ready(function () {";
                    HTML += "App.init();";
                    HTML += "App.initBxSlider();";
                    HTML += "Index.initRevolutionSlider();";
                    //HTML += "ComponentsDropdowns.init();";
                    HTML += "ContactUs.init();";
                    // for the "Scroll Back to Top"
                    HTML += "document.getElementById('topcontrol').childNodes[0].src = '" + Root + "/template/assets/img/up.png';";
                HTML += "});";
            HTML += "</script>";
            //<!-- END PAGE LEVEL JAVASCRIPTS -->

            return HTML;
        }

        public static string GenerateProvinceCombobox()                 
        {
            string HTML = "";

            Dictionary<string, string> provinces = new Dictionary<string, string>();
            provinces.Add("0", "Anywhere");
            provinces.Add("AB", "Alberta");
            provinces.Add("BC", "British Columbia");
            provinces.Add("MB", "Manitoba");
            provinces.Add("NB", "New Brunswick");
            provinces.Add("NL", "Newfoundland and Labrador");
            provinces.Add("NT", "Northwest Territories");
            provinces.Add("NS", "Nova Scotia");
            provinces.Add("NU", "Nunavut");
            provinces.Add("ON", "Ontario");
            provinces.Add("PE", "Prince Edward Island");
            provinces.Add("QC", "Quebec");
            provinces.Add("SK", "Saskatchewan");
            provinces.Add("YT", "Yukon");


            HTML = "<select id=\"Location_Combobox\" class=\"form-control select2me\" data-placeholder=\"Select...\">";
            foreach (string Key in provinces.Keys)
                HTML += "<option value=\"" + Key + "\">" + provinces[Key] + "</option>";
            HTML += "</select>";

            return HTML;
        }
        public static string GenerateProvinceCombobox(string Province)  
        {
            string HTML = "";

            Dictionary<string, string> provinces = new Dictionary<string, string>();
            provinces.Add("0", "Anywhere");
            provinces.Add("AB", "Alberta");
            provinces.Add("BC", "British Columbia");
            provinces.Add("MB", "Manitoba");
            provinces.Add("NB", "New Brunswick");
            provinces.Add("NL", "Newfoundland and Labrador");
            provinces.Add("NT", "Northwest Territories");
            provinces.Add("NS", "Nova Scotia");
            provinces.Add("NU", "Nunavut");
            provinces.Add("ON", "Ontario");
            provinces.Add("PE", "Prince Edward Island");
            provinces.Add("QC", "Quebec");
            provinces.Add("SK", "Saskatchewan");
            provinces.Add("YT", "Yukon");


            HTML = "<select id=\"Location_Combobox\" class=\"form-control select2me\" data-placeholder=\"Select...\">";
            foreach (string Key in provinces.Keys)
                HTML += "<option " + (Province.ToLower() == Key.ToLower() ? "SELECTED" : "") + " value=\"" + Key + "\">" + provinces[Key] + "</option>";
            HTML += "</select>";

            return HTML;
        }

    }
}