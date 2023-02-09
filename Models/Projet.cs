using System;
using System.Collections.Generic;

namespace Exemple.Models;

public partial class Projet
{
	public int Id { get; set; }

	public string Nom { get; set; } = null!;

	public string? Description { get; set; }

	public DateTime DateCreation { get; set; }

	public virtual List<Liste> Listes { get; } = new();

	public virtual List<ProjetUtilisateur> ProjetUtilisateurs { get; } = new();
}
