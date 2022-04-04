namespace WebApi.Repositories.Models
{
    public partial class ManagerEmployees
    {
        public int RecursionLevel { get; set; }
        public string OrganizationNode { get; set; } = null!;
        public string ManagerFirstName { get; set; } = "";
        public string ManagerLastName { get; set; } = "";
        public int BusinessEntityID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}