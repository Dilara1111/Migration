using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad mutleq yazilmalidir"), MinLength(3, ErrorMessage = "Uzunluq 3den az olmalilidir")]
        public int Title { get; set; }   // bunu stringe deyihsmek lazimdir 
        public List<CategoryComponents>? CategoryComponents { get; set; } // bir categorinin birden cox komponenti oldugu ucun list sheklinde saxlayiriq
        // Navigation property - bir propertiden diger ptopertiye catiriqsa,
        // problem cixartmasin deye ?-nullable isharesi qoyuruq
    }

}
