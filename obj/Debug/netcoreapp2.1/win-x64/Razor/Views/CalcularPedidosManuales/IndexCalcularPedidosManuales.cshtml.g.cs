#pragma checksum "C:\Users\CRISTIAN\Desktop\bacon-desktop\Views\CalcularPedidosManuales\IndexCalcularPedidosManuales.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e5026a0f5abee4ca284a087c8c92298850281b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CalcularPedidosManuales_IndexCalcularPedidosManuales), @"mvc.1.0.view", @"/Views/CalcularPedidosManuales/IndexCalcularPedidosManuales.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CalcularPedidosManuales/IndexCalcularPedidosManuales.cshtml", typeof(AspNetCore.Views_CalcularPedidosManuales_IndexCalcularPedidosManuales))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e5026a0f5abee4ca284a087c8c92298850281b9", @"/Views/CalcularPedidosManuales/IndexCalcularPedidosManuales.cshtml")]
    public class Views_CalcularPedidosManuales_IndexCalcularPedidosManuales : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 13384, true);
            WriteLiteral(@"<bacon class=""task-bacon"">

    <!-- partial -->
    <div class=""email-wrapper wrapper"">
        <div class=""row align-items-stretch"">

            <div class=""mail-list-container col-md-3 pt-4 pb-4 border-right bg-white"">
                <div class=""border-bottom pb-4 mb-3 px-3"">
                    <div class=""form-group"">
                        <input class=""form-control w-100"" type=""search"" placeholder=""Buscar Insumo"" id=""Mail-rearch"">
                    </div>
                </div>
                <div id=""target-insumos"">


                </div>

            </div>
            <div class=""mail-view d-none d-md-block col-md-9 col-lg-9 bg-white"">
                
                <div class=""message-body"">
                    
                    <div style=""visibility:hidden;display:none"" id=""target-cargaInsumos"">
                        <h2>Agregar insumo pedido</h2>
                        <div class=""sender-details"">
                            <img class=""img-sm rounded-ci");
            WriteLiteral(@"rcle mr-3"" id=""imagen"" src=""https://via.placeholder.com/43x43"" alt="""">
                            <input type=""hidden"" id=""IdInsumo"" />
                            <div class=""details"">
                                <p class=""msg-subject"" id=""nombre"">Cacao</p>
                                <p id=""stock"" class=""sender-email"">Stock Actual: 10 Kilos / Stock Minimo: 3 kilos / Stock Maximo: 15 kilos </p>
                            </div>
                        </div>
                        <div class=""sender-details"">
                            <form class=""col-md-12 forms-sample mb-4"">
                                <div class=""form-group"">
                                    <label for=""exampleInputName1"">Cantidad de insumo (kilos/litros)</label>
                                    <input type=""text"" class=""form-control"" id=""cantidadInsumo"" placeholder=""23"">
                                </div>






                                <button onclick=""agregarInsumo()"" class=""btn btn-p");
            WriteLiteral(@"rimary mr-2"">Pedir insumo a administración</button>
                                <button class=""btn btn-behance btn-light"">Cancelar</button>
                            </form>

                        </div>
                    </div>

                    <div style=""visibility:hidden;display:none"" id=""target-modificarInsumos"">
                        <h2>Modificar insumo pedido</h2>
                        <div class=""sender-details"">
                            <img class=""img-sm rounded-circle mr-3"" id=""imagen2"" src=""https://via.placeholder.com/43x43"" alt="""">
                            <input type=""hidden"" id=""IdInsumoPedido2"" />
                            <div class=""details"">
                                <p class=""msg-subject"" id=""nombre2""></p>
                                <p id=""stock2"" class=""sender-email""></p>
                            </div>
                        </div>
                        <div class=""sender-details"">
                            <form class=""col-");
            WriteLiteral(@"md-12 forms-sample mb-4"">
                                <div class=""form-group"">
                                    <label for=""exampleInputName1"">Cantidad de insumo (kilos/litros)</label>
                                    <input type=""text"" class=""form-control"" id=""cantidadInsumo2"" placeholder=""23"">
                                </div>
                                <button onclick=""modificarInsumo()"" class=""btn btn-primary mr-2"">Modificar insumo pedido</button>
                                <button class=""btn btn-behance btn-light"">Cancelar</button>
                            </form>

                        </div>
                    </div>
                    <div class=""message-content"">
                        <div class=""table-responsive"">
                            <table class=""table table-hover"">
                                <thead>
                                    <tr>
                                        <th>Inusmo</th>
                                        ");
            WriteLiteral(@"<th>Nombre Insumo</th>
                                        <th>Cantidad pedida</th>
                                        <th>Medida</th>
                                        <th>Estado</th>
                                        <th>Editar</th>
                                    </tr>
                                </thead>
                                <tbody id=""target-insumosPedidos""></tbody>
                            </table>
                        </div>



                    </div>
                    <div class=""attachments-sections"">

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--fin row-->
    <script type=""text/javascript"">
        timer = false;
        function calcularPedidosManuales() {
            cargarCalcularPedidosManuales();
            cargarInsumosPedidos();
            cargarDatosInsumo();
            timer = true;
        }

        function cargarCalcularPedidosManuales() {
    ");
            WriteLiteral(@"        //Carga de las calcularPedidos
            ipcRenderer.send(""async-cargarVistasCalcularPedidos"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
            ///fin de carga de vistas

        }

        function cargarInsumosPedidos() {
            //Carga de las calcularPedidos
            ipcRenderer.send(""async-cargarVistasInsumosPedidos"", 'buscar');
            var loader = document.getElementById('loader');
            loader.style.visibility = '';
            ///fin de carga de vistas

        }

      


        ipcRenderer.on('asynchronous-reply-cargarVistasCalcularPedidos', (event, arg) => {
            //console.log(arg);
            let vista = """";

            document.getElementById('target-insumos').innerHTML = """";

            for (var i = 0; i < arg.length; i++) {



                vista += ""<div class='mail-list'><div class='form-check'><label class='form-check-label'><input onclick='cargar");
            WriteLiteral(@"Insumos("" + arg[i].idInsumo +"")' name='insumos' type='radio' class='form-check-input'><i class='input-helper'></i></label></div>"" +
                    ""<div class='content'><p class='sender-name'>"" + arg[i].nombreInusmo + ""</p><p class='message_text'>"" + arg[i].stockInsumo + "" "" + arg[i].unidadMedidaInsumo + "" disponibles </p></div></div>"" 
                    


            }


            document.getElementById('target-insumos').innerHTML = vista;
            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';



        });

      
        //Carga del insumo
        function cargarInsumos(idInsumo) {
            
            ipcRenderer.send(""async-cargarVistasInsumosId"", idInsumo);
            var loader = document.getElementById('loader');
        }

        ipcRenderer.on('asynchronous-reply-cargarVistasInsumosId', (event, arg) => {
          
            document.getElementById('target-cargaInsumos').style.visibility = '';
       ");
            WriteLiteral(@"     document.getElementById('target-cargaInsumos').style.display = '';
            document.getElementById('imagen').src = 'https://baconappimagenes.s3-sa-east-1.amazonaws.com/' + arg.foto;
            document.getElementById('nombre').innerHTML = arg.nombreInusmo;
            document.getElementById('stock').innerHTML = ""Stock actual: "" + arg.stockInsumo + arg.unidadMedidaInsumo + "" /Stock Minimo: "" + arg.minStockInsumo + arg.unidadMedidaInsumo + "" /Stock Maximo: "" + arg.maxStockInsumo + arg.unidadMedidaInsumo;  

           
            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';



        });

        ipcRenderer.on('asynchronous-reply-cargarVistasInsumosPedidos', (event, arg) => {
            //console.log(arg);
            let vista = """";

            document.getElementById('target-insumosPedidos').innerHTML = """";

            for (var i = 0; i < arg.length; i++) {



                vista += ""<tr><td class='py-1'><img src='htt");
            WriteLiteral(@"ps://baconappimagenes.s3-sa-east-1.amazonaws.com/"" + arg[i].insumo.foto + ""' alt='image'></td>"" +
                    ""<td>"" + arg[i].insumo.nombreInusmo + ""</td><td>"" + arg[i].cantidadInsumo + ""</td><td>"" + arg[i].insumo.unidadMedidaInsumo + ""</td>"" +
                    ""<td>"";
                if (!arg[i].estadoInsumoPedido) {
                    vista += ""<label id='colorBoton' class='badge badge-danger'>"" + estadoInsumo(arg[i].estadoInsumoPedido) + ""</label>"";
                } else if (Number(arg[i].estadoInsumoPedido) === 1) {
                    vista += ""<label id='colorBoton' class='badge badge-warning'>"" + estadoInsumo(arg[i].estadoInsumoPedido) + ""</label>"";
                } else if (Number(arg[i].estadoInsumoPedido) === 2) {
                    vista += ""<label id='colorBoton' class='badge badge-info'>"" + estadoInsumo(arg[i].estadoInsumoPedido) + ""</label>"";
                }
                
                vista += ""</td ><td><div class='btn-group' role='group' aria-label='Basic exam");
            WriteLiteral(@"ple'>"" +
                    ""<button type='button' id='btnEditar' onclick='cargarInsumoPedidoHaEditar("" + arg[i].idInsumoPedido + "")' class='btn btn-primary'><i class='mdi mdi-table-edit'></i></button></div></td></tr>"";
                
                


            }


            document.getElementById('target-insumosPedidos').innerHTML = vista;
            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';



        });
        
          
        function cargarInsumoPedidoHaEditar(idInsumo) {
            
            console.log(idInsumo);
            ipcRenderer.send(""async-cargarInsumoPedidoHaEditar"", idInsumo);
            
        }

        ipcRenderer.on('asynchronous-reply-cargarInsumoPedidoHaEditar', (event, arg) => {
            document.getElementById('target-cargaInsumos').style.visibility = 'hidden';
            document.getElementById('target-cargaInsumos').style.display = 'none';
            document.getElementById");
            WriteLiteral(@"('target-modificarInsumos').style.visibility = '';
            document.getElementById('target-modificarInsumos').style.display = '';

            console.log(arg);

            document.getElementById('imagen2').src = 'https://baconappimagenes.s3-sa-east-1.amazonaws.com/' + arg.insumo.foto;
            document.getElementById('IdInsumoPedido2').value = arg.idInsumoPedido;
            document.getElementById('nombre2').innerHTML = arg.insumo.nombreInusmo;
            document.getElementById('stock2').innerHTML = ""Stock actual: "" + arg.insumo.stockInsumo +arg.insumo.unidadMedidaInsumo + "" /Stock Minimo: "" + arg.insumo.minStockInsumo + arg.insumo.unidadMedidaInsumo + "" /Stock Maximo: "" + arg.insumo.maxStockInsumo + arg.insumo.unidadMedidaInsumo;
            document.getElementById('cantidadInsumo2').value = arg.cantidadInsumo;


            var loader = document.getElementById('loader');
            loader.style.visibility = 'hidden';

        });

        function estadoInsumo(estadoInsumo) {
            WriteLiteral(@"
            var estado = ""Pendiente"";
            if (estadoInsumo == 0) {
                estado = ""Pendiente"";
            } else if (estadoInsumo == 1) {
                estado = ""A Proveedor"";
            } else if (estadoInsumo == 2) {
                estado = ""Finalizado"";
            }
            return estado;
        }

        function cambiarColor(estadoInsumo) {
           
            if (estadoInsumo == 0) {
                estado = ""danger"";
            } else if (estadoInsumo == 1) {
                estado = ""warning"";
            } else if (estadoInsumo == 2) {
                estado = ""info"";
            }
        }

        function agregarInsumo() {

            var idInsumo = document.getElementById('IdInsumo').value;
            var cantidad = document.getElementById('cantidadInsumo').value;

            

            var datos = [{ ""idInsumo"": idInsumo, ""cantidad"": cantidad }];

            ipcRenderer.send(""async-agregarInsumoPedido"", datos);
         ");
            WriteLiteral(@"    
        }

        ipcRenderer.on('asynchronous-reply-agregarInsumoPedido', (event, arg) => { 

            if (arg === 1) {
                alert('Se agrego insumo pedido')
            } else {
                alert('No se pudo agregar insumo pedido');
            }

            cargarInsumosPedidos();

        });
        function modificarInsumo() {
            var idInsumoPedido2 = document.getElementById('IdInsumoPedido2').value;
            var cantidad = document.getElementById('cantidadInsumo2').value;
            var datos = [{ ""idInsumoPedido"": idInsumoPedido2, ""cantidad"": cantidad }];
            ipcRenderer.send(""async-modificarInsumoPedido"", datos);
        }
         ipcRenderer.on('asynchronous-reply-modificarInsumoPedido', (event, arg) => { 

            if (arg === 1) {
                alert('Se modificó insumo pedido')
            } else {
                alert('No se pudo modificar insumo pedido');
            }

            cargarInsumosPedidos();

      ");
            WriteLiteral("  });\r\n        \r\n\r\n\r\n       \r\n\r\n\r\n\r\n       \r\n\r\n\r\n    </script>\r\n</bacon>");
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