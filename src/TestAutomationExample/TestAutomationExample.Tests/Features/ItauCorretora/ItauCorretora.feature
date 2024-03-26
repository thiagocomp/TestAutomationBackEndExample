#language: pt-BR

Funcionalidade: Aplicativo Itaú Corretora


@tag1
Cenário: Verificar que o login não é realizado quando o cliente insere credenciais inválidas no login.
	Dado que tenho o aplicativo do Itaú Corretora instalado
	Quando insiro credenciais inválidas no login
	Então visualizo a mensagem de erro no login
