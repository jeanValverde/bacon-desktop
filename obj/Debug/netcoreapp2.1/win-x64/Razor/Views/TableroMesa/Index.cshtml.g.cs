#pragma checksum "C:\Users\totor\bacon-desktop\Views\TableroMesa\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba13ac7aed5c7b8ca08ee6481af520b4fe56ce5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TableroMesa_Index), @"mvc.1.0.view", @"/Views/TableroMesa/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TableroMesa/Index.cshtml", typeof(AspNetCore.Views_TableroMesa_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba13ac7aed5c7b8ca08ee6481af520b4fe56ce5b", @"/Views/TableroMesa/Index.cshtml")]
    public class Views_TableroMesa_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 5622, true);
            WriteLiteral(@"<bacon class=""task-bacon"">


    <div class=""row"">
        <button onclick=cargarMesaHab() type=""button"" class=""btn btn-primary btn-lg btn-block mt-2""> Mesas Habilitadas </button>
        <button onclick=cargarMesaDesb() type=""button"" class=""btn btn-primary btn-lg btn-block mt-2""> Mesas Deshabilitadas </button>
        <button onclick=cargarMesaEsp() type=""button"" class=""btn btn-primary btn-lg btn-block mt-2""> Mesas En Espera </button>
    </div>


    <div class=""card-columns"" id=""target-ord-mesaHabilitada"" style=""column-count: 4"">

    </div>

    <script type=""text/javascript"">

        function mesaHabilitadaIndex() {
            cargarMesaHab();
            cargarMesaDesb();
            cargarMesaEsp();
            timer = false;
        }

        function cargarMesaHab() {
            ipcRenderer.send(""async-MesaHabilitada"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
        }

        ipcRenderer.on('asy");
            WriteLiteral(@"nchronous-reply-MesaHabilitada', (event, arg) => {

            console.log(arg);

            let mesasHab = """";

            document.getElementById('target-ord-mesaHabilitada').innerHTML = """";

            for (var i = 0; i < arg.length; i++) {

                mesasHab += ""<div class='card'><div class='card-body'><div><h5> Numero de mesa <div class='badge badge-pill badge-primary'>"" + arg[i].numeroMesa +
                    ""</div ></h5 ><h5> Cantidad de Asientos <div class='badge badge-pill badge-primary'>"" + arg[i].cantidadAsientosMesa +
                    ""</div> </h5><h5> Estado Mesa <div class='badge badge-pill badge-primary'>"" + arg[i].estadoMesa + ""</div> </h5> <button onclick='modificarMesa("" + arg[i].idMesa + "",2)' type='button' class='btn btn-primary btn-lg btn-block mt-2'> Deshabilitar Mesa </button><button onclick='modificarMesa("" + arg[i].idMesa + "",3)' type='button' class='btn btn-primary btn-lg btn-block mt-2'> Mesa En Espera </button></div></div></div>"";
            }

    ");
            WriteLiteral(@"        document.getElementById('target-ord-mesaHabilitada').innerHTML = mesasHab;

            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

        });

        function cargarMesaDesb() {
            ipcRenderer.send(""async-MesasDeshabilitadass"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
        }

        ipcRenderer.on('asynchronous-reply-MesasDeshabilitadasss', (event, arg) => {

            console.log(arg);

            let mesasHab = """";

            document.getElementById('target-ord-mesaHabilitada').innerHTML = """";

            for (var i = 0; i < arg.length; i++) {

                mesasHab += ""<div class='card'><div class='card-body'><div><h5> ID Cliente <div class='badge badge-pill badge-primary'>"" + arg[i].idCliente + 
                    ""</div ></h5 ><h5> Nombre <div class='badge badge-pill badge-primary'>"" + arg[i].nombre + 
                    """);
            WriteLiteral(@"</div ></h5 ><h5> fecha Ingreso <div class='badge badge-pill badge-primary'>"" + arg[i].fechaIngreso + 
                    ""</div ></h5 ><h5> Numero Mesa <div class='badge badge-pill badge-primary'>"" + arg[i].mesa.numeroMesa + 
                    ""</div ></h5 ><h5> Cantidad de Asientos <div class='badge badge-pill badge-primary'>"" + arg[i].mesa.cantidadAsientosMesa + 
                    ""</div> </h5><h5> Estado Mesa <div class='badge badge-pill badge-primary'>"" + arg[i].mesa.estadoMesa + ""</div> </h5></div></div></div>"";
            }

            document.getElementById('target-ord-mesaHabilitada').innerHTML = mesasHab;

            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

        });

        function cargarMesaEsp() {
            ipcRenderer.send(""async-MesaEspera"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
        }

        ipcRenderer.on('asynchronous-reply-");
            WriteLiteral(@"MesaEspera', (event, arg) => {

            console.log(arg);

            let mesasHab = """";

            document.getElementById('target-ord-mesaHabilitada').innerHTML = """";

            for (var i = 0; i < arg.length; i++) {

                mesasHab += ""<div class='card'><div class='card-body'><div><h5> Numero de mesa <div class='badge badge-pill badge-primary'>"" + arg[i].numeroMesa +
                    ""</div ></h5 ><h5> Cantidad de Asientos <div class='badge badge-pill badge-primary'>"" + arg[i].cantidadAsientosMesa +
                    ""</div> </h5><h5> Estado Mesa <div class='badge badge-pill badge-primary'>"" + arg[i].estadoMesa + ""</div> </h5></div></div></div>"";
            }

            document.getElementById('target-ord-mesaHabilitada').innerHTML = mesasHab;

            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

        });

        function modificarMesa(idMesa, estado_mesa) {

            var datos = [{ ""id_mesa"": ");
            WriteLiteral(@"idMesa, ""estado_mesa"": estado_mesa }];

            ipcRenderer.send('async-ModificarMesa', datos);
            var loader = document.getElementById('loader');
            loader.style.visibility = '';

        }

        ipcRenderer.on('asynchronous-reply-ModificarMesa', (event, arg) => {

            cargarMesaHab();

            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

        });






    </script>




</bacon>");
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