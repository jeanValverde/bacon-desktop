/*
 * Este codigo valida cualquier formulario con Bootstrap
 * Para usar esto debes cambiar en la linea 8 el name por el name de tu formulario
 * Las visualización de las validaciones se realizan con bootstrap, con clases como is-valid o is-invalid
 * Para realizar correctamente la validación del rut debes cambiar el id de la linea 296 por el id del input RUT que tu prefieras
 * Para realizar correctamente la validación del file y visualizar su preview debes asignar al img un id llamado imagePreview o cambiarlo en la linea 264 por el que prefieras
 * Nota: el validar contraseña debe estar un input abajo de otro
 */
function validatorForms(formulario) {

    console.log(formulario);
    /**
     *
     * @param {Elements} rut
     * @returns Void - Cambia el valor del input del RUT por formato xx.xxx.xxx-x
     */

    /*
     *
     * @param {Elemnts} RUT
     * @returns TRUE (El rut ingresado es valido) / FALSE (El  rut es invalido)
     */

    /*
     *
     * @param Elements elemento
     * @returns TRUE (correo valido) / FALSE (Correo invalido)
     */
    function valida_Rut(Objeto) {

    }
    function validarEmail(elemento) {
        var texto = document.getElementById(elemento.id).value;
        var regex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
        if (!regex.test(texto)) {
            //correo invalido
            return false;
        } else {
            //correo valido
            return true;
        }
    }
    /*
     *
     * @param Elements elemento
     * @returns TRUE (Campo VALIDO) / FALSE (campo vacio INVALIDO)
     */
    function validarVacio(elemento) {
        var texto = document.getElementById(elemento.id).value;
        texto = texto.trim();
        if (texto.length == 0 || texto == "") {
            //campo invalido
            return false;
        } else {
            //campo valido
            return true;
        }
    }
    /*
     *
     * @param {Elements} elemento
     * @returns TRUE (Esta selecconado) / FALSE (Es invalido, no seleccionado)
     */
    function validadCheckbox(elemento) {
        var isChecked = elemento.checked;
        if (isChecked) {
            return true;
        } else {
            return false;
        }
    }
    /*
     *
     * @param {String} e
     * @returns {Boolean} TRUE (Si es numero) / FALSE (Si no es numero)
     */
    function validarSiNumero(elemento) {
        var g = parseInt(elemento.value);
        if (Number.isInteger(g)) {
            return true;
        } else {
            return false;
        }
    }

    /*
     *
     * @param {type}
     * @returns {Valida todos los radio de un grupo}
     */
    function validarRadio() {
        var radios = new Array();
        for (var i = 0, max = formulario.elements.length; i < max; i++) {
            if (formulario.elements[i].type == "radio") {
                radios.push(formulario.elements[i].checked);
            }
        }
        var contador = 0;
        for (var i = 0, max = radios.length; i < max; i++) {
            if (radios[i] == true) {
                contador++;
            }
        }
        if (contador == 1) {
            return true;
        } else {
            return false;
        }
    }
    /*
     * @param {Elemento} e
     * @returns {Boolean} TRUE (Si la contraseña es valida) / FALSE (Sino es validas)
     * La contraseña debe tener mínimo 6 caracteres, al menos una mayúscula, al menos una minúscula, al menos un número.
     */
    function validarPassword(elemento) {
        var password = document.getElementById(elemento.id).value;
        if (/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$/.test(password)) {
            return true;
        } else {
            return false;
        }
    }
    /*
     *
     * @param {elementos} e , e2
     * @returns {Boolean} TRUE (iguales) / FALSE (Diferentes invalido)
     */
    function validar_igual_password(e) {
        var elemento = formulario.elements[objeterIndexPasswordValidar()];
        var elementoPass = formulario.elements[objeterIndexPasswordValidar() - 1];
        if (elemento.value == elementoPass.value) {
            formulario.elements[objeterIndexPasswordValidar()].setAttribute("class", "form-control is-valid");
        } else {
            formulario.elements[objeterIndexPasswordValidar()].setAttribute("class", "form-control is-invalid");
            e.preventDefault(e);
        }
    }
    /*
     *
     * @param
     * @returns {El index del segundo input password}
     */
    function objeterIndexPasswordValidar() {
        var indexs = new Array();
        for (var i = 0, max = formulario.elements.length; i < max; i++) {
            if (formulario.elements[i].type == "password") {
                //el siguiente es el que necesitamos
                indexs.push(i);
            }
        }
        var numMax = 0;
        for (var i = 0, max = indexs.length; i < max; i++) {
            if (numMax < indexs[i])
            {
                numMax = indexs[i];
            }
        }
        return numMax;
    }
    /*
     *
     * @param {type}
     * @returns {Void} cambia la clase de los input tipo radio
     */
    function quitarFormatoInvalid() {
        for (var i = 0, max = formulario.elements.length; i < max; i++) {
            if (formulario.elements[i].type == "radio") {
                //el siguiente es el que necesitamos
                formulario.elements[i].setAttribute("class", "custom-control-input");
            }
        }
    }
    /*
     *
     * @param {Elemento} e
     * @returns {Boolean}
     * TRUE (Si el selecciono una opción / FALSE (No se selecciono ninguna opción valida)
     */
    function validarSelectOne(e) {
        var elemento = formulario.elements[e];
        if (elemento.value == "select") {
            return false;
        } else {
            return true;
        }
    }
    /*
     *
     * @param {elemento} e
     * @returns {Boolean}
     * Archivo valido que tenga las extensiones .jpeg / .jpg / .png / .gif solamente.
     */
    function validarInputFile(elemento) {
        var filePath = elemento.value;
        var allowedExtensions = /(.jpg|.jpeg|.png|.gif)$/i;
        if (elemento.value !== null || elemento.value !== "") {
            if (!allowedExtensions.exec(filePath)) {
                elemento.value = '';
                return false;
            } else {
                //Image preview
                if (elemento.files && elemento.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        document.getElementById('imagePreview').src = e.target.result;
                    };
                    reader.readAsDataURL(elemento.files[0]);
                }
                return true;
            }
        } else {
            return false;
        }
    }

    /*
     *
     * @param {type} e
     * @returns  void / Validar y recorrer input pot input y validarlos
     */
    var validar = function (e) {
















        for (var i = 0, max = formulario.elements.length; i < max; i++) {
            //tipo email validador
            if (formulario.elements[i].id == "nombre") {
                if (validarVacio(formulario.elements[i])) {
                    document.getElementById("nombre-mensaje1").setAttribute("style", "display: display");
                    formulario.elements[i].setAttribute("class", "form-control is-valid");
                } else {
                    document.getElementById("nombre-mensaje1").setAttribute("style", "display: block");
                    formulario.elements[i].setAttribute("class", "form-control is-invalid");
                    e.preventDefault(e);
                }
            }
            if (formulario.elements[i].id == "descripcion") {
                if (validarVacio(formulario.elements[i])) {
                    document.getElementById("descripcion-mensaje1").setAttribute("style", "display: display");
                    formulario.elements[i].setAttribute("class", "form-control is-valid");
                } else {
                    document.getElementById("descripcion-mensaje1").setAttribute("style", "display: block");
                    formulario.elements[i].setAttribute("class", "form-control is-invalid");
                    e.preventDefault(e);
                }
            }
            if (formulario.elements[i].id == "unidadMedida") {
                if (validarSelectOne(i)) {
                    document.getElementById("unidad-mensaje1").setAttribute("style", "display: display");
                    formulario.elements[i].setAttribute("class", "custom-select is-valid");
                } else {
                    document.getElementById("unidad-mensaje1").setAttribute("style", "display: block");
                    formulario.elements[i].setAttribute("class", "custom-select is-invalid");
                    e.preventDefault(e);
                }
            }

            if (formulario.elements[i].id == "stock") {
                document.getElementById("stock-mensaje1").setAttribute("style", "display: display");
                if (validarSiNumero(formulario.elements[i])) {
                    var stock = new Number(formulario.elements[i].value);
                    document.getElementById("stock-mensaje2").setAttribute("style", "display: display");
                    formulario.elements[i].setAttribute("class", "form-control is-valid");
                    if (stock < 0) {
                        document.getElementById("stock-mensaje2").setAttribute("style", "display: block");
                        formulario.elements[i].setAttribute("class", "form-control is-invalid");
                        e.preventDefault(e);
                    }
                } else {
                    formulario.elements[i].setAttribute("class", "form-control is-invalid");
                    document.getElementById("stock-mensaje1").setAttribute("style", "display: block");
                    e.preventDefault(e);
                }
            }






            if (formulario.elements[i].id == "stockMinimo") {
                document.getElementById("stockMin-mensaje1").setAttribute("style", "display: display");
                if (validarSiNumero(formulario.elements[i])) {
                    var stockMin = new Number(formulario.elements[i].value);
                    var stock = new Number(formulario.elements["stock"].value);
                    formulario.elements[i].setAttribute("class", "form-control is-valid");
                    document.getElementById("stockMin-mensaje2").setAttribute("style", "display: display");
                    document.getElementById("stockMin-mensaje3").setAttribute("style", "display: display");
                    if (stockMin > stock) {
                        formulario.elements[i].setAttribute("class", "form-control is-invalid");
                        document.getElementById("stockMin-mensaje3").setAttribute("style", "display: block");
                        e.preventDefault(e);
                    } else if (stockMin < 0) {
                        formulario.elements[i].setAttribute("class", "form-control is-invalid");
                        document.getElementById("stockMin-mensaje2").setAttribute("style", "display: block");
                        e.preventDefault(e);
                    }
                } else {
                    formulario.elements[i].setAttribute("class", "form-control is-invalid");
                    document.getElementById("stockMin-mensaje1").setAttribute("style", "display: block");
                    e.preventDefault(e);
                }
            }
            if (formulario.elements[i].id == "stockMaximo") {
                document.getElementById("stockMax-mensaje1").setAttribute("style", "display: display");       
                if (validarSiNumero(formulario.elements[i])) {
                    var stockMax = new Number(formulario.elements[i].value);
                    var stock = new Number(formulario.elements["stock"].value);
                    formulario.elements[i].setAttribute("class", "form-control is-valid");
                    document.getElementById("stockMax-mensaje2").setAttribute("style", "display: display");
                    
                    if (stockMax < stock) {
                        formulario.elements[i].setAttribute("class", "form-control is-invalid");
                        document.getElementById("stockMax-mensaje2").setAttribute("style", "display: block");
                        e.preventDefault(e);
                    }
                } else {
                    formulario.elements[i].setAttribute("class", "form-control is-invalid");
                    document.getElementById("stockMax-mensaje1").setAttribute("style", "display: block");
                    e.preventDefault(e);
                }
            }
            if (formulario.elements[i].id == "foto") {
                    
                if (validarInputFile(formulario.elements[i])) {
                    document.getElementById("foto-mensaje1").setAttribute("style", "display: display");
                    formulario.elements[i].setAttribute("class", "custom-file-input is-valid");
                } else {
                    
                    formulario.elements[i].setAttribute("class", "custom-file-input is-invalid");
                    document.getElementById("foto-mensaje1").setAttribute("style", "display: block");
                    e.preventDefault(e);
                }
            }

            //validar rut
            //Solo cambiar el id por el id del rut de tu formulario




        }
    };


    //cada vez que cambia algún input
    formulario.addEventListener("change", validar);
    //Evento de envio de formulario
    formulario.addEventListener("submit", validar);
}
;
