using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Roni.Pomodoro.Persistence.Entities
{
    public class TaskBlock
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(TaskBlockCategory))]
        public int TaskBlockCategoryId { get; set; }
        public TaskBlockCategory TaskBlockCategory { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsTerminated { get; set; }
        public string Description { get; set; }
    }
}
