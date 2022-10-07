using System.ComponentModel.DataAnnotations;

namespace e_Tickets.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Profile Picture")]
        public string Picture { get; set; }
        public string Bio { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}