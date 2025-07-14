using DAL.Models;
using DAL.Repositories;

namespace BAL.Services
{
    public class ResearchProjectService
    {
        private readonly ResearchProjectRepository _repo = new();

        public List<ResearchProject> GetAll(string projectTitle = "", string researchField = "")
        {
            return _repo.GetAll(projectTitle, researchField);
        }

        public bool Delete(ResearchProject entity)
        {
            return _repo.Delete(entity);
        }
    }
}
