using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using C4H_DataInsertion.Structure;
using C4H_DataInsertion.Managers;

namespace C4H_DataInsertion
{
    public partial class MainForm : Form
    {
        public MainForm()   
        {
            InitializeComponent();
        }

        #region Charities

        //#################
        //# File Browsers #
        //#################
        private void identification_file_button_Click(object sender, EventArgs e)   
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = this.identification_file_textbox.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.identification_file_textbox.Text = dialog.FileName;
        }
        private void category_file_button_Click(object sender, EventArgs e)         
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = this.category_file_textbox.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.category_file_textbox.Text = dialog.FileName;
        }
        private void designation_file_button_Click(object sender, EventArgs e)      
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = this.designation_file_textbox.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.designation_file_textbox.Text = dialog.FileName;
        }
        private void programs_file_button_Click(object sender, EventArgs e)         
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = this.programs_file_textbox.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.programs_file_textbox.Text = dialog.FileName;
        }
        private void countries_file_button_Click(object sender, EventArgs e)        
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = this.countries_file_textbox.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.countries_file_textbox.Text = dialog.FileName;
        }

        //################
        //# Files Import #
        //################

        //Designation
        Dictionary<string, string> designationOrigionalTable;
        Dictionary<string, int> designationConvertedTable;
        //Category
        Dictionary<int, CharityType> charityTypesOrigionalTable;
        Dictionary<int, int> charityTypesConvertedTable;
        //Countries
        Dictionary<string, List<string>> countriesTable;
        //Programs
        Dictionary<string, List<string>> programsTable;

        //Charities
        List<string> charitiesDistinctRegNumbers;
        List<Charity> charities;
        int charitiesErros;

        private void charities_data_import_button_Click(object sender, EventArgs e) 
        {
            this.Cursor = Cursors.WaitCursor;
            if (!this.loadCharitiesDesignationFiles(this.designation_file_textbox.Text))
            {
                this.Cursor = Cursors.Default;
                return;
            }
            if (!this.loadCharitiesCategoryFiles(this.category_file_textbox.Text))
            {
                this.Cursor = Cursors.Default;
                return;
            }
            if (!this.loadCharitiesCountriesFiles(this.countries_file_textbox.Text))
            {
                this.Cursor = Cursors.Default;
                return;
            }
            if (!this.loadCharitiesProgramsFiles(this.programs_file_textbox.Text))
            {
                this.Cursor = Cursors.Default;
                return;
            }

            if (!this.loadCharitiesIdentificationFile(this.identification_file_textbox.Text))
            {
                this.Cursor = Cursors.Default;
                return;
            }

            foreach (Charity charity in charities)
            {
                string regNumber = charity.RegNumber;

                if (countriesTable.ContainsKey(regNumber))
                    charity.CharityCountries.AddRange(countriesTable[regNumber]);

                if (programsTable.ContainsKey(regNumber))
                    charity.CharityPrograms.AddRange(programsTable[regNumber]);
            }


            int countriesCount = 0;
            foreach (string country in countriesTable.Keys)
                countriesCount += countriesTable[country].Count();
            int programsCount = 0;
            foreach (string program in programsTable.Keys)
                programsCount += programsTable[program].Count();

            result_label.Text = "Result:\n\n"
                + "\tDesignation Records: " + designationOrigionalTable.Count() + "\n"
                + "\tCategory Records: " + charityTypesOrigionalTable.Count() + "\n\n"

                + "\tCountries Charities Records: " + countriesTable.Keys.Count() + "\n"
                + "\tCountries Records: " + countriesCount + "\n\n"

                + "\tProgram Charities Records: " + programsTable.Keys.Count() + "\n"
                + "\tProgram Records: " + programsCount + "\n\n"

                + "\t Charities Distinct RegNum: " + charitiesDistinctRegNumbers.Count() + "\n"
                + "\t Charities Errors: " + charitiesErros + "\n"
                +"\t Charities: " + charities.Count();


            this.Cursor = Cursors.Default;
        }

        private bool loadCharitiesIdentificationFile(string FileName)   
        {
            charities = new List<Charity>();
            charitiesDistinctRegNumbers = new List<string>();
            charitiesErros = 0;

            try
            {
                FileStream file = new FileStream(FileName, FileMode.Open);
                StreamReader reader = new StreamReader(file);

                if (!reader.EndOfStream)
                    reader.ReadLine();

                int counter = 0;
                while (!reader.EndOfStream)
                {
                    counter++;
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length == 0)
                        continue;

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Replace("***", ",").Trim();

                    string RegNum = values[0];
                    int CategoryID = int.Parse(values[1]);
                    string DesignationID = values[2];
                    string FullName = values[4];
                    string Address1 = values[5];
                    string Address2 = values[6];
                    string City = values[7];
                    string Province = values[8];
                    string PostalCode = values[9];
                    string Country = values[10].Trim();
                    string Phone = values[12];
                    string Email = values[13];
                    string Website = values[14];

                    if (Country.ToLower() != "ca")
                    {
                        charitiesErros++;
                        continue;
                    }

                    if (!charitiesDistinctRegNumbers.Contains(RegNum))
                        charitiesDistinctRegNumbers.Add(RegNum);

                    if (!charityTypesConvertedTable.ContainsKey(CategoryID))
                    {
                        charitiesErros++;
                        continue;
                    }
                    if (!designationConvertedTable.ContainsKey(DesignationID))
                    {
                        charitiesErros++;
                        continue;
                    }

                    Charity charity = new Charity(RegNum, FullName, City, Province, PostalCode, Address1, Address2, Phone, Website, Email, charityTypesConvertedTable[CategoryID], designationConvertedTable[DesignationID]);
                    charities.Add(charity);
                }

                file.Close();
                reader.Close();

                return true;
            }
            catch 
            {
                MessageBox.Show("Charities Error");
                return false;
            }
        }
        private bool loadCharitiesCategoryFiles(string FileName)        
        {
            charityTypesOrigionalTable = new Dictionary<int, CharityType>();
            charityTypesConvertedTable = new Dictionary<int, int>();

            try
            {
                FileStream file = new FileStream(FileName, FileMode.Open);
                StreamReader reader = new StreamReader(file);

                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Replace("***", ",").Trim();

                    if (values.Length == 0)
                        continue;

                    int key = int.Parse(values[0]);
                    CharityType value = new CharityType(values[1], values[3]);

                    if (charityTypesOrigionalTable.ContainsKey(key))
                        continue;

                    charityTypesOrigionalTable.Add(key, value);
                    charityTypesConvertedTable.Add(key, charityTypesConvertedTable.Keys.Count() + 1);
                }

                file.Close();
                reader.Close();

                return true;
            }
            catch
            {
                MessageBox.Show("Categories Error");
                return false;
            }
        }
        private bool loadCharitiesDesignationFiles(string FileName)     
        {
            designationOrigionalTable = new Dictionary<string, string>();
            designationConvertedTable = new Dictionary<string, int>();

            try
            {
                FileStream file = new FileStream(FileName, FileMode.Open);
                StreamReader reader = new StreamReader(file);

                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length == 0)
                        continue;

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Replace("***", ",").Trim();

                    string key = values[0];
                    string value = values[1];

                    if (designationOrigionalTable.ContainsKey(key))
                        continue;

                    designationOrigionalTable.Add(key, value);
                    designationConvertedTable.Add(key, designationConvertedTable.Keys.Count() + 1);
                }

                file.Close();
                reader.Close();

                return true;
            }
            catch 
            { 
                MessageBox.Show("Designation Error"); 
                return false; 
            }
        }
        private bool loadCharitiesProgramsFiles(string FileName)        
        {
            programsTable = new Dictionary<string, List<string>>();

            try
            {
                FileStream file = new FileStream(FileName, FileMode.Open);
                StreamReader reader = new StreamReader(file);

                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length == 0)
                        continue;

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Replace("***", ",").Trim();

                    string key = values[0];
                    string value = values[3];

                    string[] cleanedValues = value.Split(new string[] { "    " }, StringSplitOptions.None);
                    value = "";
                    for (int i = 0; i < cleanedValues.Length; i++)
                    {
                        if (cleanedValues[i].Length == 0)
                            continue;

                        if (value.Length != 0)
                            value += "\n";
                        value += cleanedValues[i].Trim();
                    }

                    if (programsTable.ContainsKey(key))
                    {
                        if (programsTable[key].Contains(value))
                            continue;
                        programsTable[key].Add(value);
                    }
                    else
                        programsTable.Add(key, new List<string> { value });
                }

                file.Close();
                reader.Close();


                return true;
            }
            catch
            {
                MessageBox.Show("Programs Error");
                return false;
            }
        }
        private bool loadCharitiesCountriesFiles(string FileName)       
        {
            countriesTable = new Dictionary<string, List<string>>();

            try
            {
                FileStream file = new FileStream(FileName, FileMode.Open);
                StreamReader reader = new StreamReader(file);

                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length == 0)
                        continue;

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Replace("***", ",").Trim();

                    string key = values[0];
                    string value = values[4];

                    if (countriesTable.ContainsKey(key))
                    {
                        if (countriesTable[key].Contains(value))
                            continue;
                        countriesTable[key].Add(value);
                    }
                    else
                        countriesTable.Add(key, new List<string> { value });
                }

                file.Close();
                reader.Close();


                return true;
            }
            catch
            {
                MessageBox.Show("Countries Error");
                return false;
            }
        }


        //###############
        //# Data Export #
        //###############

        private void charities_database_export_button_Click(object sender, EventArgs e) 
        {
            try
            {
                foreach (string designationID in designationConvertedTable.Keys)
                    CharityManager.addDesignation(designationConvertedTable[designationID], designationOrigionalTable[designationID]);

                foreach (int typeID in charityTypesOrigionalTable.Keys)
                    CharityManager.addCharityCategory(charityTypesConvertedTable[typeID], charityTypesOrigionalTable[typeID].CharityTypeName, charityTypesOrigionalTable[typeID].CharityTypeDescription);


                int errors = 0;

                this.charities_database_export_progressbar.Maximum = charities.Count();
                this.charities_database_export_progressbar.Value = 0;

                this.charities_database_export_label.Text = "Progress: " + this.charities_database_export_progressbar.Value + "/" + this.charities_database_export_progressbar.Maximum 
                    + "\nErrors: " + errors.ToString();

                foreach (Charity charity in charities)
                {
                    bool valid = CharityManager.AddCharity(charity);

                    if (!valid)
                        errors++;

                    this.charities_database_export_progressbar.Value++;

                    this.charities_database_export_label.Text = "Progress: " + this.charities_database_export_progressbar.Value + "/" + this.charities_database_export_progressbar.Maximum
                        + "\nErrors: " + errors.ToString();

                    if (this.charities_database_export_progressbar.Value % 100 == 0)
                        Application.DoEvents();
                }

            }
            catch { MessageBox.Show("Error"); }

            Application.DoEvents();
        }

        #endregion

        #region Services

        //################
        //# File Browser #
        //################
        private void services_file_button_Click(object sender, EventArgs e) 
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = this.services_file_textbox.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.services_file_textbox.Text = dialog.FileName;
        }

        //################
        //# Files Import #
        //################
        Dictionary<string, List<string>> services;

        private void services_import_button_Click(object sender, EventArgs e)   
        {
            services = new Dictionary<string, List<string>>();

            try
            {
                FileStream file = new FileStream(this.services_file_textbox.Text, FileMode.Open);
                StreamReader reader = new StreamReader(file);

                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length == 0)
                        continue;

                    for (int i = 0; i < values.Length; i++)
                        values[i] = values[i].Replace("***", ",").Trim();

                    string key = values[0];
                    string value = values[1];

                    if (!services.ContainsKey(key))
                        services.Add(key, new List<string>());
                    services[key].Add(value);
                }

                file.Close();
                reader.Close();

                int counter = 0;
                foreach (string serviceType in services.Keys)
                    counter += services[serviceType].Count();

                this.services_result_label.Text = "Result:\n\n"
                    + "\tServices Types Records: " + counter + "\n"
                    + "\tServices Records: " + services.Keys.Count();
            }
            catch
            {
                MessageBox.Show("Services Error");
            }
        }

        //###############
        //# Data Export #
        //###############
        private void services_export_button_Click(object sender, EventArgs e)   
        {
            try
            {
                foreach (string serviceType in services.Keys)
                    ServiceManager.AddServiceType(serviceType, services[serviceType]);
            }
            catch { MessageBox.Show("Error"); }
        }

        #endregion

    }
}
