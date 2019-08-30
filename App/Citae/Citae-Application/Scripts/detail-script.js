window.addEventListener('scroll', () => {
    if(!document.body.classList.contains('detail-shadow-nav')){
        if(window.pageYOffset >= 170){
            document.body.classList.add('detail-shadow-nav');
        }
    }
    else{
        if(window.pageYOffset < 170){
            document.body.classList.remove('detail-shadow-nav');
        }
    }
});