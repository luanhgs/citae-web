/*---- ANIMAÇÃO DA ROLAGEM ----*/
const divsSecContent = document.querySelectorAll("main .sec-content");

function reviewFade(){
    divsSecContent.forEach( (el) => {
        if( (el.offsetTop < (window.pageYOffset + ((window.innerHeight * 3)/4)) ) && !(el.classList.contains('showed-content')) ){
            el.classList.add('showed-content');
        }
    });
}

window.addEventListener('load', reviewFade);
document.addEventListener('scroll', reviewFade);
