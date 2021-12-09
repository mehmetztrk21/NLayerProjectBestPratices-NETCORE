﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProjectBestPratices.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} alanı boş olamaz.")]
        [Display(Name="Kategori Adı")]
        public string Name { get; set; }
    }
}
