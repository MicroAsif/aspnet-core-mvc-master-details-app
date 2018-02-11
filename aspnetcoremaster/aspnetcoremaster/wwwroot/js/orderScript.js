$(document).ready(function () {

     //submit btn event

    $("#btnSubmit").click(function () {

        var list = [];
        $('#Items tr').each(function (index, ele) {
            var orderItem = {
                ProductId: $('.productId', this).text(),
                Product: $('.productName', this).text(),
                Price: parseInt($('.price', this).text()),
                Quantity: parseInt($('.quantity', this).text()),
                TotalPrice: parseFloat($('.amount', this).text())
            };
            list.push(orderItem);
        });
        console.log(list);
        $.ajax({
            type: 'POST',
            url: '/Home/Order',
            datatype: "Json",
            data: {
                CustomerId: parseInt($("#Customer").val()),
                InventoryCode: $("#InventoryCode").val(),
                CreatedDate: $("#InventoryDate").val(),
                Status: $("#Status").val(),
                TotalAmount: parseFloat($("#TotalAmount").val()),
                GivenAmount: parseFloat($("#GivenAmount").val()),
                ChangeAmount: parseFloat($("#ChangeAmount").val()), 
                InventoryItems: list
            },
            success: function () {
                //alert('Successfully saved');
            },
            error: function (error) {
                console.log(error);
            }
        });
    });


    //add button event
    $("#btnAdd").on('click', function () {
        var productId = $('#Product').val();
        var productName = $("#Product option:selected").text();
        var price = $("#Price").val();
        var quantity = $("#Quantity").val();
        var amount = $("#Amount").val();

        var row = `<tr>
                    <td class="productId">${productId}</td>
                    <td class="productName">${productName}</td>
                    <td class="price">${price}</td>
                    <td class="quantity">${quantity}</td>
                    <td class="amount">${amount}</td>
                    <td>
                        <a class="btn btn-danger btn-sm btnDelete">
                            <span class="glyphicon glyphicon-trash"></span>
                        </a>
                    </td>
                </tr>`;

        $('#Items').append(row);
        calculateSum();
        //clearValue();
    });

    //remove button click event
    $('#Items').on('click', '.btnDelete', function () {
        $(this).parents('tr').remove();
        calculateSum();
    });

    //get customer
    $.ajax({
        type: "GET",
        url: "/Home/Customers",
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
              
                $('#Product').append('<option value="' + value.id + '">' + value.name + '</option>');
            });
        }
    });

    ////get products by categoryId
    $('#Category').change(function () {
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


    //total calculation
    function calculateSum() {
        var sum = 0;
        // iterate through each td based on class and add the values
        $(".amount").each(function () {

            var value = $(this).text();
            // add only if the value is number
            if (!isNaN(value) && value.length !== 0) {
                sum += parseFloat(value);
            }
        });

        $('#TotalAmount').val(sum);
        var a = $('#TotalAmount').val();
        var b = $('#GivenAmount').val();
        $('#ChangeAmount').val(a - b);
    };

    $('.amount').each(function () {
        calculateSum();
    });

    // change amount
    $('#GivenAmount').keyup(function () {
        var a = $('#TotalAmount').val();
        var b = $('#GivenAmount').val();
        $('#ChangeAmount').val(a - b);
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
            $.each(data, function (index, value) {
                $("#Price").val(value.price);
                $("#Description").val(value.description);
            });

        }
    });
}



