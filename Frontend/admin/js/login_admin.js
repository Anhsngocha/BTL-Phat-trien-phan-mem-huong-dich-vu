function login(event){
    event.preventDefault();

        var item = {}
        item.username = $('.user-login').val()
        item.password = $('.pass-login').val()
        $.ajax({
                type: "POST",
                url: current_url+"/api-admin/TaiKhoan/login",
                dataType: "json",
                contentType: 'application/json',
                data: JSON.stringify(item)
            }).done(function (data) {
                if (data != null && data.message != null && data.message != 'undefined') {
                    alert(data.message);
                } else {
                    // localStorage.setItem("user", JSON.stringify(data));
                    // window.location.href = "./admin/admin/TongQuan.html";
                    if(data.maquyen===1){
                        localStorage.setItem("admin", JSON.stringify(data));
                        window.location.href = '/admin/admin/TongQuan.html'
                    }
                }
               
            }) .fail(function() {
              alert('Tài khoản hoặc mật khẩu không chính xác');
            }); 
        // return
    // }
}