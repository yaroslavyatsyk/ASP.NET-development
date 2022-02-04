namespace Contact_Manager_APP.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateAdded { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Organization { get; set; }

        public Category? Category { get; set; }

        public int CategoryID { get; set; }

        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

    }
}
