using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }
       
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Book { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$")]
        [Required]
        public int Chapter { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$")]
        [Required]
        public int Verse { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Note { get; set; }

        [Display(Name = "Added on")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }

    }
}
