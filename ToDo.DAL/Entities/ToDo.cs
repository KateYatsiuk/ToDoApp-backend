namespace ToDoTasks.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ToDoTasks.DAL.Enums;
    using ToDoTasks.DAL.Validation;

    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title field is required.")]
        [MaxLength(45)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "CreationDate field is required.")]
        [DataType(DataType.Date, ErrorMessage = "The {0} field must be a valid date in the format 'yyyy-MM-dd'.")]
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        [ValidateEnum(typeof(State), ErrorMessage = "Not valid State.")]
        public State ToDoState { get; set; } = State.ToDo;
    }
}