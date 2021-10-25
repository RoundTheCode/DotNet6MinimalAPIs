using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoundTheCode.FrontEndPostApi.Models;
using RoundTheCode.FrontEndPostApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPostService, PostService>();
builder.Services.AddSingleton<ICommentService, CommentService>();

builder.Services.AddEndpointsApiExplorer(); // Need to add this in for it to appear in Swagger.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Post API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// Comments API
app.MapGet("api/comment/{postId}", (IPostService postService, ICommentService commentService, int postId) =>
{
    var post = postService.ReadById(postId);

    if (post == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(commentService.ReadAllByPost(postId));
});

app.MapPost("api/comment", (IPostService postService, ICommentService commentService, CreateComment createComment) =>
{
    var post = postService.ReadById(createComment.PostId);

    if (post == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(commentService.Create(createComment));
});

// Posts API
app.MapGet("api/post", (IPostService postService) =>
{
    return postService.ReadAll();
});

app.MapGet("api/post/{slug}", (IPostService postService, string slug) =>
{
    var post = postService.ReadBySlug(slug);

    if (post == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(post);
});

app.Run();
