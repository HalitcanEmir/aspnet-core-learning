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

    public List<Project> GetAll()
    {
        // Gerçek hayatta burada DB sorgusu olur
        return _projects;
    }
}
