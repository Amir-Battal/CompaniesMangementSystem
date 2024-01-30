namespace APIs_Task.Dtos
{
    public class AddBranchDto
    {
        public bool IsPrimary { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public int CompanyId { get; set; }
    }
}
