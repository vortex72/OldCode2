namespace eClub.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using eClub.Context;

    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<AppScreen> RoleScreens { get; set; }

        public RoleViewModel() { }
        public RoleViewModel(ApplicationRole role)
        {
            this.RoleName = role.Name;
            this.Description = role.Description;
            IEnumerable<AppScreen> RoleScreens = new List<AppScreen>();
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

            IEnumerable<AppScreen> RoleScreens = new List<AppScreen>();
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }

        // Add the new Description property:
        public string Description { get; set; }

        public virtual IEnumerable<ScreenViewModel> RoleScreens { get; set; }
    }

    public class EditRoleViewModel
    {
        public string OriginalRoleName { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<ScreenViewModel> RoleScreens { get; set; }
       
        public EditRoleViewModel() { }
        public EditRoleViewModel(ApplicationRole role)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ScreensList = new List<ScreenViewModel>();
            foreach (var screen in db.AppScreens)
            {
                var ScreenModel = new ScreenViewModel(screen);
                ScreensList.Add(ScreenModel);
            }

            this.OriginalRoleName = role.Name;
            this.RoleName = role.Name;
            this.Description = role.Description;
            
            RoleScreens = ScreensList;
            
        }
    }
}