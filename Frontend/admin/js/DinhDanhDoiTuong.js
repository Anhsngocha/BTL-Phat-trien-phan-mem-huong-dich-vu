// Xây dựng hàm sinh ID tự động
function taoID() {
    var id = '';
    // Lấy milisecond ở thời điển hiện tại 1s = 1000 milisecond
    id = Math.random().toString().substring(2, 10) + "_" +
        String(new Date().getTime());

    return id;
}