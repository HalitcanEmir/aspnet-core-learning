using System;

namespace aspnetegitim.Models;

public class Message
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    // HTML-encoded body (contains <br/> for line breaks)
    public string BodyHtml { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}
