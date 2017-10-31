using BusinessLayer.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestBuy.CommonModels.ExtensionMethods
{
    public static class HtmlHelpers
    {
        public static HtmlString GetComputerTypeName(IHtmlHelper html, PCType type)
        {
            string typeName = null;
            switch (type)
            {
                case PCType.Desktop:
                    typeName = "Desktop computers list"; 
                break;
                case PCType.Laptop:
                    typeName = "Laptop computers list";
                    break;
                case PCType.ALLInOne:
                    typeName = "All in one computers list";
                    break;
            }

            return new HtmlString(typeName);
        }
    }
}
