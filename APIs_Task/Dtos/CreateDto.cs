namespace APIs_Task.Dtos
{
    public class CreateDto
    {
        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
