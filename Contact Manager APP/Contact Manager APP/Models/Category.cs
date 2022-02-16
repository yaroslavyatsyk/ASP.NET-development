using System.ComponentModel.DataAnnotations;

namespace Contact_Manager_APP.Models
{
    public class Category
    {
        [Key]
        public int? CategoryID { get; set; }
        public string? Name { get; set; }
    }
}
