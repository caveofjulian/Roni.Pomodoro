using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Roni.Pomodoro.Persistence.Entities
{
    public class TaskBlockCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string Description { get; set; }
    }
}
