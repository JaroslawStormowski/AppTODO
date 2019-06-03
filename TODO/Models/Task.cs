using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;

namespace TODO.Models
{
    public class Task
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        [DisplayName("Your task")]
        public string Name { get; set; }

        [DisplayName("Details")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [DisplayName("")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public Task()
        {
            Text = " ";
            ImagePath = "~/AppFiles/Images/btn_attach.png";
        }
    }
}