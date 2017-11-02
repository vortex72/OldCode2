namespace eClub.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class mTablesViewModel
    {
        public int MasterTable_ID { get; set; }
        public string MasterTable_Name { get; set; }
        public string MasterTable_Description { get; set; }

        public mTablesViewModel() { }
        public mTablesViewModel(AppTables mTable)
        {
            this.MasterTable_ID = mTable.MasterTable_ID;
            this.MasterTable_Name = mTable.MasterTable_Name;
            this.MasterTable_Description = mTable.MasterTable_Description;
        }
    }

    public class SelectMTableEditorViewModel
    {
        public SelectMTableEditorViewModel() { }

        // Update this to accept an argument of type AppScreen:
        public SelectMTableEditorViewModel(AppTables mTable)
        {
            this.MasterTable_ID = mTable.MasterTable_ID;
            this.MasterTable_Name = mTable.MasterTable_Name;
            this.MasterTable_Description = mTable.MasterTable_Description;

        }

        public bool Selected { get; set; }
        [Key]
        public int MasterTable_ID { get; set; }

        [Required]
        public string MasterTable_Name { get; set; }

        [Required]
        public string MasterTable_Description { get; set; }
    }

    public class EditMTableViewModel
    {
        public string OriginalMTableName { get; set; }
        public string OriginalMTableDescription { get; set; }
        public string MasterTable_Name { get; set; }
        public string MasterTable_Description { get; set; }

        public EditMTableViewModel() { }
        public EditMTableViewModel(AppTables mTable)
        {
            this.OriginalMTableName = mTable.MasterTable_Name;
            this.MasterTable_Name = mTable.MasterTable_Name;

            this.OriginalMTableDescription = mTable.MasterTable_Description;
            this.MasterTable_Description = mTable.MasterTable_Description;
        }
    }
}
