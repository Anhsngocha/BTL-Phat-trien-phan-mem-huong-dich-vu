var slides = document.getElementsByClassName("img-feature");
var dots = document.getElementsByClassName("box-extra-img");
var trans = 150

function changActiveDetails(type, element) {
    let changeDetails = document.querySelectorAll('.list-detail li');
    for (i = 0; i < changeDetails.length; i++) {
        changeDetails[i].classList.remove('active-details')
    }
    element.classList.add('active-details')
    switch (type) {
        case 'content-information':
            {

                document.getElementById('content-parameter').style.display = 'none'
                document.getElementById('content-comment').style.display = 'none'
            }
        case 'content-parameter':
            {
                document.getElementById('content-information').style.display = 'none'
                document.getElementById('content-comment').style.display = 'none'
            }
        case 'content-comment':
            {
                document.getElementById('content-parameter').style.display = 'none'
                document.getElementById('content-information').style.display = 'none'
            }
    }
    document.getElementById(type).style.display = 'block'
}

function changActiveColor(element) {
    let colorProduct = document.querySelectorAll('.item-color-product')
    for (var x of colorProduct) {
        x.classList.remove('active-color')
    }
    element.classList.add('active-color')
}

var slideIntro = document.querySelectorAll('.container-extra-img')

var slideIndex = 1;
showSlides(slideIndex);

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    if (n > slides.length) {
        slideIndex = 1
    }
    if (n < 1) {
        slideIndex = slides.length
    }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active-img", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active-img";
    // captionText.innerHTML = dots[slideIndex - 1].alt;
}