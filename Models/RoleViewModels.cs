using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eClub.Context;

namespace eClub.Models
{
    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<AppModules> RoleModules { get; set; }

        public RoleViewModel() { }
        public RoleViewModel(ApplicationRole role)
        {
            this.RoleName = role.Name;
            this.Description = role.Description;
            IEnumerable<AppModules> RoleModules = new List<AppModules>();
        }
        
    }

    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }

        // Update this to accept an argument of type ApplicationRole:
        public SelectRoleEditorViewModel(ApplicationRole role)
        {
            this.RoleName = role.Name;

            // Assign the new Descrption property:
            this.Description = role.Description;

            IEnumerable<AppModules> RoleModules = new List<AppModules>();
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }

        // Add the new Description property:
        public string Description { get; set; }

        public virtual IEnumerable<ModulesViewModel> RoleModules { get; set; }
    }

    public class EditRoleViewModel
    {
        public string OriginalRoleName { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<ModulesViewModel> RoleModules { get; set; }
       
        public EditRoleViewModel() { }
        public EditRoleViewModel(ApplicationRole role)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ModulesList = new List<ModulesViewModel>();
            foreach (var module in db.AppModules)
            {
                var ModuleModel = new ModulesViewModel(module);
                ModulesList.Add(ModuleModel);
            }

            this.OriginalRoleName = role.Name;
            this.RoleName = role.Name;
            this.Description = role.Description;
            
            RoleModules = ModulesList;
            
        }
    }
}