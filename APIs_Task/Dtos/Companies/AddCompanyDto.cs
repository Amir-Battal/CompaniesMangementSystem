namespace APIs_Task.Dtos.Company
{
    public class AddCompanyDto
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime EstDate { get; set; }

        public bool IsActive { get; set; }
    }
}
