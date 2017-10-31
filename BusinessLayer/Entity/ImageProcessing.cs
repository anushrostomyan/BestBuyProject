using DataAccessLayer.DataAccess;
using Microsoft.AspNetCore.Http;
//using SixLabors.ImageSharp;
//using SixLabors.ImageSharp.Formats;
//using SixLabors.ImageSharp.Helpers;
//using SixLabors.ImageSharp.Processing;
//using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class ImageProcessing
    {
        public byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }

        public string Getbase64(byte[] byteimage)
        {
            string s = Convert.ToBase64String(byteimage);

            return s;
        }
    }
}
