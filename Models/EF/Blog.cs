using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.Models.EF{
    public class Blog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsSlider { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}