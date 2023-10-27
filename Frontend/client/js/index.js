document.addEventListener("DOMContentLoaded", function () {
  // Lấy tất cả các nút "Add to cart" trên trang
  const addToCartButtons = document.querySelectorAll(".add-btn");

  // Sự kiện click cho từng nút "Add to cart"
  addToCartButtons.forEach((button) => {
    button.addEventListener("click", () => {
      const productName =
        document.getElementById("product-title-id").textContent;
      const productImage = document.getElementById("product-img-id").src;
      const productSalePrice = parseFloat(
        document.getElementById("product-sale-id").textContent
      );

      console.log("productName:", productName);
      console.log("productImage:", productImage);
      console.log("productSalePrice:", productSalePrice);
      // 1. Xác định sản phẩm cụ thể mà người dùng đang thêm vào giỏ hàng
      const productToAdd = {
        name: productName,
        price: productSalePrice, // Giá sản phẩm
        image: productImage, // URL hình ảnh sản phẩm
        // Thêm các thông tin khác nếu cần
      };

      // 2. Chuyển thông tin sản phẩm thành đối tượng JSON
      const productJSON = JSON.stringify(productToAdd);

      // 3. Lấy danh sách sản phẩm đã lưu từ Local Storage (nếu có)
      const existingProductsJSON = localStorage.getItem("cart");
      const existingProducts = existingProductsJSON
        ? JSON.parse(existingProductsJSON)
        : [];

      // 4. Thêm sản phẩm mới vào danh sách sản phẩm đã lưu
      existingProducts.push(productJSON);

      // 5. Lưu danh sách sản phẩm mới vào Local Storage
      localStorage.setItem("cart", JSON.stringify(existingProducts));

      // 6. Tính toán tổng số sản phẩm trong giỏ hàng
      const totalItemsInCart = existingProducts.length;

      // 7. Cập nhật biểu tượng giỏ hàng để hiển thị số sản phẩm trong giỏ hàng
      const cartIcon = document.querySelector(".fa-cart-shopping"); // Thay thế bằng cách chọn phần tử biểu tượng giỏ hàng của bạn
      const countElement = cartIcon.querySelector("header-btn .count-product"); // Thay thế bằng cách chọn phần tử hiển thị số

      countElement.textContent = totalItemsInCart;

      // 8. Hiển thị thông báo thêm thành công
      alert("Sản phẩm đã được thêm vào giỏ hàng.");
    });
  });
});
