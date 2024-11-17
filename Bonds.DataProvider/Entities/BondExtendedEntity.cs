using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonds.DataProvider.Entities
{
    public class BondExtendedEntity
    {

        /// <summary>
        /// Международный идентификационный код ценной бумаги
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ISIN { get; set; }

       
        public long? EmitterId { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
