using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using C4H_Website.Managers;
using C4H_Website.C4H_Service;
using System.Text;

namespace C4H_Website.Pages.SearchCharities
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)    
        {
            string query = Request.QueryString["query"];
            if (query == null)
                query = Request.QueryString["Search_TextBox"];
            query = query == null ? "" : query;
            string province = Request.QueryString["province"];
            if (province == null)
                province = "0";
            bool looseSearch = true;
            string looseSearchStr = Request.QueryString["loose"];
            if (looseSearchStr != null && looseSearchStr.ToLower() == "false")
                looseSearch = false;

            int rowsPerPage = 50;
            int currentPage = 0;
            string currentPageStr = Request.QueryString["page"];
            if (!int.TryParse(currentPageStr, out currentPage))
                currentPage = 0;

            loose_search_radio.Checked = looseSearch;
            strong_search_radio.Checked = !looseSearch;

            this.Search_TextBox.Value = query;
            this.location_div.InnerHtml = C4H_Website.Managers.DesignManager.GenerateProvinceCombobox(province);

            int totalRows = 0;
            Dictionary<string, int> geoStatistics;
            Dictionary<CharityDesignation, int> designationStatistics;
            List<CharityProfile> profiles = DonorSearchManager.SearchCharitiesByQuery(query, province, looseSearch, currentPage, rowsPerPage, out totalRows, out geoStatistics, out designationStatistics);

            accordion1.InnerHtml = "<br/></br></br>" + GenerateMapStatiscalHTML(geoStatistics)
                + "<h2>Results</h2>"
                + (profiles == null ? "" : "<h4>Showing you " + (currentPage * rowsPerPage + 1) + "-" + (currentPage * rowsPerPage + profiles.Count()) + " out of " + totalRows + "</h4>")
                + GenereatePageHTMLNavigation(currentPage, rowsPerPage, totalRows) + " " + GenerateDesignationStatisticsHTML(designationStatistics)
                + "<br/>" + GenerateHTMLResult(profiles, query, province, looseSearch, currentPage);

        }

        private string GenerateDesignationStatisticsHTML(Dictionary<CharityDesignation, int> Designations)  
        {
            if (Designations == null)
                return "";

            string HTML = @"
                <script type=""text/javascript"">
                    function drawDesignationChat()
                    {
                            google.load(""visualization"", ""1"", {packages:[""corechart""]});
                            google.setOnLoadCallback(drawChart);
                            function drawChart() {
                            var data = google.visualization.arrayToDataTable([
                                ['Designation', 'Number'],
                                ";

                            for (int i = 0; i < Designations.Keys.Count(); i++)
                            {
                                HTML += "['" + Designations.Keys.ToArray()[i].Description + "', " + Designations[Designations.Keys.ToArray()[i]] + "]";

                                if (i != Designations.Keys.Count() - 1)
                                    HTML += ",";
                            }

                            HTML+= @"]);

                            var options = {
                                pieHole: 0.4,
                            };

                            var chart = new google.visualization.PieChart(document.getElementById('designationChart'));
                            chart.draw(data, options);
                            }
                    }
                    drawDesignationChat();
                </script>
            ";
            
            return HTML;
        }
        private string GenerateMapStatiscalHTML(Dictionary<string, int> Provinces)                          
        {
            if (Provinces == null)
                return "";

            string HTML = @"
            <script>
            

            function drawChart()
	        {
		        var provs = [";

                for (int i = 0; i < Provinces.Keys.Count(); i++)
                {
                    HTML += "\"" + Provinces.Keys.ToArray()[i] + "\"";
                    if (i != Provinces.Keys.Count() - 1)
                        HTML += ",";
                }

                HTML += @"];
		
	          var cityAreaData = [";

                for (int i = 0; i < Provinces.Keys.Count(); i++)
                {
                    HTML += Provinces[Provinces.Keys.ToArray()[i]];
                    if (i != Provinces.Keys.Count() - 1)
                        HTML += ",";
                }

              HTML += @"];
		
		        var markers = new Array();
		        //var regions = new Array();
		        var names = new Array();

                var regions = {
                      ""CA-AB"": ""#34373F"",
                      ""CA-BC"": ""#34373F"",
                      ""CA-MB"": ""#34373F"",
                      ""CA-NB"": ""#34373F"",
                      ""CA-NL"": ""#34373F"",
                      ""CA-NT"": ""#34373F"",
                      ""CA-NS"": ""#34373F"",
                      ""CA-NU"": ""#34373F"",
                      ""CA-ON"": ""#34373F"",
                      ""CA-PE"": ""#34373F"",
                      ""CA-QC"": ""#34373F"",
                      ""CA-SK"": ""#34373F"",
                      ""CA-YT"": ""#34373F""};
		
		        for (var i=0;i<provs.length;i++)
		        { 
			        if (provs[i]==""AB"")
			        {
				        markers[i] = {latLng: [55.169514,-114.509178], name: 'Alberta'};
				        names[i] = ""CA-AB"";
				        regions['CA-AB'] = ""#34A12E"";
			        } else if (provs[i]==""BC"")
			        {
				        markers[i] = {latLng: [54.561863,-125.104057], name: 'Britisih Columbia'};
				        names[i] = ""CA-BC"";
				        regions['CA-BC'] = ""#0A2165"";
			        } else if (provs[i]==""MB"")
			        {
				        markers[i] = {latLng: [55.083370,-97.179237], name: 'Manitoba'};
				        names[i] = ""CA-MB"";
				        regions['CA-MB'] = ""#821789"";
			        } else if (provs[i]==""NB"")
			        {
				        markers[i] = {latLng: [46.634178,-66.075150], name: 'New Brunswick'};
				        names[i] = ""CA-NB"";
				        regions['CA-NB'] = ""#0A2165"";
			        } else if (provs[i]==""NL"")
			        {
				        markers[i] = {latLng: [52.625362,-59.685577], name: 'Newfoundland and Labrador'};
				        names[i] = ""CA-NL"";
				        regions['CA-NL'] = ""#34B4D1"";
			        } else if (provs[i]==""NT"")
			        {
				        markers[i] = {latLng: [78.695404,-110.531197], name: 'Northwest Territories'};
				        names[i] = ""CA-NT"";
				        regions['CA-NT'] = ""#FFBF00"";
			        } else if (provs[i]==""NS"")
			        {
				        markers[i] = {latLng: [45.598148,-62.367664], name: 'Nova Scotia'};
				        names[i] = ""CA-NS"";
				        regions['CA-NS'] = ""#FF850D"";
			        } else if (provs[i]==""NU"")
			        {
				        markers[i] = {latLng: [69.875023,-88.037949], name: 'Nunavut'};
				        names[i] = ""CA-NU"";
				        regions['CA-NU'] = ""#FF850D"";
			        } else if (provs[i]==""ON"")
			        {
				        markers[i] = {latLng: [50.251640,-85.794281], name: 'Ontario'};
				        names[i] = ""CA-ON"";
				        regions['CA-ON'] = ""#E60A0A"";
			        } else if (provs[i]==""PE"")
			        {
				        markers[i] = {latLng: [46.619251,-63.135151], name: 'Prince Edward Island'};
				        names[i] = ""CA-PE"";
				        regions['CA-PE'] = ""#34B4D1"";
			        } else if (provs[i]==""QC"")
			        {
				        markers[i] = {latLng: [53.010578,-70.998291], name: 'Quebec'};
				        names[i] = ""CA-QC"";
				        regions['CA-QC'] = ""#FFBF0A"";
			        } else if (provs[i]==""SK"")
			        {
				        markers[i] = {latLng: [54.418579,-105.888847], name: 'Saskatchewan'};
				        names[i] = ""CA-SK"";
				        regions['CA-SK'] = ""#34B4D1"";
			        } else if (provs[i]==""YT"")
			        {
				        markers[i] = {latLng: [63.704056,-135.546463], name: 'Yukon Territory'};
				        names[i] = ""CA-YT"";
				        regions['CA-YT'] = ""#E60002"";
			        }
		        }

                var map = new jvm.WorldMap({
                    container: $('#mapChart'),
	                map: 'ca_lcc_en',
                    backgroundColor: '#FAFAFA',
                    regionsSelectable: true,
                    markersSelectable: true,
                    markers: markers,
                    markerStyle: {
                        initial: {
                        fill: '#4DAC26'
                        },
                        selected: {
                        fill: '#CA0020'
                        }
                    },
                    regionStyle: {
                        initial: {
                        fill: '#B8E186'
                        },
                        selected: {
                        fill: '#F4A582'
                        }
                    },
                    series: {
                        markers: [{
                        attribute: 'fill',
                            scale: ['#FEE5D9', '#A50F15'],
                        values: cityAreaData,
			                normalizeFunction: 'polynomial'
                        },
	                    {
                            attribute: 'r',
                            scale: [5, 20],
                            values: cityAreaData

                        }],
	                    regions: [{
		                    attribute: 'fill',
                        values: regions

                        }]
                    },
	                onRegionLabelShow: function(event, label, code){
                        label.html(
                            ''+label.html()+''+
                            '</br>Charity Number: '+cityAreaData[names.indexOf(code)]);
                        }
                });
	        }
            </script>
            ";



            return HTML;
        }
        private string GenereatePageHTMLNavigation(int CurrentPage, int RowsPerPage, int TotalRows)         
        {
            string HTML = "";

            int totalPages = (int)Math.Ceiling((double)TotalRows / (double)RowsPerPage);

            HTML += "<div style='clear:both;float:right' >";
                        
            HTML += "<select id='page_combobox' onChange='ChangePage_Click()'>";
            for (int i = 0; i < totalPages || i == 0; i++)
            {
                HTML += "<option " + (i == CurrentPage ? "SELECTED" : "") + " value='" + i + "'>Page " + (i+1) + "</option>";
            }
            HTML += "</select>&nbsp;&nbsp;&nbsp;&nbsp;";


            if (CurrentPage > 0)
                HTML += "<a href='javascript:PreviousPage_Click()' class='btn red' ><i class='fa fa-chevron-left'></i></font></a>&nbsp;";
            if (CurrentPage < totalPages - 1)
                HTML += "<a href='javascript:NextPage_Click()' class='btn red' ><i class='fa fa-chevron-right'></i></font></a>";
            
            HTML += "</div><br/>";

            return HTML;
        }
        private string GenerateHTMLResult(List<CharityProfile> Profiles, 
            string Query, string Province, bool LooseSearch, int CurrentPage)                               
        {
            if (Profiles == null)
                return "Error";
            if (Profiles.Count() == 0)
                return "No record found";

            StringBuilder HTML = new StringBuilder();

            for (int i = 0; i < Profiles.Count(); i++)
            {
                Panel p = new Panel();
                
                HTML.Append("<div class=\"panel panel-" + (i % 2 == 0 ? "default" : "danger") + "\">");
                    HTML.Append("<div class=\"panel-heading\">");
                        HTML.Append("<h4 class=\"panel-title\">");
                            HTML.Append("<a class=\"accordion-toggle\" data-toggle=\"collapse\" data-parent=\"#accordion" + i + "\" href=\"#accordion1_" + i + "\">");
                            HTML.Append(Profiles[i].FullName);
                            HTML.Append("</a>");
                        HTML.Append("</h4>");
                    HTML.Append("</div>");
                    HTML.Append("<div id=\"accordion1_" + i + "\" class=\"panel-collapse collapse\">");
                        HTML.Append("<div class=\"panel-body\">");
                            HTML.Append("<table width='100%' border='0'>");
                                HTML.Append("<tr>");
                                    HTML.Append("<td style='padding-left:30px'>");
                                        HTML.Append("<h4>Address</h4>");
                                        HTML.Append("<ul>");
                                            HTML.Append("<li> <b>Province:</b> " + Profiles[i].Province + "</li>");
                                            HTML.Append("<li> <b>City:</b> " + Profiles[i].City + "</li>");
                                            HTML.Append("<li> <b>Address1:</b> " + Profiles[i].Address1 + "</li>");
                                            HTML.Append("<li> <b>Address2:</b> " + Profiles[i].Address2 + "</li>");
                                            HTML.Append("<li> <b>Postal Code:</b> " + Profiles[i].PostalCode + "</li>");
                                        HTML.Append("</ul>");
                                        HTML.Append("<br/>");
                                        HTML.Append("<h4>Contact Information</h4>");
                                        HTML.Append("<ul>");
                                            HTML.Append("<li> <b>Email:</b> " + Profiles[i].Email + "</li>");
                                            HTML.Append("<li> <b>Phone:</b> " + Profiles[i].Phone + "</li>");
                                            HTML.Append("<li> <b>Website:</b> " + Profiles[i].Website + "</li>");
                                        HTML.Append("</ul>");
                                    HTML.Append("</td>");
                                    HTML.Append("<td width='50%' valign='top'>");
                                        HTML.Append("<h4>General</h4>");
                                        HTML.Append("<ul>");
                                            HTML.Append("<li> <b>Registration number:</b> " + Profiles[i].RegNumber + "</li>");
                                            HTML.Append("<li> <b>Category:</b> " + Profiles[i].Category.Name + "</li>");
                                            HTML.Append("<li> <b>Category description:</b> " + Profiles[i].Category.Description + "</li>");
                                            HTML.Append("<li> <b>Designation:</b> " + Profiles[i].Designation.Description + "</li>");
                                            HTML.Append("</ul><br/><br/><br/>");
                                        
                                        HTML.Append("<span class=\"input-group-btn\" style='padding-left:50px'>");
                                        HTML.Append("<button  type=\"button\" class=\"btn green\" onclick=\"location.href='CharityProfilePage.aspx?id=" + Profiles[i].UserID + "&query=" + Query + "&province=" + Province + "&loose=" + LooseSearch + "&page=" + CurrentPage + "'\">");
                                                HTML.Append("View Details &nbsp; <i class=\"m-icon-swapright m-icon-white\"></i>");
                                            HTML.Append("</button>");
                                        HTML.Append("</span>");

                                    HTML.Append("</td>");
                                HTML.Append("</tr>");
                            HTML.Append("</table>");
                        HTML.Append("</div>");
                    HTML.Append("</div>");
                HTML.Append("</div>");
            }

            return HTML.ToString();
        }
    }
}