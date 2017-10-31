using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.ViewModels.Gaming
{
    public class VideoGameViewModel
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string ColorCategory { get; set; }
        public string Model { get; set; }
        public bool?  Multiplayer { get; set; }
        public string ImageAsBase64 { get; set; }

        public VideoGameViewModel()
        {
        }

        public VideoGameViewModel(string name, string developer, string genre, string platform, string colorCategory,
                                  string model, bool? multiPlayer, string imageAsBase64)
        {
            Name = name;
            Developer = developer;
            Genre = genre;
            Platform = platform;
            ColorCategory = colorCategory;
            Model = model;
            Multiplayer = multiPlayer;
            ImageAsBase64 = imageAsBase64;
        }
    }
}
