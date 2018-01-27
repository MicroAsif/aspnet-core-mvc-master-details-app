$(document).ready(function () {

    //add button event
    $("#btnAdd").on('click', function () {
        var productId = $('#Product').val();
        var productName = $("#Product option:selected").text();
        var price = $("#Price").val();
        var quantity = $("#Quantity").val();
        var amount = $("#Amount").val();

        var row = `<tr>
                    <td>${productId}</td>
                    <td>${productName}</td>
                    <td>${price}</td>
                    <td>${quantity}</td>
                    <td>${amount}</td>
                    <td>
                        <a class="btn btn-danger btnDelete">
                            <span class="glyphicon glyphicon-trash"></span>
                        </a>
                    </td>
                </tr>`;

        $('#Items').append(row);
        console.log(row);
    });

    //remove button click event
    $('#Items').on('click', '.btnDelete', function () {
        $(this).parents('tr').remove();
    });

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


    //customer details
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

    ////get products by categoryId
    $('#Category').change(function () {
        console.log($("#Category option:selected").val());
        $('#Product').empty();
        
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

  
});

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



