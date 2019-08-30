/*Abrir Menu*/
document.querySelector('#body-nav .content-nav #btn-menu').addEventListener('click', () => {
    document.body.classList.add('opened-menu');
});

/*Fechar janelas ao tocar no fade*/
document.querySelector('#fade-back').addEventListener('click', () => {
    if (document.body.classList.contains('opened-menu')) {
        document.body.classList.remove('opened-menu');
    }
});