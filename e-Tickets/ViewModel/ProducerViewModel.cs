using System.ComponentModel.DataAnnotations;

namespace e_Tickets.ViewModel
{
    public class ProducerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Profile Picture")]
        public string Picture { get; set; }

        public string Bio { get; set; }
    }
}