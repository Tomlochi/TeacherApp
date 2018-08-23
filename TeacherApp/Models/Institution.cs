using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherApp.Models
{


    public class Institution
    {

        public int InstitutionID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string InstitutionType { get; set; }

        //static int count = 0;
        //public Institution()
        //{
        //    count++;
        //    InstitutionID = count;
        //}
        //public Institution(int institutionid, string name, string location, InstitutionType institutionType)
        //{
        //    this.InstitutionID = institutionid;
        //    this.Name = name;
        //    this.Location = location;
        //    this.InstitutionType = institutionType;
        //}
        //public Institution(Institution institution)
        //{
        //    this.InstitutionID = institution.InstitutionID;
        //    this.Name = institution.Name;
        //    this.Location = institution.Location;
        //    this.InstitutionType = institution.InstitutionType;
        //}


    }
}
