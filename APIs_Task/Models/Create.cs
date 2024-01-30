namespace APIs_Task.Models
{
    public class Create//todo pick more convenice name up
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }//todo yes you identify the relation in this side but the other side??????
        
        public int ProductId { get; set; }
        public Product Product { get; set; } //todo yes you identify the relation in this side but the other side??????

        public int ProductQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
