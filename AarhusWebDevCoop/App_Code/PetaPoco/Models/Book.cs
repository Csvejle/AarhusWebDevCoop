using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace AarhusWebDevCoop.App_Code.PetaPoco.Models
{
    [TableName("CMBooks")]
    [PrimaryKey("BookID", autoIncrement = true)]
    [ExplicitColumns]
    public class Book
    {
        [Column("BookID")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int BookID { get; set; }

        [Column("AuthorID")]
        [ForeignKey(typeof(Author), Name = "FK_Book_Author")]
        [IndexAttribute(IndexTypes.NonClustered, Name = "IX_AuthorID")]
        public int AuthorID { get; set; }

        [Column("Title")]
        [Length(120)]
        public string Title { get; set; }

        [Column("Description")]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string Description { get; set; }

        [Column("Year")]
        public int Year { get; set; }
    }
}
