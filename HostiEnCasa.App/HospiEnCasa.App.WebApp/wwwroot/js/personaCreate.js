$().ready(function() {

    $("#form-registro").on('submit', function(e){
        //e.preventDefault();        
    });

    $("#form-registro").validate({
        //errorClass: "invalid",
        //validClass: "success",
        rules: {
            nombre : {
                required: true,
                minlength: 3,
                maxlenght: 50,
            },
            apellido : {
                required: true,
                minlength: 3,
                maxlenght: 50,
            },
            telefono: {
                required: true,
                number: true,
                min: 3000000000,
                max: 3999999999,
            },
            genero: {
                required: true,
            },
            discriminador: {
                required: true,
            },
        },
        messages : {
            nombre: {
                required: "El nombre es requerido",
                minlength: "El nombre debe tener mínimo 3 caracteres",
                maxlength: "El nombre debe tener máximo 50 caracteres",
            },
            apellido: {
                required: "El apellido es requerido",
                minlength: "El apellido debe tener mínimo 3 caracteres",
                maxlength: "El apellido debe tener máximo 50 caracteres",
            },
            telefono: {
                required: "El número de teléfono es requerido",
                number: "Debe ingresar solo números",
                min: "El número teléfonico debe ser mayor a 3000000000",
                max: "El número teléfonico debe ser menor a 3999999999",
            },
            genero: {
                required: "El genero es requerido",
            },
            discriminador: {
                required: "El discriminador es requerido",
            },
        },
        /*submitHandler: function(form) {
            form.submit();
        }*/
    });

});