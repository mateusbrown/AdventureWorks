namespace WebApi.Repositories.Models
{
    public partial class ContactInformation
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string BusinessEntityType { get; set; } = null!;
    }
}