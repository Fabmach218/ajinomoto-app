let count = 6;

function redireccion(){


    if(window.location.pathname === "/Identity/Account/ConfirmEmail"){
        
        mensaje();
        setInterval(mensaje , 1000);
        setTimeout("redirect()", 5500);

    }

}

function redirect(){

    window.location.href = "https://localhost:5001/";

  }

  function mensaje (){

    const texto = document.querySelector('#mensaje');
    count--;
    texto.textContent = "Su correo a sido confirmado se le redireccionara a la pagina de inicio en: " + count + " segundos";
  
  }
   
