using Microsoft.AspNetCore.Http;
using aspnetegitim.Services;

namespace aspnetegitim.Endpoints;

public static class PagesEndpoints
{
    public static void MapPages(this WebApplication app)
    {
        // Ana Sayfa
        app.MapGet("/", () =>
        {
            var body = """
<h1>Mini Site</h1>
<div class="card">
  <p>Bu site ASP.NET Core Minimal API ile yapılıyor.</p>
  <p>Menüden sayfalarrrr arasında gezebilirsin.</p>
</div>
""";
            return Results.Content(Layout("Ana Sayfa", body), "text/html; charset=utf-8");
        });

        // Hakkımda
        app.MapGet("/hakkimda", () =>
        {
            var body = """
<h1>Hakkımda</h1>
<div class="card">
  <p>Ben Halitcan. .NET öğreniyorum ve küçük bir web sitesi yapıyorum.</p>
  <p>Bir sonraki adım: Razor Pages ile gerçek sayfa dosyalarına geçmek.</p>
</div>
""";
            return Results.Content(Layout("Hakkımda", body), "text/html; charset=utf-8");
        });

        // Projeler
app.MapGet("/projeler", (Services.ProjectService projectService) =>
{
    var projects = projectService.GetAll();

    var items = string.Join("", projects.Select(p =>
        $"""
<li>
  <b>{System.Net.WebUtility.HtmlEncode(p.Name)}</b> — {System.Net.WebUtility.HtmlEncode(p.Status)}<br/>
  <small>{System.Net.WebUtility.HtmlEncode(p.Description)}</small>
</li>
"""
    ));

    var body = $"""
<h1>Projeler</h1>
<div class="card">
  <ul>
    {items}
  </ul>
</div>
""";

    return Results.Content(Layout("Projeler", body), "text/html; charset=utf-8");
});
        // İletişim (GET)
        app.MapGet("/iletisim", () =>
        {
            var body = """
<h1>İletişim</h1>
<div class="card">
  <form method="post" action="/iletisim">
    <label>Ad Soyad</label>
    <input name="fullName" placeholder="Ad Soyad" />

    <label style="display:block; margin-top:12px;">Mesaj</label>
    <textarea name="message" rows="5" placeholder="Mesajın..."></textarea>

    <div style="margin-top:12px;">
      <button type="submit">Gönder</button>
    </div>
  </form>
</div>
""";
            return Results.Content(Layout("İletişim", body), "text/html; charset=utf-8");
        });

        // İletişim (POST)
        app.MapPost("/iletisim", async (HttpRequest request, Services.ContactService contactService) =>
        {
            var result = await contactService.HandleAsync(request);

            var body = $"""
<h1>Teşekkürler!</h1>
<div class="card">
  <p><b>Ad Soyad:</b> {result.FullName}</p>
  <p><b>Mesaj:</b><br/>{result.MessageHtml}</p>
</div>
""";

            return Results.Content(Layout("Gönderildi", body), "text/html; charset=utf-8");
        });
    }

    // UI (layout) burada, sonra ayrı dosyaya da taşıyacağız
    private static string Layout(string title, string body)
    {
        return @"<!doctype html>
<html lang=""tr"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
  <title>" + title + @"</title>
  <style>
    body { font-family: -apple-system, system-ui, Arial; max-width: 900px; margin: 40px auto; padding: 0 16px; }
    nav a { margin-right: 12px; text-decoration: none; }
    nav a:hover { text-decoration: underline; }
    .card { border: 1px solid #ddd; border-radius: 12px; padding: 16px; margin-top: 16px; }
    input, textarea { width: 100%; padding: 10px; margin-top: 6px; border-radius: 10px; border: 1px solid #ccc; }
    button { padding: 10px 14px; border-radius: 10px; border: 1px solid #ccc; cursor: pointer; }
  </style>
</head>
<body>
  <nav>
    <a href=""/"">Ana Sayfa</a>
    <a href=""/hakkimda"">Hakkımda</a>
    <a href=""/projeler"">Projeler</a>
    <a href=""/iletisim"">İletişim</a>
  </nav>

  " + body + @"
</body>
</html>";
    }
}
