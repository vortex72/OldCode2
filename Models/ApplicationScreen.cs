namespace CCCore.Models
{
   using System.ComponentModel.DataAnnotations.Schema;

    [Table("SCREENS")]
    public class ApplicationScreen
    {
        public SCREEN()
        {
            ROLES = new HashSet<ROLE>();
        }

        [Key]
        public int User_Id { get; set; }

        public ApplicationScreen() : base() { }

        public ApplicationScreen(string ScreenName, string ScreenFile)
            : base(ScreenName)
        {
            this.ScreenName = ScreenName;
            this.ScreenFile = ScreenFile;
        }

        public virtual string ScreenName { get; set; }
        public virtual string ScreenFile { get; set; }
    }
}