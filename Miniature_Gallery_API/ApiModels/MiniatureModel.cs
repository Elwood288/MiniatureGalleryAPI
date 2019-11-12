using Miniature_Gallery_API.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Miniature_Gallery_API.ApiModels
{
    public class MiniatureModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Game { get; set; }
        [Required]
        public string[] Keywords { get; set; }
    }
}
