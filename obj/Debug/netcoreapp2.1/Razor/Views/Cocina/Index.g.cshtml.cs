<<<<<<< HEAD
<<<<<<< HEAD:obj/Debug/netcoreapp2.1/Razor/Views/Cocina/Index.g.cshtml.cs
#pragma checksum "C:\Proyecto bacon\bacon-desktop-malo\Views\Cocina\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a654bcde46e025a50cf38fc0e57602656b1fdb2c"
=======
#pragma checksum "C:\Users\totor\bacon-desktop\Views\Cocina\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a654bcde46e025a50cf38fc0e57602656b1fdb2c"
>>>>>>> Alejandro:obj/Debug/netcoreapp2.1/Razor/Views/Cocina/Index.cshtml.g.cs
=======
#pragma checksum "C:\Proyecto bacon\bacon-escritorio-ultimo\bacon-desktop\Views\Cocina\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a654bcde46e025a50cf38fc0e57602656b1fdb2c"
>>>>>>> Felipe
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cocina_Index), @"mvc.1.0.view", @"/Views/Cocina/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cocina/Index.cshtml", typeof(AspNetCore.Views_Cocina_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a654bcde46e025a50cf38fc0e57602656b1fdb2c", @"/Views/Cocina/Index.cshtml")]
    public class Views_Cocina_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 8112, true);
            WriteLiteral(@"<bacon class=""task-bacon"">
    <!--inicio row-->
    <div class=""row"">
        <div class=""col-md-3 grid-margin"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Totalidad de recetas ordenadas</h4>
                    <div class=""template-demo"">
                        <table class=""table mb-0"">
                            <thead>
                                <tr>
                                    <th class=""pl-0"">Receta</th>
                                    <th class=""text-right"">Cantidad</th>
                                </tr>
                            </thead>
                            <tbody id=""target-ord-cocina-cantidad"" >
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div class=""col-md-9 grid-margin"">

            <div class=""card-columns"" id=""target");
            WriteLiteral(@"-ord-cocina"">
                <!--inicio tarjeta de ordenes--->
                


                <!--fin tarjeta de ordenes--->
            </div>


        </div>
        <!---fin columnas--->
    </div>
    <!--fin row-->


    <script type=""text/javascript"" >

        function cocinaIndex() {
            cargarOrdenes();
            cargarRecetaCantidad();
            timer = true;
        }

         //para cargar las ordenes 
        function cargarOrdenes() {
            //Carga de las ordenes Cocina 
            ipcRenderer.send(""async-receta"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
            ///fin de carga de ordenes 
        }

        ipcRenderer.on('asynchronous-reply-receta', (event, arg) => {

            let message = """";

             document.getElementById('target-ord-cocina').innerHTML = """";

            for (var i = 0; i < arg.length; i++) {

                    var recetas");
            WriteLiteral(@" = """";
                 
                    for (var j = 0; j < arg[i].recetaOrdenada.length ; j++) {

                        recetas += ""<tr><td class='pl-0'  >"" + cortarTextoConPuntos(arg[i].recetaOrdenada[j].receta.nombreReceta,37) + ""</td>""
                            + ""<td class='pr-0 text-center'><div class='badge badge-pill badge-outline-primary'>""
                            + arg[i].recetaOrdenada[j].cantidad + ""</div></td></tr>"";

                    }
                
                message += ""<div class='card'><div class='card-body'><h4 class='card-title mt-3'>Orden número #"" + arg[i].orden.idOrden + ""</h4>""
                    + ""<div class='badge badge-outline-primary mr-1'>Mesa #"" + arg[i].orden.cliente.mesa.numeroMesa +  ""</div>""
                    + ""<div class='badge badge-outline-primary mr-1'>""  + arg[i].orden.tiempoPreparacion + "" minutos</div>""
                    + ""<div class='badge badge-info mr-1'>"" + arg[i].orden.fechaCompleta + ""</div> ""
                    + ""<");
            WriteLiteral(@"div class='badge badge-"" + estadoOrdenStyle(arg[i].orden.fechaCompleta) + "" mr-1'>"" + estadoOrden(arg[i].orden.fechaCompleta) + ""</div> ""
                    + ""<div class='badge badge-info mr-1 mt-1'>"" + calcularMinutos(arg[i].orden.fechaCompleta) + "" minutos</div> ""
                    + ""<br />""
                    + ""<table class='table mb-0'><thead><tr><th class='pl-0'>Receta</th><th class='text-right'>Cantidad</th></tr></thead><tbody>""

                    + recetas 

                    + ""</tbody></table>""
                    + ""<h4 class='card-title mt-3'>Descripción</h4>""
                    + ""<p class='card-text'>"" + arg[i].orden.descripcion + ""</p>""
                    + ""<table class='table mb-0'><thead><tr><th class='text-right'>""
                    + ""<button type='button' onclick='completarOrden("" + arg[i].orden.idOrden  + "")' class='btn btn-outline-success btn-fw'>Orden Lista</button></th>""
                    + ""</tr></thead></table></div></div>"";

            }

          ");
            WriteLiteral(@"  document.getElementById('target-ord-cocina').innerHTML = message;

            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

            cargarTextos();

        });
        //fin para cargar las ordenes 


        //para cargar la cantidad de receta 
         function cargarRecetaCantidad() {
            ipcRenderer.send(""async-receta-cantidad"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
         }


         ipcRenderer.on('asynchronous-reply-receta-cantidad', (event, arg) => {

            let message = """";

            document.getElementById('target-ord-cocina-cantidad').innerHTML = """";                   

            for (var i = 0; i < arg.length; i++) {
                 message += ""<tr><td class='pl-0'><a href='#23423423' onclick='modalReceta( "" + arg[i].receta.idReceta + ""  )' >"" + cortarTextoConPuntos(arg[i].receta.nombreReceta, 34) + ""</a>""
          ");
            WriteLiteral(@"               +  ""</td><td class='pr-0 text-right'><div class='badge badge-pill badge-primary'>"" +  arg[i].cantidad + ""</div></td></tr>"";
            }

            document.getElementById('target-ord-cocina-cantidad').innerHTML = message;
           
            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

        });
        //fin para cargar la cantidad de receta 


        //para completar la orden 
         function completarOrden(idOrden) {
            ipcRenderer.send(""async-receta-completarOrden"", idOrden);
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
         }


         ipcRenderer.on('asynchronous-reply-receta-completarOrden', (event, arg) => {

             cocinaIndex();

        });
        //fin para completar la orden 



        function modalReceta(idReceta) {
            ipcRenderer.send(""modalReceta-window"", idReceta);
        }


        function");
            WriteLiteral(@" cortarTextoConPuntos(texto, limite)
        {
           
          var puntosSuspensivos = ""..."";
          if(texto.length > limite)
          {
            texto = texto.substring(0,limite) + puntosSuspensivos;
          }

            return texto;
        }

        function cargarTextos() {

            var highlightedItems = document.querySelector("".cortarTexto"");

            highlightedItems.forEach(function (userItem) {
                var text = cortarTextoConPuntos(userItem.innerHTML, 6);
                userItem.innerHTML = text;
            });
        }

        function calcularMinutos(fecha) {
            var today = new Date();
            var Christmas = new Date(fecha);
            var diffMs = (Christmas - today); // milliseconds between now & Christmas
            var diffMins = Math.round(((diffMs % 86400000) % 3600000) / 60000); // minutes
            return diffMins * -1;
        }

        function estadoOrden(fecha) {

            var minutos = calcu");
            WriteLiteral(@"larMinutos(fecha);

            var integer = parseInt(minutos, 10);

            var estado = ""Ingresado"";

            if (integer < 15) {
                estado = ""Limite""
            } 

            if (integer < 5) {
                estado = ""Retrasado""
            } 

            return estado;
        }

        function estadoOrdenStyle(fecha) {

            var minutos = calcularMinutos(fecha);

            var integer = parseInt(minutos, 10);
            var estado = ""info"";

            if (integer < 15) {
                estado = ""danger""
            } 

            if (integer < 5) {
                estado = ""Retrasado""
            } 

            return estado;
        }

        
        setInterval(function () {
            if (timer) {
               cargarOrdenes();
               cargarRecetaCantidad();
            }
        }, 60000);


    </script>


</bacon>

");
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
