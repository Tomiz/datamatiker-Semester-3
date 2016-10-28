<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyRESTServiceCaller.aspx.cs" Inherits="MyRESTClient.MyRESTServiceCaller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="'1'" id="products">
                <%--<!– Make a Header Row –>--%>
                <tr>
                    <td><b>Product Id</b></td>
                    <td><b>Name</b></td>
                    <td><b>Price</b></td>
                    <td><b>Category</b></td>
                </tr>
            </table>

            <script type="text/javascript">
                $(document).ready(function ()
                {
                $.ajax({
                                  type: "GET",
                                  url: "http://localhost/MyRestService/ProductRESTService.svc/GetProductList/",
                                   dataType: "xml",
                                   success: function (xml) {
                $(xml).find('Product').each(function () {
                var id = $(this).find('ProductId').text();
                var name = $(this).find('Name').text();
                var price = $(this).find('Price').text();
                varcategory = $(this).find('CategoryName').text();
                                         $('<tr><td>' + id + '</td><td>' + name + '</td><td>' + price + '</td><td>' +
                category).appendTo('#products');
                });
                },
                                   error: function (xhr) {
                alert(xhr.responseText);
                }
                });
                });
            </script>
        </div>
    </form>
</body>
</html>
