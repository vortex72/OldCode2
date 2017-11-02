namespace eClub.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ModulesViewModel
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }

        public ModulesViewModel() { }
        public ModulesViewModel(AppModules module)
        {
            this.ModuleID = module.dSECModule_ID;
            this.ModuleName = module.SECModule_Name;
        }
    }

    public class SelectScreenEditorViewModel
    {
        public SelectScreenEditorViewModel() { }

        // Update this to accept an argument of type AppScreen:
        public SelectScreenEditorViewModel(AppModules module)
        {
            this.ModuleID = module.dSECModule_ID;
            this.ModuleName = module.SECModule_Name;
        }

        public bool Selected { get; set; }
        [Key]
        public int ModuleID { get; set; }

        [Required]
        public string ModuleName { get; set; }

        // Add the new Description property:
        //public string ScreenFile { get; set; }
    }

    public class EditModuleViewModel
    {
        public string OriginalModuleName { get; set; }
        public string ModuleName { get; set; }

        public EditModuleViewModel() { }
        public EditModuleViewModel(AppModules module)
        {
            this.OriginalModuleName = module.SECModule_Name;
            this.ModuleName = module.SECModule_Name;
        }
    }
}