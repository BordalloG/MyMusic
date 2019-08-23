# Seja bem vindo ao myMusic!
MyMusic é uma aplicação Web desenvolvida com uma Api utilizando como linguagem base o C#, .net core 2.2.

## Qual a utilidade do myMusic ?

Com o myMusic você pode criar uma lista de músicas. Salvando informações como Título, Autor e Duração. 

# Dependências 
[.Net Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)  
[Node](https://nodejs.org/en/download/)   
[Angular Cli](https://cli.angular.io/)  
[Angular Material](https://material.angular.io/guide/getting-started)
# Como rodar na sua máquina.
Instale todas as dependências.  
Clone o projeto.

Banco de dados:  
Rode o script de banco disponível na pasta "DataBase".


API:  
Abra a solução usando o Visual Studio (MyMusic.sln).  
Defina o projeto da api (MyMusic.Application.WebAPI) como projeto inicialização.  
Defina a url de inicio como "swagger":  
```bash
Botão direito no projeto da api > Propriedades > Debug > Lauch browser: "swagger".
```
Defina a porta de sua preferencia que sera usada para a API:
```bash
Botão direito no projeto da api > Propriedades > Debug > App Url: "http://localhost:11223".
```
Pegue um token de autenticação da api do spotify e adicione na api:
```bash
https://developer.spotify.com/console/get-current-user-playlists/ > Clique em "Get Token" > Clique em"Request Token" > Faça login no spotify > 
Copie o Token e adicione na variável "spotifyToken" dentro do arquivo "HttpClientHelperDomainService.cs"
```
Nesse ponto você já deve conseguir usar o swagger para utilizar a API.  

Angular:  
Abra o diretório myMusic/Source/Presentation com o Visual Code.    

Utilizando o terminal rode o comando "npm i" para baixar as dependências.  

Altere a variável baseUri no arquivo  src\environments\environment.ts  com o valor que você definiu na sua api.

Use o comando "ng serve --open" para rodar o servidor.

Observação: É necessário renovar o token do spotify de tempos em tempos.


Exemplo de playlist: https://open.spotify.com/playlist/1Z0ZsrMYLRyFROD8JmzmXX
