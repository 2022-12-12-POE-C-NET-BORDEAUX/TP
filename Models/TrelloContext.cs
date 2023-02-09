using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exemple.Models;

public partial class TrelloContext : DbContext
{
	public TrelloContext()
	{
		Utilisateur SU = new Utilisateur("bob", "Bob@gmail.com", "123");
		Utilisateurs.Add(SU);
		SaveChanges();
	}

	public virtual DbSet<Carte> Cartes { get; set; }

	public virtual DbSet<Commentaire> Commentaires { get; set; }

	public virtual DbSet<Etiquette> Etiquettes { get; set; }

	public virtual DbSet<Liste> Listes { get; set; }

	public virtual DbSet<Projet> Projets { get; set; }

	public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

	public virtual DbSet<ProjetUtilisateur> ProjetUtilisateurs { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=trello;User=root;Password=0000;");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Carte>(entity =>
		{
			entity.HasOne(d => d.IdListeNavigation).WithMany(p => p.Cartes).HasForeignKey(d => d.IdListe);
		});

		modelBuilder.Entity<Commentaire>(entity =>
		{
			entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Commentaires).HasForeignKey(d => d.IdCarte);

			entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Commentaires).HasForeignKey(d => d.IdUtilisateur);
		});

		modelBuilder.Entity<Etiquette>(entity =>
		{
			entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Etiquettes).HasForeignKey(d => d.IdCarte);
		});

		modelBuilder.Entity<Liste>(entity =>
		{
			entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.Listes).HasForeignKey(d => d.IdProjet);
		});

		modelBuilder.Entity<ProjetUtilisateur>(entity =>
		{
			entity.HasKey(e => new { e.IdProjet, e.IdUtilisateur }).HasName("PRIMARY");

			entity.HasOne(e => e.projetNav).WithMany(e => e.ProjetUtilisateurs);
			entity.HasOne(e => e.UtilisateurNav).WithMany(e => e.ProjetUtilisateurs);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
