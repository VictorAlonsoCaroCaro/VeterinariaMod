$().ready(function(){
    
    /*
    $("#eliminar").click(function(){
        $('#modalEliminar').modal('show');
    });
    
    $("#editar").click(function(){
        $('#modalEditar').modal('show');
    });
    */

    $(document).on('click', '#tablePersonas tbody tr td a.btn.btn-secondary', function(){
        $('#modalEliminar').modal('show');
    });

    $(document).on('click', '#tablePersonas tbody tr td a.btn.btn-primary', function(){
        $(this).parent().parent().find('td').each(function(index){
            switch(index){
                case 0:
                    $('#Id').val($(this).text());
                    break;
                case 1:
                    $('#nombre').val($(this).text());
                    break;
                case 2:
                    $('#apellido').val($(this).text());
                    break;
                case 3:
                    $('#telefono').val($(this).text());
                    break;
                case 4:
                    $('#genero').val($(this).text());
                    break;
            }
        });

        $('#modalEditar').modal('show');

    });

    $("#btnActualizar").click(function(){
        //Validar datos

        /* Enviar petición AJAX datos crudos*/
        /*
        $.ajax({
            type: "POST",
            url: "/GestionPersonas/List?handler=Update",
            contentType: "application/html; charset=utf-8",
            dataType: "html",
            headers: {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            data: $('#formEditar').serialize(),
        })
        .done(function (result) {
            alert(result);
        })
        .fail(function (error) {
            alert(error);
        });
        */

        var genero = ($("#genero").val() == "Femenino" ? 0 : 1);

        /* Enviar petición AJAX datos JSON */
        var persona = { "Id": $("#Id").val(), "Nombre": $("#nombre").val(), "Apellidos": $("#apellido").val(), "NumeroTelefono": $("#telefono").val(), "Genero": genero };

        $.ajax({
            type: "POST",
            url: "/GestionPersonas/List?handler=UpdateJson",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            headers: {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            data: JSON.stringify(persona),
        })
        .done(function (result) {
            alert(result);
            console.log(result);
            location.reload();
        })
        .fail(function (error) {
            console.log(result);
            alert(error);
        });

    });

});