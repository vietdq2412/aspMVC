﻿using System.ComponentModel.DataAnnotations;

namespace aspMVC.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> Students { get; } = [];
    }
}
