let count = 6;

function redireccion(){


    if(window.location.pathname === "/Identity/Account/ConfirmEmail"){
        
        mensaje();
        setInterval(mensaje , 1000);
        setTimeout("redirect()", 5500);

    }

}

function redirect(){

    window.location.href = "https://app-ajinomoto.herokuapp.com/";

  }

  function mensaje (){

    const texto = document.querySelector('#mensaje');
    count--;
    texto.textContent = "Su correo a sido confirmado se le redireccionara a la pagina de inicio en: " + count + " segundos";
  
  }

  function mostrarPassword(campo) {
    var pass = document.getElementById(campo);
    if (pass.type === "password") {
      pass.type = "text";
    } else {
      pass.type = "password";
    }
  }
   
