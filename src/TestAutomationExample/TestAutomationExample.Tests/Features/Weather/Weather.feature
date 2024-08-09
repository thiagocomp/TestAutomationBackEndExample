#language: pt-BR

Funcionalidade: API Weather

@ct05 
Cenário: Verificar uma requisição informando uma cidade brasileira
	Dado que tenho acesso a api de weather
	Quando envio a requisição da cidade "Taboão da Serra" estado "SP" país "BR"
	Então visualizo o retorno da requisição com sucesso
#
@ct06
Cenário: Verificar uma requisição informando uma cidade brasileira e validando o Id retornado
	Dado que tenho acesso a api de weather
	Quando envio a requisição da cidade "Alfenas" estado "MG" país "BR"
	E envio a requisição da cidade "Alfenas" estado "MG" país "BR"
	Então visualizo o retorno da requisição com sucesso validando o id

@ct07
Cenário: Verificar uma requisição usando um método put não suportado pela API
	Dado que tenho acesso a api de weather
	Quando envio a requisição da cidade "Alfenas" estado "MG" país "BR" com metodo Put
	Então visualizo a mensagem de erro "Internal error" StatusCode "MethodNotAllowed"

@ct08
Cenário: Verificar uma requisição informando uma api key inválida
	Dado que tenho acesso a api de weather
	Quando envio a requisição da cidade "Alfenas" estado "MG" país "BR" com apikey inválida
	Então visualizo a mensagem de erro "Invalid API key" StatusCode "Unauthorized"

@ct09
Cenário: Verificar uma requisição informando sem informar api key
	Dado que tenho acesso a api de weather
	Quando envio a requisição da cidade "São Paulo" estado "SP" país "BR" sem informar apikey
	Então visualizo a mensagem de erro "Invalid API key" StatusCode "Unauthorized"

@ct10
Cenário: Verificar uma requisição informando uma cidade inválida
	Dado que tenho acesso a api de weather
	Quando envio a requisição da cidade "Ayco" estado "SP" país "BR"
	Então visualizo a mensagem de erro Cidade não localizada