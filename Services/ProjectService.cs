using System.Linq;
using aspnetegitim.Models;
using aspnetegitim.Data;
using Microsoft.EntityFrameworkCore;

namespace aspnetegitim.Services;

public class ProjectService
{
    private readonly AppDbContext _db;

    public ProjectService(AppDbContext db)
    {
        _db = db;
    }

    public List<Project> GetAll()
    {
        return _db.Projects.ToList();
    }

    public Project? GetById(int id)
    {
        return _db.Projects.FirstOrDefault(p => p.Id == id);
    }

    public Project Add(Project project)
    {
        _db.Projects.Add(project);
        _db.SaveChanges();
        return project;
    }
}
