using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBasicApp.ViewModel
{
    public class LoaiVM
    {
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
    }
}
