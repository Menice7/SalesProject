#pragma checksum "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50636688da0ada17f0847fd0b3b330f92d2b8576"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Anbar_Export), @"mvc.1.0.view", @"/Views/Anbar/Export.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\_ViewImports.cshtml"
using mvc_2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\_ViewImports.cshtml"
using mvc_2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50636688da0ada17f0847fd0b3b330f92d2b8576", @"/Views/Anbar/Export.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f305b3896de38acc5471f1381f48927dbb13f61", @"/Views/_ViewImports.cshtml")]
    public class Views_Anbar_Export : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Anbar>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h3 class=""text-center text-uppercase"">Məhsullar</h3>


<table class=""table table-bordered"" id=""example"">
    <thead class=""thead-dark"">
        <tr>
            <th>Ad</th>
            <th>Daxili Kod</th>
            <th>Xarici Kod</th>
            <th>Növ</th>
            <th>Ölkə</th>
            <th>Say</th>
            <th>Topdan Satış Qiyməti</th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
         foreach (var anbar in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.Daxili_Kod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.Xarici_Kod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.NovAd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.OlkeAd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.Say);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
               Write(anbar.Topdan_Satis_Qiymeti);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Asus\Desktop\mehsul_project\mvc-2\mvc-2\Views\Anbar\Export.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>

</table>

<script type=""text/javascript"" src=""https://code.jquery.com/jquery-3.5.1.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/1.11.4/js/jquery.dataTables.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/dataTables.buttons.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/buttons.html5.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/buttons.print.min.js""></script>

<script type=""text/javascript"">

    $('#example').DataTable({
        dom: 'Bfrtip',
        buttons: [");
            WriteLiteral(@"
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        ""searching"": true,
        ""paging"": true,
        ""order"": [[0, ""asc""]],
        ""ordering"": true,
        ""columnDefs"": [{
            ""targets"": [3],
            ""orderable"": false
        }]


    });

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Anbar>> Html { get; private set; }
    }
}
#pragma warning restore 1591
