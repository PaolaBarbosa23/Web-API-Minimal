using Microsoft.EntityFrameworkCore;
using WebApiMinimal3.Contexto;
using WebApiMinimal3.MODELS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AdicionarProduto", async (Produto produto, Contexto contexto) =>
{
    contexto.Produto.Add(produto);
    await contexto.SaveChangesAsync();
 });
app.MapPost("ExcluirProduto/{id}", async (int id, Contexto contexto) =>
{
    var produtoExcluir = await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);
    if (produtoExcluir != null)
    {
        contexto.Produto.Remove(produtoExcluir);
        await contexto.SaveChangesAsync();
    }
});
app.MapPost("ListarProdutos", async (Contexto contexto) =>
{
    return await contexto.Produto.ToListAsync();
});
app.MapPost("ObterProdutos/{id}", async (int id, Contexto contexto) =>
{
    return await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);
});

app.UseSwaggerUI();
app.Run();
