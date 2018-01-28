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
                Amount: parseFloat($('.amount', this).text())
            }
            list.push(orderItem);
        }); 
        var Data = {
            CustomerId : $("#Customer").val(),
            InventoryCode : $("#InventoryCode").val(),
            InventoryDate : $("#InventoryDate").val(), 
            Status : $("#Status").val(), 
            TotalAmount : $("#TotalAmount").val(), 
            GivenAmount : $("#GivenAmount").val(), 
            ChangeAmount : $("#ChangeAmount").val(),
            InventoryItems: list
        }
        console.log(Data);
        $.ajax({
            type: 'POST',
            url: '/Home/Order',
            data: JSON.stringify(Data),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data.status) {
                    alert('Successfully saved');
                    //here we will clear the form
                    list = [];
                }
                else {
                    alert('Error');
                }
               
            },
            error: function (error) {
                console.log(error);
            }
        });

        

    })


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


    //total calculation
    function calculateSum() {
        var sum = 0;
        // iterate through each td based on class and add the values
        $(".amount").each(function () {

            var value = $(this).text();
            // add only if the value is number
            if (!isNaN(value) && value.length != 0) {
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
            console.log(data);
            $.each(data, function (index, value) {
                $("#Price").val(value.price);
                $("#Description").val(value.description);
            });

        }
    });
}



