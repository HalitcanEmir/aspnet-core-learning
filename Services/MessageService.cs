using System.Collections.Generic;
using System.Linq;
using aspnetegitim.Models;

namespace aspnetegitim.Services;

public class MessageService
{
    private readonly List<Message> _messages = new();
    private int _nextId = 1;
    private readonly object _lock = new();

    public Message Add(string fullName, string bodyHtml)
    {
        var msg = new Message
        {
            Id = GetNextId(),
            FullName = fullName,
            BodyHtml = bodyHtml,
            CreatedAt = System.DateTime.UtcNow
        };

        lock (_lock)
        {
            _messages.Add(msg);
        }

        return msg;
    }

    private int GetNextId()
    {
        lock (_lock)
        {
            return _nextId++;
        }
    }

    public List<Message> GetAll()
    {
        lock (_lock)
        {
            return _messages.OrderByDescending(m => m.CreatedAt).ToList();
        }
    }
}
