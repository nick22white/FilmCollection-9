using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class NewMovie
    {
        [Key]
        public int MovieId { get; set; }
        //Category is required field
        //Getters and setters for the model
        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }

        //Title is required field
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        //Year is required field
        [Required(ErrorMessage = "Please enter a year")]
        public string Year { get; set; }

        //Director is required field
        [Required(ErrorMessage = "Please enter a director")]
        public string Director { get; set; }

        //Rating is  required field
        [Required(ErrorMessage = "Please select a rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        public string Notes { get; set; }
    }
}
