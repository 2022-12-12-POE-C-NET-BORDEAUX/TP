namespace Exemple.Models;

public class ProjetUtilisateur
{
	public int IdProjet { get; set; }
	public Projet projetNav { get; set; }

	public int IdUtilisateur { get; set; }
	public Utilisateur UtilisateurNav { get; set; }

	public ProjetUtilisateur()
	{

	}
}
