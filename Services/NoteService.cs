using System.Collections.Generic;
using System.Linq;
using aspnetegitim.Data;
using aspnetegitim.Models;

namespace aspnetegitim.Services;

public class NoteService
{
    private readonly AppDbContext _db;

    public NoteService(AppDbContext db)
    {
        _db = db;
    }

    public Note Add(string title, string body)
    {
        var note = new Note { Title = title, Body = body, CreatedAt = System.DateTime.UtcNow };
        _db.Notes.Add(note);
        _db.SaveChanges();
        return note;
    }

    public List<Note> GetAll()
    {
        return _db.Notes.OrderByDescending(n => n.CreatedAt).ToList();
    }
}
