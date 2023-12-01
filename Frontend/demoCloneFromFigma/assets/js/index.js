const tabs = document.querySelectorAll('[data-target]'),
    tabContents = document.querySelectorAll('[content]');

tabs.forEach((tab) => {
    tab.addEventListener('click', () => {
        const target = document.querySelector(tab.dataset.target);
        tabContents.forEach((tabContent) => {
            tabContent.classList.remove('active-tab');
        });

        target.classList.add('active-tab');

        tabs.forEach((tab) => {
            tab.classList.remove('active-tab');
        });
        tab.classList.add('active-tab');
    });
});


const loadmore = document.querySelector('.load-more');
let currentItems = 4;
loadmore.addEventListener('click', (e) => {
    const elementList = [...document.querySelectorAll('.product-suggest .product-container .product-item')];
    e.target.classList.add('show-loader');

    for (let i = currentItems; i < currentItems + 4; i++) {
        setTimeout( function() {
            e.target.classList.remove('show-loader');
            if(elementList[i]) {
                elementList[i].style.display = 'grid';
            }
        }, 2000)
    }

    currentItems += 4;

    if (currentItems >= elementList.length) {
        event.target.classList.add('loaded');
    }
})