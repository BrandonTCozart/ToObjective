// https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#conventions //
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToObjective.Models
{
    public class Objective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // https://www.youtube.com/watch?v=mydm-jIWwTY //
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CompleteByDate { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set;} = DateTime.Now;
        public DateTime? CompletedDate { get; set; }

        public Objective(string title, string? description, DateTime? completeByDate)
        {
            Title = title;
            Description = description;
            CompleteByDate = completeByDate;
        }

        public bool containsDescription()
        {
            if (this.Description == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
