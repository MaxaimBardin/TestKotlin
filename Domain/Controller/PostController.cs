using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Domain.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/Domain/[controller]")]
public class PostController : ControllerBase
{
    private readonly string? _dalUrl;
    private readonly HttpClient _client;

    public PostController(IConfiguration conf)
    {
        _dalUrl = conf.GetValue<string>("DalUrl");
        _client = new HttpClient();
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        JsonContent content = JsonContent.Create(post);
        using var result = await _client.PostAsync($"{_dalUrl}/api/DAL/Product/AddProduct", content);
        var dalPost = await result.Content.ReadFromJsonAsync<Post>();

        if (dalPost == null)
            return BadRequest();
        else
            return dalPost;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var response = await _client.GetAsync($"{_dalUrl}/api/Post/getPost/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if (content == null) return NotFound();

        return JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

}