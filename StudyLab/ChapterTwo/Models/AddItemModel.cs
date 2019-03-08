using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChapterTwo.Models
{
    public class AddItemModel
    {
        public int Id{ get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Remote("IsTitleAvailable", "Home")]
        public string Title { get; set; }

        [Range(300, 3000)]
        public int NumberOfAuthors { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 250)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
    }
}