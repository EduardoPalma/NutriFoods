﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? AlsoCalled { get; set; }
        public bool IsCalculated { get; set; }
        public int Essentiality { get; set; }
        public int SubtypeId { get; set; }

        public virtual NutrientSubtype Subtype { get; set; } = null!;
    }
}