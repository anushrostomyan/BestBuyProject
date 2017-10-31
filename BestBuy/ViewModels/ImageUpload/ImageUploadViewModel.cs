using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Test
{
    public class ImageUploadViewModel
    {
      public IFormFile Image { get; set; }
    }
}
