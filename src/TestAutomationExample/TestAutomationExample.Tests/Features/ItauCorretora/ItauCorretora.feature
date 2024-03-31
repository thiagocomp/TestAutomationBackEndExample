#language: pt-BR

Funcionalidade: Aplicativo Itaú Corretora

@ct01
Cenário: Verificar que o login não é realizado quando o cliente insere credenciais inválidas no login.
#	Dado que tenho o aplicativo do Itaú Corretora instalado
#	Quando insiro credenciais inválidas no login
#	Então visualizo a mensagem de erro no login
#
#
#@ct02
#Cenario: Verificar que ao cliente clicar no ícone 'cotações' a tela de cotações é exibida com os seguintes itens: título da página, campo de busca e cabeçalho
#	Dado que tenho o aplicativo do Itaú Corretora instalado
#	Quando acesso a sessão de cotações
#	Então visualizo os dados necessários para o cliente 
#
#@ct03
#Cenario: Verificar que os caracteres são apagados corretamente após o cliente realizar uma busca de ativo no buscador e clicar no botão X do campo de busca
#	Dado que estou na sessão cotações
#	Quando preencho o ativo "ITSA4" ativo para consultar a cotação
#	E clico no botão X 
#	Então os caracteres devem ser apagados com sucesso
#
#
#@ct04
#Cenario: Verificar que a mensagem 'ABCD não encontrado' é retornado após o cliente buscar pelo ativo ABCD (ativo inexistente)
#	Dado que estou na sessão cotações
#	Quando preencho o ativo "ABCD" ativo para consultar a cotação
#	Então a mensagem que o ativo não foi encontrado deve ser exibida com sucesso