﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Comment
    {
        
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Content { get; set; } = String.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
        
    }
}
