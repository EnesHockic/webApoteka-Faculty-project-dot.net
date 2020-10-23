using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class EditRoleVM
    {
        public EditRoleVM()
        {
            Users = new List<string>();
        }
        public string ID { get; set; }
        [Required(ErrorMessage = "Naziv uloge je obavezan")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
