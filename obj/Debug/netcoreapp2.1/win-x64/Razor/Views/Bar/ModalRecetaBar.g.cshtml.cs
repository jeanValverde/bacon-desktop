#pragma checksum "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "335fefbe1f59f55c8898ab80c0af29151c95543f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bar_ModalRecetaBar), @"mvc.1.0.view", @"/Views/Bar/ModalRecetaBar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bar/ModalRecetaBar.cshtml", typeof(AspNetCore.Views_Bar_ModalRecetaBar))]
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
#line 19 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
using bacon_desktop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"335fefbe1f59f55c8898ab80c0af29151c95543f", @"/Views/Bar/ModalRecetaBar.cshtml")]
    public class Views_Bar_ModalRecetaBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/mdi/css/materialdesignicons.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/flag-icon-css/css/flag-icon.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/css/vendor.bundle.base.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/vertical-layout-light/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/js/vendor.bundle.base.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/off-canvas.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/hoverable-collapse.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/template.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/settings.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/todolist.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/loginform.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 18, true);
            WriteLiteral("<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(18, 695, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a4abe01401d471297f4afea0630f560", async() => {
                BeginContext(24, 220, true);
                WriteLiteral("\r\n    <!-- Required meta tags -->\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <title>BACON Restaurante</title>\r\n    <!-- base:css -->\r\n    ");
                EndContext();
                BeginContext(244, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bf55b881380141c6a70b96039c0a2a4e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(320, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(326, 76, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dcca3eb499e84a21a49d17e93431cc79", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(402, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(408, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "433512592a0740bd90bb7082b5edc429", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(475, 137, true);
                WriteLiteral("\r\n    <!-- endinject -->\r\n    <!-- plugin css for this page -->\r\n    <!-- End plugin css for this page -->\r\n    <!-- inject:css -->\r\n    ");
                EndContext();
                BeginContext(612, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5c81729d8b3946b38dedef97d457f541", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(680, 26, true);
                WriteLiteral("\r\n    <!-- endinject -->\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(713, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 20 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
  

    Receta receta = (Receta)ViewData["recetaB"];
    List<Ingrediente> ingredientes = (List<Ingrediente>)ViewData["ingredientesB"];

    string foto = "https://baconappimagenes.s3-sa-east-1.amazonaws.com/" + receta.Foto;

#line default
#line hidden
            BeginContext(981, 4822, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "814437eab443438b937f9062a80196d3", async() => {
                BeginContext(996, 589, true);
                WriteLiteral(@"
    <div class="""">
        <!-- partial:../../partials/_navbar.html -->
        <!-- partial -->
        <div class="""">
            <!-- partial:../../partials/_settings-panel.html -->
            <!-- partial -->
            <!-- partial:../../partials/_sidebar.html -->
            <!-- partial -->
            <div class=""main-panel"">
                <div class=""content-wrapper"">
                    <div class=""col-md-12"">
                        <div class=""card"">
                            <div class=""card-body text-center"">
                                <div>
");
                EndContext();
#line 42 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                     if (receta.Foto != "")
                                    {

#line default
#line hidden
                BeginContext(1685, 44, true);
                WriteLiteral("                                        <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1729, "\"", 1740, 1);
#line 44 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
WriteAttributeValue("", 1735, foto, 1735, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1741, 58, true);
                WriteLiteral(" class=\"img-lg rounded-circle mb-2\" alt=\"profile image\">\r\n");
                EndContext();
#line 45 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
                BeginContext(1919, 142, true);
                WriteLiteral("                                        <img src=\"https://via.placeholder.com/92x92\" class=\"img-lg rounded-circle mb-2\" alt=\"profile image\">\r\n");
                EndContext();
#line 49 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                    }

#line default
#line hidden
                BeginContext(2100, 40, true);
                WriteLiteral("                                    <h4>");
                EndContext();
                BeginContext(2141, 19, false);
#line 50 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                   Write(receta.NombreReceta);

#line default
#line hidden
                EndContext();
                BeginContext(2160, 72, true);
                WriteLiteral("</h4>\r\n                                    <p class=\"text-muted mb-0\"># ");
                EndContext();
                BeginContext(2233, 18, false);
#line 51 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                                            Write(ViewData["DatosB"]);

#line default
#line hidden
                EndContext();
                BeginContext(2251, 71, true);
                WriteLiteral("</p>\r\n                                    <p class=\"text-muted mb-0\">\r\n");
                EndContext();
                BeginContext(2457, 77, true);
                WriteLiteral("                                        <div class=\"badge badge-primary\">ID: ");
                EndContext();
                BeginContext(2535, 18, false);
#line 54 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                                                        Write(ViewData["DatosB"]);

#line default
#line hidden
                EndContext();
                BeginContext(2553, 93, true);
                WriteLiteral("</div>\r\n                                        <div class=\"badge badge-primary\">Estimación: ");
                EndContext();
                BeginContext(2647, 30, false);
#line 55 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                                                                Write(receta.CantidadPrepacionDiaria);

#line default
#line hidden
                EndContext();
                BeginContext(2677, 91, true);
                WriteLiteral("</div>\r\n                                        <div class=\"badge badge-primary\">Duracion: ");
                EndContext();
                BeginContext(2769, 26, false);
#line 56 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                                                              Write(receta.DuracionPreparacion);

#line default
#line hidden
                EndContext();
                BeginContext(2795, 190, true);
                WriteLiteral(" min</div>\r\n                                    </p>\r\n                                </div>\r\n                                <p class=\"mt-2 card-text\">\r\n                                    ");
                EndContext();
                BeginContext(2986, 24, false);
#line 60 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                               Write(receta.DescripcionReceta);

#line default
#line hidden
                EndContext();
                BeginContext(3010, 734, true);
                WriteLiteral(@"
                                </p>
                                <a id=""close"" class=""btn btn-info btn-sm mt-3 mb-4"" href=""javascript:window.close()"">Cerrar la ventana</a>
                                <div class=""template-demo"">
                                    <table class=""table mb-0"">
                                        <thead>
                                            <tr>
                                                <th class=""pl-0"">Nombre del Insumo</th>
                                                <th class=""text-right"">Cantidad (KG)</th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
                EndContext();
#line 72 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                             foreach (var ingrediente in ingredientes)
                                            {

#line default
#line hidden
                BeginContext(3879, 123, true);
                WriteLiteral("                                                <tr>\r\n                                                    <td class=\"pl-0\">");
                EndContext();
                BeginContext(4003, 31, false);
#line 75 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                                                Write(ingrediente.Insumo.NombreInusmo);

#line default
#line hidden
                EndContext();
                BeginContext(4034, 151, true);
                WriteLiteral("</td>\r\n                                                    <td class=\"pr-0 text-right\"><div class=\"badge badge-pill badge-outline-primary text-center\">");
                EndContext();
                BeginContext(4186, 20, false);
#line 76 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                                                                                                                           Write(ingrediente.Cantidad);

#line default
#line hidden
                EndContext();
                BeginContext(4206, 68, true);
                WriteLiteral("</div></td>\r\n                                                </tr>\r\n");
                EndContext();
#line 78 "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Bar\ModalRecetaBar.cshtml"
                                            }

#line default
#line hidden
                BeginContext(4321, 988, true);
                WriteLiteral(@"                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <style type=""text/css"">
                    .content-wrapper {
                        padding: 0px;
                    }

                    .col-md-12 {
                        padding: 0px;
                    }

                    .card {
                        padding: 0px;
                        border-radius: 0px;
                    }
                </style>
                <!-- content-wrapper ends -->
                <!-- partial:../../partials/_footer.html -->
                <!-- partial -->
            </div>
            <!-- main-panel ends -->
        </div>
        <!-- page-body-wrapper ends -->
    </div>
    <!-- container-scroller
    <!-- base:js -->
    ");
                EndContext();
                BeginContext(5309, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26d374c6fd614cd5826fe0c0b4f2c4cc", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5367, 132, true);
                WriteLiteral("\r\n    <!-- endinject -->\r\n    <!-- Plugin js for this page-->\r\n    <!-- End plugin js for this page-->\r\n    <!-- inject:js -->\r\n    ");
                EndContext();
                BeginContext(5499, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "202f7767783d4f71bbc06b3130707057", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5541, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5547, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b9714ffaf1d46b69ab9342e062aa1d7", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5597, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5603, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84e27e10ad1042e5ab5abb4ca394b9cd", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5643, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5649, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dd2ca0f38c04f338dfbe09f7a13a050", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5689, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5695, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8609615e2ce64e8ba1a4f2859cec9168", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5735, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(5743, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2792f90802645fd9fba67720dc18ad7", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5788, 8, true);
                WriteLiteral("\r\n\r\n\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5803, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
