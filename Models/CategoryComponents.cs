namespace PurpleBuzz.Models
{
    public class CategoryComponents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public Category Category { get; set; }     // One to many relationu qururuq
        public int CategoryId { get; set; }        // Categorinin Id-si saxlayiriq


    }
}
