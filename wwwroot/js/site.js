const faqs = document.querySelectorAll(".faq");

faqs.forEach(faq => {
    faq.addEventListener("click", () =>{
        faq.classList.toggle("active");
    });
});

//Api de CEP


function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('rua').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('cidade').value = ("");
    document.getElementById('estado').value = ("");
    
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('rua').value = (conteudo.logradouro);
        document.getElementById('bairro').value = (conteudo.bairro);
        document.getElementById('cidade').value = (conteudo.localidade);
        document.getElementById('estado').value = (conteudo.uf);
        
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        alert("CEP não encontrado.");
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('rua').value = "...";
            document.getElementById('bairro').value = "...";
            document.getElementById('cidade').value = "...";
            document.getElementById('estado').value = "...";


            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulário_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
};


// Validação de CPF 

function validarCpf()
{
      var cpf = document.getElementById('cpf').value,
      cpfSoNumero = cpf.replace('.','').replace('.','').replace('.',''),
      somaDosNovePrimeirosNumeros = multiplicaNumeros(9, cpfSoNumero,10),
      somaDosDezPrimeirosNumeros = multiplicaNumeros(10, cpfSoNumero,11),
      resultadoModulo1 = obterDigitoVerificador(somaDosNovePrimeirosNumeros);
      resultadoModulo2 = obterDigitoVerificador(somaDosDezPrimeirosNumeros);
 
      if((resultadoModulo1 + resultadoModulo2) === cpfSoNumero.substr(9,2))
    {
          alert('CPF Válido');
    } else 
    {
        alert('CPF Inválido');
    }
 }
   function obterDigitoVerificador(soma) 
  {
     var resultado = (soma * 10) % 11;
     return resultado.toString();
  }
   function multiplicaNumeros(quantidadeNumeros, cpfSoNumero, multiplicado)
   {
     var primeirosNumeros = cpfSoNumero.substr(0, quantidadeNumeros), somaDosNumeros =0;
 
     for(var i = 0; i < primeirosNumeros.length; i++){
     var numero = primeirosNumeros.substr(i, 1);
         somaDosNumeros += numero * multiplicado;
         multiplicado--;
     }
 
     return somaDosNumeros;
 }

 // Mascara para parentese telefone 

 function mascara(telefone){ 
    if(telefone.value.length == 0)
        telefone.value = '(' + telefone.value; //quando começamos a digitar, o script irá inserir um parênteses no começo do campo.
    if(telefone.value.length == 3)
        telefone.value = telefone.value + ') '; //quando o campo já tiver 3 caracteres (um parênteses e 2 números) o script irá inserir mais um parênteses, fechando assim o código de área.

    if(telefone.value.length == 10)
        telefone.value = telefone.value + '-'; //quando o campo já tiver 8 caracteres, o script irá inserir um tracinho, para melhor visualização do telefone.
}
