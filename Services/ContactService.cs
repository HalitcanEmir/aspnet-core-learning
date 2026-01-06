using Microsoft.AspNetCore.Http;

namespace aspnetegitim.Services;

public class ContactService
{
    public async Task<ContactResult> HandleAsync(HttpRequest request)
    {
        var form = await request.ReadFormAsync();

        var fullName = form["fullName"].ToString();
        var message = form["message"].ToString();

        // Neden encode ediyoruz?
        // Kullanıcı <script> gibi şeyler yazıp sayfayı bozamasın / XSS olmasın
        fullName = System.Net.WebUtility.HtmlEncode(fullName);
        message = System.Net.WebUtility.HtmlEncode(message);

        return new ContactResult
        {
            FullName = fullName,
            MessageHtml = message.Replace("\n", "<br/>")
        };
    }
}

public class ContactResult
{
    public string FullName { get; set; } = "";
    public string MessageHtml { get; set; } = "";
}
