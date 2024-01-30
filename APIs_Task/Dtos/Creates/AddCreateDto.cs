namespace APIs_Task.Dtos.Create
{
    public class AddCreateDto
    {
        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
