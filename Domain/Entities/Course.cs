using System;

namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Time SpendingTime { get; set; }
    }
}