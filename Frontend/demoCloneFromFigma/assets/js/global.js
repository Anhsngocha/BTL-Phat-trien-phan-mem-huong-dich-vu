window.onload = function () {
    var cart_json = JSON.parse(localStorage.getItem("cart"));
    if (cart_json != null) {
        cart_products = cart_json; // cập nhật biến cart từ localStorage
        document.getElementById("slsp").innerHTML = cart_products.length; // cập nhật số lượng sản phẩm trên biểu tượng giỏ hàng
    }
};

var current_url = "https://localhost:44366"
