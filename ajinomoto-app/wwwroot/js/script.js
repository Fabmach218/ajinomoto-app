const nave = document.querySelector('.flex__nav');
const div  = document.querySelector('.nav-columna');
const parrilla = document.querySelector('.parrilla');

parrilla.addEventListener('click' , function(){

     

    if(div.classList.contains('mostrar')){
    
     div.style.display = 'none';
     div.classList.remove('mostrar');
     

    }else {

        div.classList.add('mostrar')
    }



});

 

window.onload = function(){
     
     tamaño(2);
   
}

function tamaño(numero){

  

  const flex = document.querySelector('.flex');
  const header = document.querySelector('#header');

    if (window.outerWidth > 768) {
        
        parrilla.style.display = 'none';
        div.style.display = 'none';
        nave.classList.remove('nav-columna');
        header.classList.remove('flex-colum');
        flex.appendChild(nave); 
        div.classList.remove('mostrar');
        console.log("hola como estas");
        
        

    } else if(window.outerWidth < 768) {

        parrilla.style.display = 'block';
        nave.classList.add('nav-columna');
        div.appendChild(nave);
        header.classList.add('flex-colum')
        console.log("estoy aqui");

        if(numero === 2){

            div.classList.add('mostrar');
        }else {

            console.log("revels");
        }
       
    }

}