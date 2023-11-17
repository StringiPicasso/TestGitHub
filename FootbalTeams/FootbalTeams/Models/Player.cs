using FootbalTeams.Models;
using System.ComponentModel.DataAnnotations;

namespace CatalogOfFootballPlayers.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }
        
        [Required]
        public Genders Gender { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public List<TeamNames> NameTeamsList { get; set; }

        [Required]
        public Countries Country { get; set; }
    }
}
