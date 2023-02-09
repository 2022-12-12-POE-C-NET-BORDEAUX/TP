﻿using System;
using System.Collections.Generic;

namespace Exemple.Models;

public partial class Utilisateur
{
	public int Id { get; set; }

	public string Nom { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string MotDePasse { get; set; } = null!;

	public DateTime DateInscription { get; set; }

	public virtual List<Commentaire> Commentaires { get; } = new List<Commentaire>();

	public virtual List<ProjetUtilisateur> ProjetUtilisateurs { get; } = new();

	public Utilisateur() { }

	public Utilisateur(string Nom, string Email, string Mdp)
	{
		this.Nom = Nom;
		this.Email = Email;
		this.MotDePasse = Mdp;
		this.DateInscription = DateTime.Now;
	}
}
