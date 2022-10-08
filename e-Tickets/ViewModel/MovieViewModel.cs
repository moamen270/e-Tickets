﻿using e_Tickets.Models;

namespace e_Tickets.ViewModel
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public int CinemaId { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Cinema Cinema { get; set; }
        public Producer Producer { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}