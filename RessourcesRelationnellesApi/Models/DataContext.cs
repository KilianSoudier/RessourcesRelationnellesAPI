using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RessourcesRelationnellesAPI.Models;

public partial class DataContext : DbContext
{
    public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }
    public virtual DbSet<Categorie_Ressource> Categorie_Ressources { get; set; }
    public virtual DbSet<Chat> Chats { get; set; }
    public virtual DbSet<Commentaire> Commentaires { get; set; }
    public virtual DbSet<Image> Images { get; set; }
    public virtual DbSet<Jeu> Jeux { get; set; }
    public virtual DbSet<Langue> Langues { get; set; }
    public virtual DbSet<Partager> Partager { get; set; }
    public virtual DbSet<Relation_Utilisateurs> Relation_Utilisateurs { get; set; }
    public virtual DbSet<Ressources> Ressources { get; set; }
    public virtual DbSet<Texte> Textes { get; set; }
    public virtual DbSet<Trier_Ressources_Categories> Trier_Ressources_Categories { get; set; }
    public virtual DbSet<Type_Relation> Type_Relations { get; set; }
    public virtual DbSet<Type_Utilisateurs> Type_Utilisateurs { get; set; }
    public virtual DbSet<Video> Videos { get; set; }



    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RessourcesRelationnelles;TrustServerCertificate=True;Encrypt=False;persist security info=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
