var index2 = 0;

function turnLeft() {
    index2--;
    if (index2 == -1) {
        for (var i = 0; i < slideIntro.length - 5; i++) {
            for (var j = 0; j < slideIntro.length; j++) {
                slideIntro[j].style.transform += 'translateX(-' + trans + 'px)';
                index2 = 3;
            }
        }
    } else {
        // let slideIntro = document.querySelectorAll('.intro-product-item')
        for (i = 0; i < slideIntro.length; i++) {
            // console.log(slideIntroLeft[i])
            slideIntro[i].style.transform += 'translateX(' + trans + 'px)'
        }
    }

}

function turnRight() {
    index2++;
    if (index2 == slideIntro.length - 4) {
        for (var i = 0; i < slideIntro.length - 5; i++) {
            for (var j = 0; j < slideIntro.length; j++) {
                slideIntro[j].style.transform += 'translateX(' + trans + 'px)';
                index2 = 0;
            }
        }
    } else {
        for (i = 0; i < slideIntro.length; i++) {
            // console.log(slideIntroLeft[i])
            slideIntro[i].style.transform += 'translateX(-' + trans + 'px)'
        }
    }
}