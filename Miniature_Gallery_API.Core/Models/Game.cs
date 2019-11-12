using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Miniature_Gallery_API.Core.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<string> Attributes { get; set; }
        IEnumerable<Miniature> miniatures { get; set; }
        
    }
}
