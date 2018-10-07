using System;

namespace Application.Dtos
{
    public class CourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime SpendingTime { get; set; }
    }
}