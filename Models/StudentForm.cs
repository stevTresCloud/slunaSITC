using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slunaSITC.Models
{
    public class StudentForm
    {
        public string IdType { get; set; }
        public string Identification { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string Career { get; set; }
        public string Modality { get; set; }
        public string Campus { get; set; }
    }
}
