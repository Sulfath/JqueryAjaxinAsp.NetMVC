namespace JqueryAjaxinAsp.NetMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Employee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public Nullable<int> Salary { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Employee()
        { 
            ImagePath = "~/AppFiles/Images/default.png";
        }
    }
}
