using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ResearchProjectRepository
    {
        private readonly Sp25researchDbContext _context = new();

        public List<ResearchProject> GetAll(string projectTitle = "", string researchField = "")
        {
            var query = _context.ResearchProjects.Include(x => x.LeadResearcher).AsQueryable();

            if (!string.IsNullOrEmpty(projectTitle))
            {
                query = query.Where(x => x.ProjectTitle.Contains(projectTitle));
            }

            if (!string.IsNullOrEmpty(researchField))
            {
                query = query.Where(x => x.ResearchField.Contains(researchField));
            }

            return query.ToList();
        }

        public bool Delete(ResearchProject entity)
        {
            _ = _context.ResearchProjects.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
