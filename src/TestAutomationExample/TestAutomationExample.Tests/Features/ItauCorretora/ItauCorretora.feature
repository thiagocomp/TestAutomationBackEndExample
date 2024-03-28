#language: pt-BR

Funcionalidade: Aplicativo Itaú Corretora

@ct01
Cenário: Verificar que o login não é realizado quando o cliente insere credenciais inválidas no login.
	Dado que tenho o aplicativo do Itaú Corretora instalado
	Quando insiro credenciais inválidas no login
	Então visualizo a mensagem de erro no login


@ct02
Cenario: Verificar que ao cliente clicar no ícone 'cotações' a tela de cotações é exibida com os seguintes itens: título da página, campo de busca e cabeçalho
	Dado que tenho o aplicativo do Itaú Corretora instalado
