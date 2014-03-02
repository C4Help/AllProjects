using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C4H_DataInsertion.Structure
{
    public class CharityType
    {

        #region Constructor

        public CharityType(string CharityTypeName, string CharityTypeDescription)    
        {
            this.CharityTypeName = CharityTypeName;
            this.CharityTypeDescription = CharityTypeDescription;
        }

        #endregion

        #region Variable

        private string charityTypeName;
        private string charityTypeDescription;

        #endregion

        #region Properties

        public string CharityTypeName           
        {
            get { return this.charityTypeName; }
            set { this.charityTypeName = value; }
        }
        public string CharityTypeDescription    
        {
            get { return this.charityTypeDescription; }
            set { this.charityTypeDescription = value; }
        }

        #endregion

    }
}
