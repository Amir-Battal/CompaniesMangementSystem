namespace APIs_Task.Services
{
    public interface ICreateService
    {
        Task<IEnumerable<Create>> GetAll();
        Task<Create> Add(Create create);
        Create Update(Create create);
        Task<Create> GetCreatesByIDs(int branchId, int productId);
        Create Delete(Create create);


    }
}
