﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Miniature_Gallery_API.Core.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Miniature")]
        public int MiniatureId { get; set; }
    }
}
