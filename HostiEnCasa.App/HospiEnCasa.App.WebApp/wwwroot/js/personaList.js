$().ready(function(){
    
    $("#eliminar").click(function(){
        $('#modalEliminar').modal('show');
    });

    $("#actualizar").click(function(){

        //Colocar datos seleccionados al modal
        $("#nombre").val("Juan Carlos");
        $("#apellido").val("Zambrano");
        $("#telefono").val("31298765432");

        $('#modalEditar').modal('show');
    });

});