﻿namespace TodoWebApp.Service.Implementations
{
    internal class TodoEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CurrentDate { get; set; }
        public int isComplete { get; set; }
    }
}