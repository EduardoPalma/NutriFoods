﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MealType
    {
        public MealType()
        {
            MealMenus = new HashSet<MealMenu>();
            RecipeMealTypes = new HashSet<RecipeMealType>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MealMenu> MealMenus { get; set; }
        public virtual ICollection<RecipeMealType> RecipeMealTypes { get; set; }
    }
}