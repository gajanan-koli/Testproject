using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCM.Domain.Models
{
    public class Notes
    {
        public int NoteId { get; set; }
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="title should be upto 50 characters.")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CreateByUserId { get; set; }
        [Required]
        public int UpdateByUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
