$(document).ready(function () {


  
    //get customer
    $.ajax({
        type: "GET",
        url: "/Home/GetProducts",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                $("#Customer").select2();
                $('#Customer').append('<option value="' + value.id + '">' + value.name + '</option>');
            });
        }
    });

    $("#Customer").select2({
        multiple: false
    });
  
    //get categories
    $.ajax({
        type: "GET",
        url: "/Home/GetCategories",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                console.log(value);
                $('#Category').append('<option value="' + value.id + '">' + value.categoryName + '</option>');
            });
        }
    });

    //get products
    $.ajax({
        type: "GET",
        url: "/Home/GetProducts",
        datatype: "Json",
        success: function (data) {
            $.each(data, function (index, value) {
                // console.log(value);
                $('#Product').append('<option value="' + value.id + '">' + value.name + '</option>');
            });
        }
    });
    $('#Category').change(function () {
        console.log($("#Category option:selected").val());
        $('#Product').empty();
        //get products by categoryId
        $.ajax({
            type: "GET",
            url: "/Home/GetProducts",
            datatype: "Json",
            data: { categoryId: $('#Category').val() },
            success: function (data) {
                $.each(data, function (index, value) {
                    $('#Product').append('<option value="' + value.id + '">' + value.name + '</option>');
                });
                console.log($("#Product option:selected").val());
                LoadProductsData($("#Product option:selected").val());
            }
        });
    });
    $("#Product").change(function () {
        LoadProductsData($("#Product option:selected").val());
    });

    //quantiy chnage event
    $('input[name="Quantity"]').keyup(function () {
        var a = $('input[name="Price"]').val();
        var b = $(this).val();
        $('input[name="Amount"]').val(a * b);
    });



    $('.mydatepicker').datepicker({
        format: 'mm/dd/yyyy'
    });
    //$('#Product').select2();
})

//get products details
function LoadProductsData(id) {
    $('#Price').empty();
    $('#Description').empty();
    $('#Quantity').val("");
    $('#Amount').val("");
    $.ajax({
        type: "GET",
        url: "/Home/GetProductById",
        datatype: "Json",
        data: { productId: id },
        success: function (data) {
            console.log(data);
            $.each(data, function (index, value) {
                $("#Price").val(value.price);
                $("#Description").val(value.description);
            });

        }
    });
}