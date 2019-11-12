using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miniature_Gallery_API.Core.Models
{
    public class Miniature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Game { get; set; }
        public IEnumerable<Keyword> Keywords { get; set; }
       
    }
}
