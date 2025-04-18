﻿using System.ComponentModel.DataAnnotations;

namespace Blog_App.Dto.Request
{
    public class PostRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Content { get; set; }
    }
}
