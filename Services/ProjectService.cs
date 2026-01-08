using System.Linq;
using aspnetegitim.Models;

namespace aspnetegitim.Services;

public class ProjectService
{
    // Şimdilik fake veri: sonra DB’ye geçince sadece burası değişecek
    private static readonly List<Project> _projects =
    [
        new Project { Id = 1, Name = "LifePlan", Description = "Hedef, alışkanlık, günlük takip platformu", Status = "Devam ediyor" },
        new Project { Id = 2, Name = "Fikir Pazarı", Description = "Fikir oylama ve ekip kurma uygulaması", Status = "Devam ediyor" },
        new Project { Id = 3, Name = "HSD OSTİMTECH Web", Description = "Topluluk için etkinlik/duyuru web arayüzü", Status = "Tamamlandı" },
    ];

    private static int _nextId = _projects.Any() ? _projects.Max(p => p.Id) + 1 : 1;
    private static readonly object _lock = new();

    public List<Project> GetAll()
    {
        // Gerçek hayatta burada DB sorgusu olur
        return _projects;
    }

    public Project? GetById(int id)
    {
        return _projects.FirstOrDefault(p => p.Id == id);
    }

    public Project Add(Project project)
    {
        lock (_lock)
        {
            project.Id = _nextId++;
            _projects.Add(project);
        }

        return project;
    }
}
