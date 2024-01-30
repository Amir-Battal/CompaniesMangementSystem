namespace APIs_Task.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public bool IsPrimary { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }//todo don't use the branchName or BranchLocation (We are in the branch class)
        
        public int CompanyId { get; set; }//todo you must put the navigation Property
        public Company Company { get; set; }//todo this is the NavigationProp


        //todo begin selfJoin
        public int? MainBranchId { get; set; }
        public Branch? MainBranch { get; set; }//todo this the selfJoin relationShip for
        
        public ICollection<Branch> SecondaryBranches { get; set; } = new List<Branch>();
        //todo end selfJoin
    }
}
