namespace WebApi.Repositories.Models
{
    public partial class WhereUsedProductID
    {
        public int ProductAssemblyID { get; set; }
        public int ComponentID { get; set; }
        public string ComponentDesc { get; set; } = "";
        public double TotalQuatily { get; set; }
        public double StandardCost { get; set; }
        public double ListPrice { get; set; }
        public int BOMLevel { get; set; }
        public int RecursionLevel { get; set; }
    }

}