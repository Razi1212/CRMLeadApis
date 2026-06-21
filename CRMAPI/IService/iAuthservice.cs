using CRMAPI.Entities;

namespace CRMAPI.IService
{
    public interface iAuthservice
    {
        Task<List<User>> GetLead();
    }
}
