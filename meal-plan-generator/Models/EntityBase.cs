using System;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models
{
    public class EntityBase
    {
        [Key, Required]
        public int Id { get; set; }
    }
}

