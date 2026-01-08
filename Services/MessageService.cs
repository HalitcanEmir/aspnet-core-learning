using System.Collections.Generic;
using System.Linq;
using aspnetegitim.Models;
using aspnetegitim.Data;
using Microsoft.EntityFrameworkCore;

namespace aspnetegitim.Services;

public class MessageService
{
    private readonly AppDbContext _db;

    public MessageService(AppDbContext db)
    {
        _db = db;
    }

    public Message Add(string fullName, string bodyHtml)
    {
        var msg = new Message
        {
            FullName = fullName,
            BodyHtml = bodyHtml,
            CreatedAt = System.DateTime.UtcNow
        };

        _db.Messages.Add(msg);
        _db.SaveChanges();

        return msg;
    }

    public List<Message> GetAll()
    {
        return _db.Messages.OrderByDescending(m => m.CreatedAt).ToList();
    }
}

