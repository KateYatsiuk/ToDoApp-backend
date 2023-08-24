namespace ToDoTasks.DAL.Persistence
{
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base(
            dateOnly => DateTime.Parse(dateOnly.ToString()),
            dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }
}
