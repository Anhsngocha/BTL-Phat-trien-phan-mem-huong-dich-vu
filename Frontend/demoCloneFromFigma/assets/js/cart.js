var cart_products = [];
var btn = document.getElementsByTagName("button");

for (let i = 0; i < btn.length; i++) {
    btn[i].addEventListener("click", function(){
        var imageProducts = btn[i].parentElement.parentElement.childNodes[1].childNodes[1].src;
        var productTitleElement = this.closest('.single_pro_details').querySelector('.product-detail-title');
        if (productTitleElement) {
            var nameProducts = productTitleElement.innerText;
            // alert(nameProducts);
        } else {
            console.error("Product title element not found.");
        }

        var priceProducts = this.closest('.single_pro_details').querySelector('.product-detail-price').innerText;
        // alert(priceProducts);
        var quantity = 1
        var listProducts = {
            name: nameProducts,
            image: imageProducts,
            price: priceProducts,
            number: quantity
        };

        cart_products.push(listProducts);
        localStorage.setItem("cart", JSON.stringify(cart_products));

        var cart_json = JSON.parse(localStorage.getItem("cart"));

        if(cart_json!= null)
        {
            cart_products = cart_json;
            document.getElementById("slsp").innerHTML = cart_json.length;
        }

        alert("Thêm sản phẩm thành công!");
    });
    
}
