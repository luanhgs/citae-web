/*---- ANIMAÇÃO DA ROLAGEM ----*/
const divsSecContent = document.querySelectorAll("main .sec-content");

function reviewFade(){
    if(divsSecContent[divsSecContent.length - 1].classList.contains('showed-content') == false){ /*IF pra executar apenas quando necessário*/
        divsSecContent.forEach( (el) => {
            if( (el.offsetTop < (window.pageYOffset + ((window.innerHeight * 3.5)/4)) ) && !(el.classList.contains('showed-content')) ){
                el.classList.add('showed-content');
            }
        });
    }
}

window.addEventListener('load', reviewFade);
document.addEventListener('scroll', reviewFade);

/*---- ANIMAÇÃO DE CARREGAMENTO DA PÁGINA ----*/
window.onload = () => {
    setTimeout(() => { document.body.classList.add("page-loaded") },2000);
}