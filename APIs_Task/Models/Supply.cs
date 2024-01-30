namespace APIs_Task.Models
{
    public class Supply
    {
        public int BranchId { get; set; }//todo where is the navigation property?
        public int ProductId { get; set; }//todo where is the navigation property?
        public int SProductQuantity { get; set; }
        public DateTime SuppliedDate { get; set; }
        [ForeignKey(nameof(fromBranch))]//todo no we don't do that here 
        public int fromBranch { get; set; }

    }
}
