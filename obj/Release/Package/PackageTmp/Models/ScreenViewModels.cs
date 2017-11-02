namespace eClub.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ScreenViewModel
    {
        public int ScreenID { get; set; }
        public string ScreenName { get; set; }

        public ScreenViewModel() { }
        public ScreenViewModel(AppScreen screen)
        {
            this.ScreenID = screen.SECScreen_ID;
            this.ScreenName = screen.SECScreen_Name;
        }
    }

    public class SelectScreenEditorViewModel
    {
        public SelectScreenEditorViewModel() { }

        // Update this to accept an argument of type AppScreen:
        public SelectScreenEditorViewModel(AppScreen screen)
        {
            this.ScreenID = screen.SECScreen_ID;
            this.ScreenName = screen.SECScreen_Name;

        }

        public bool Selected { get; set; }
        [Key]
        public int ScreenID { get; set; }

        [Required]
        public string ScreenName { get; set; }

        // Add the new Description property:
        public string ScreenFile { get; set; }
    }

    public class EditScreenViewModel
    {
        public string OriginalScreenName { get; set; }
        public string ScreenName { get; set; }

        public EditScreenViewModel() { }
        public EditScreenViewModel(AppScreen screen)
        {
            this.OriginalScreenName = screen.SECScreen_Name;
            this.ScreenName = screen.SECScreen_Name;
        }
    }
}