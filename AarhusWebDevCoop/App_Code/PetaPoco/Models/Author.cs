using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace AarhusWebDevCoop.App_Code.PetaPoco.Models
{
    [TableName("CMAuthors")]
    [PrimaryKey("AuthorID", autoIncrement = true)]
    [ExplicitColumns]
    public class Author
    {
        [Column("AuthorID")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int AuthorID { get; set; }

        [Column("Name")]
        [Length(20)]
        public string Name { get; set; }

        [Column("Surname")]
        [Length(20)]
        public string Surname { get; set; }

        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }

}