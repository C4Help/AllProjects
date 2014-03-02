using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using C4H_Website.C4H_Service;
using C4H_Website.Managers;

namespace C4H_Website.Pages.SearchCharities
{
    public partial class CharityProfilePage : System.Web.UI.Page
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

            int userId = -1;
            string userIDStr = Request.QueryString["id"];
            int.TryParse(userIDStr, out userId);

            //Charity
            CharityProfile charity = DonorSearchManager.GetCharityProfile(userId);

            if (charity == null)
            {
                Response.Redirect("../../");
            }
            else
            {
                displayCharityFullName(charity.FullName);
                displayCharityRegNumber(charity.RegNumber);

                displayCharityCategory(charity.Category.Name, charity.Category.Description);
                displayCharityDesignation(charity.Designation.Description);

                displayCharityAddress(charity.Province, charity.City, charity.Address1, charity.Address2, charity.PostalCode);
                displayContactInforamtion(charity.Email, charity.Phone, charity.Website);

                displayCharityPrograms(charity.Programs);
                displayCharityCountries(charity.Countries);
            }
        }

        private void displayCharityFullName(string FullName)    
        {
            this.Charity_Name_Label.InnerText = FullName;
        }
        private void displayCharityRegNumber(string RegNumber)  
        {
            this.Charity_RegNumber_Label.InnerText = RegNumber;
        }

        private void displayCharityCategory(string Type, string Description)    
        {
            Charity_CategoryType_Label.InnerText = Type;
            Charity_CategoryDescription_Label.InnerText = Description;
        }
        private void displayCharityDesignation(string Description)              
        {
            Charity_Designation_Label.InnerText = Description;
        }

        private void displayCharityAddress(string Province, string City, string Address1, 
            string Address2, string PostalCode)                                             
        {
            Charity_Province_Label.InnerText = Province;
            Charity_City_Label.InnerText = City;
            Charity_Address1_Label.InnerText = Address1;
            Charity_Address2_Label.InnerText = Address2;
            Charity_PostalCode_Label.InnerText = PostalCode;
        }
        private void displayContactInforamtion(string Email, string Phone, string Website)  
        {
            Charity_Email_Label.InnerText = Email;
            Charity_Phone_Label.InnerText = Phone;
            Charity_Website_Label.InnerText = Website;
        }

        private void displayCharityPrograms(CharityProgram[] Programs)              
        {
            string HTML = "";

            if (Programs.Count() == 0)
                HTML = "<li><i class='fa fa-exclamation'></i> No available program</li>";
            else
            {
                foreach (CharityProgram program in Programs)
                    HTML += "<li><i class='fa fa-check'></i> " + program.Description + "</li>";
            }

            this.Charity_Program_List.InnerHtml = HTML;
        }
        private void displayCharityCountries(CharityActivityCountry[] Countries)    
        {
            string HTML = "";

            if (Countries.Count() == 0)
                HTML = "<li><i class='fa fa-exclamation'></i> No available program</li>";
            else
            {
                foreach (CharityActivityCountry country in Countries)
                    HTML += "<li><i class='fa fa-check'></i> " + country.Name + "</li>";
            }

            this.Charity_Country_List.InnerHtml = HTML;
        }
    }
}