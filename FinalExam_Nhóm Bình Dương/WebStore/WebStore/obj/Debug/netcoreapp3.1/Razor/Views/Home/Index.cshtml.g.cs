#pragma checksum "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b43c7d2f4fd87239c02fc0e5b1ac938eeb87c0e0868b45f60b7f268ee515744f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\_ViewImports.cshtml"
using WebStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
using WebStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b43c7d2f4fd87239c02fc0e5b1ac938eeb87c0e0868b45f60b7f268ee515744f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"0ca74d9d3d8f0fda11e57151523a5ee9557a88a1c5aba4211246523de85a92d1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""main"">
    <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
        <ol class=""carousel-indicators"">
            <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
            <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
            <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
        </ol>
        <div class=""carousel-inner"">
            <div class=""carousel-item active"">
                <img class=""d-block w-100"" src=""images/slider-image-1-1920x700.jpg"" alt=""First slide"">
            </div>
            <div class=""carousel-item"">
                <img class=""d-block w-100"" src=""images/slider-image-2-1920x700.jpg"" alt=""Second slide"">
            </div>
            <div class=""carousel-item"">
                <img class=""d-block w-100"" src=""images/slider-image-3-1920x700.jpg"" alt=""Third slide"">
            </div>
        </div>
        <a class=""carousel-control-prev"" hre");
            WriteLiteral(@"f=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>

    <br>
    <br>

    <div class=""inner"">
        <!-- About Us -->
        <header id=""inner"">
            <h1>Chào mừng các bạn đến với website chúng tôi</h1>
            <p>Sách là kho báu vô tận, là đúc kết những tinh hoa, tri thức của cả nhân loại, là sự kết tinh của lớp lớp thế hệ. Sở hữu một cuốn sách hay chính là chìa khóa quyền năng để chúng ta có thể chinh phục được những khó khăn, thử thách phía trước nhằm vươn đến thành công.</p>
        </header>

        <br>

        <h2 class=""h2"">Featured Products</h2>

       ");
            WriteLiteral(" <!-- Products -->\r\n        <section class=\"tiles\">\r\n");
#nullable restore
#line 52 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
             foreach (var item in Model.book)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <article class=\"style1\">\r\n                    <span class=\"image\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2362, "\"", 2386, 2);
            WriteAttributeValue("", 2368, "images/", 2368, 7, true);
#nullable restore
#line 56 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 2375, item.Image, 2375, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2387, "\"", 2393, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"300\" height=\"325\" />\r\n                    </span>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2475, "\"", 2538, 1);
#nullable restore
#line 58 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 2482, Url.Action("Details", "Book", new {id = @item.BookID }), 2482, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h2>\r\n                            ");
#nullable restore
#line 60 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
                       Write(item.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h2>\r\n\r\n                        <p><del>");
#nullable restore
#line 63 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</del> <strong>");
#nullable restore
#line 63 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
                                                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</strong></p>\r\n                    </a>\r\n                </article>\r\n");
#nullable restore
#line 66 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </section>\r\n\r\n        <p class=\"text-center\"><a");
            BeginWriteAttribute("href", " href=\"", 2861, "\"", 2896, 1);
#nullable restore
#line 69 "C:\Users\LENOVO YOGA\source\repos\WebStore\WebStore\Views\Home\Index.cshtml"
WriteAttributeValue("", 2868, Url.Action("Index", "Book"), 2868, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">More Books &nbsp;<i class=\"fa fa-long-arrow-right\"></i></a></p>\r\n\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
