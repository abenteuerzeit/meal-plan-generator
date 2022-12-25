using System;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models
{
    public abstract class EntityBase
    {
        [Required, Key]
        public int Id { get; set; }
    }
}

