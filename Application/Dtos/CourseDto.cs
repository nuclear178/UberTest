using System;

namespace Application.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; } //To scalar
        public DateTime SpendingTime { get; set; } //same
    }
}