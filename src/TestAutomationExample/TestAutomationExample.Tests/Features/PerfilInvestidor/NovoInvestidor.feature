#language: pt-BR

Funcionalidade: Novo Investidor

@ct11
Esquema do Cenário: Verificar o cadastro de um investidor com sucesso
	Dado que tenho um investidor "<Perfil>" e "Possui" investimentos
	Quando realizo o cadastro dele
	Então o investidor é cadastrado com sucesso

	Exemplos: 
	| Perfil      | Possui	|
	| CONSERVADOR | POSSUI	|
	| MODERADO    |	POSSUI	|
	| ARROJADO    | POSSUI	|
	| CONSERVADOR | NAO		|
	| MODERADO    |	NAO		|

@ct12
Cenário: Verificar o erro de cadastro para investidor Arrojado sem investimentos
	Dado que tenho um investidor "ARROJADO" e "Não Possui" investimentos
	Quando realizo o cadastro dele
	Então o cadastro é negado com Status Code "UnprocessableEntity" Mensagem "Cliente não pode ser cadastrado nesse perfil, por não possuir investimentos"

@ct13
Cenário: Verificar o erro de cadastro com perfil de investidor inválido
	Dado que tenho um investidor "CONSERVADOR" e "Não Possui" investimentos
	Quando realizo o cadastro dele
	Então o cadastro é negado com Status Code "UnprocessableEntity" Mensagem "Perfil não encontrado"

@ct14
Cenário: Verificar o erro de cadastro com informações incorretas
	Dado que tenho um investidor com informações incorretas
	Quando realizo o cadastro dele
	Então o cadastro é negado com Status Code "BadRequest" Mensagem "Body com informações incorretas"

@ct15
Cenário: Verificar erro de autenticação na api com beaer token inválido
	Dado que tenho um investidor "CONSERVADOR" e "Não Possui" investimentos
	Quando realizo o cadastro dele com bearer token inválido
	Então o cadastro é negado com Status Code "Unauthorized" Mensagem "Erro de autenticação"

@ct16
Cenário: Verificar erro de autenticação na api sem bearer token
	Dado que tenho um investidor "CONSERVADOR" e "Não Possui" investimentos
	Quando realizo o cadastro dele sem bearer token
	Então o cadastro é negado com Status Code "Unauthorized" Mensagem "Erro de autenticação"