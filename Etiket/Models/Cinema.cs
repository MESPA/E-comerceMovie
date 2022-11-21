using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Etiket.Data.Base;

namespace Etiket.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //Relationship
        public List<Movie> Movies { get; set; }
    }
}

