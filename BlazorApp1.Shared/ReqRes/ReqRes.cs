using BlazorApp1.Shared.Card;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorApp1.Shared.ReqRes;

public class Person
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }
}

public class ReqResResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("data")]
    public List<Person>? Data { get; set; }

    [JsonPropertyName("support")]
    public Support? Support { get; set; }
}

public class Support
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

public static class ReqResExtension
{
    public static CardModel ConvertUserToCard(this Person person)
    {
        return new CardModel
        {
            Header = person.FirstName + " " + person.LastName,
            Title = person.Email,
            Image = person.Avatar,
            Text = "Esempio di text"
        };
    }
}

public class ReqResPostRequest
{
    [Required(ErrorMessage ="Il nome è obbligatorio")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Il lavoro è obbligatorio")]
    public string? Job { get; set; }
}

public class ReqResPostResponse: ReqResPostRequest
{
    public string? Id { get; set; }
    public string? CreatedAt { get; set; }
}