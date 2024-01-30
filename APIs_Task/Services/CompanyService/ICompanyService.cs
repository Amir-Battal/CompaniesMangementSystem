namespace APIs_Task.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<Company> GetOneById(int id);
        Task<Company> Add(Company company);
        Company Update(Company company);
        Company Delete(Company company);

    }
}
