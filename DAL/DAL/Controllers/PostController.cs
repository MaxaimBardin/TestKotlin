using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    ApplicationContext _context;
    public PostController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("getPosts")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        var post = await _context.Post.ToListAsync();
        return Ok(post);
    }

    [HttpGet("getPost/{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.Post.FindAsync(id);
        if (post == null) return NotFound();
        return post;
    }

    [HttpPost("addPost")]
    public async Task<ActionResult<Post>> AddPost(Post post)
    {
        if (post == null) return BadRequest();
        await _context.Post.AddAsync(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }

    [HttpPut("updatePost")]
    public async Task<ActionResult<Post>> UpdatePost(Post post)
    {
        if (post == null) return BadRequest();

        _context.Update(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }

    [HttpDelete("deletePost/{Id}")]
    public async Task<ActionResult<Post>> DeletePost(int id)
    {
        var post = _context.Post.FirstOrDefaultAsync(p => p.PostId == id);
        if (post == null) return NotFound();
        _context.Post.Remove(await post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }
}
