using System;

namespace Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime SpendingTime { get; set; }
    }
}