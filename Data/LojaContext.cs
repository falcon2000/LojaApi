using System;
using LojaApi.Controllers;
using Microsoft.EntityFrameworkCore;
using LojaApi.Entities;

namespace LojaApi.Data;

public class LojaContext : DbContext
{
    public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
