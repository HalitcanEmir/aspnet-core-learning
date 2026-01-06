var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

static string Layout(string title, string body)
{
    var template = """
<!doctype html>
<html lang="tr">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>__TITLE__</title>
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
    <a href="/">Ana Sayfa</a>
    <a href="/hakkimda">Hakkımda</a>
    <a href="/projeler">Projeler</a>
    <a href="/iletisim">İletişim</a>
  </nav>

  __BODY__
</body>
</html>
""";
    return template.Replace("__TITLE__", System.Net.WebUtility.HtmlEncode(title)).Replace("__BODY__", body);
}

// Ana Sayfa
app.MapGet("/", () =>
{
    var body = """
<h1>Mini Site</h1>
<div class="card">
  <p>Bu site ASP.NET Core Minimal API ile yapılıyor.</p>
  <p>Menüden sayfalar arasında gezebilirsin.</p>
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
  <p>Bir sonraki adım: sayfaları dosyalara ayırmak ve gerçek UI (Razor) kullanmak.</p>
</div>
""";
    return Results.Content(Layout("Hakkımda", body), "text/html; charset=utf-8");
});

// Projeler
app.MapGet("/projeler", () =>
{
    var body = """
<h1>Projeler</h1>
<div class="card">
  <ul>
    <li>LifePlan</li>
    <li>Fikir Pazarı</li>
    <li>HSD OSTİMTECH Web</li>
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
app.MapPost("/iletisim", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();
    var fullName = form["fullName"].ToString();
    var message = form["message"].ToString();

    // Güvenlik: HTML injection olmasın diye encode ediyoruz
    fullName = System.Net.WebUtility.HtmlEncode(fullName);
    message = System.Net.WebUtility.HtmlEncode(message);

    var body = $"""
<h1>Teşekkürler!</h1>
<div class="card">
  <p><b>Ad Soyad:</b> {fullName}</p>
  <p><b>Mesaj:</b><br/>{message.Replace("\n", "<br/>")}</p>
</div>
""";

    return Results.Content(Layout("Gönderildi", body), "text/html; charset=utf-8");
});

app.Run();
