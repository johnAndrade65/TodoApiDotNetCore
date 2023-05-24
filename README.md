# TodoApiDotNetCore
<p>Ainda em construção! criado por para aplicar conceitos de ASP.NET Core como WebAPI Mínima, com uma estrutura bem simples para combinar com o conceito de Minimal API.</p>
<h5>Back-end criado com C#, ASP.NET Core 7.0 e EF Core.</h5>

## Skills usadas
<div>
  <h3>ASP.NET Core MinimalAPI Back-end:</h3>
  <div style="display: inline_block"><br/>
  <img alt="c#" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/>
  <img alt=".net" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>
  <img alt="sqlserver" src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white"/>
</div>

## Aviso:
<ol>
  <li>Use suas credenciais de login do SQLServer no arquivo "appsettings.Development.json" para logar ao seu banco de dados(Database).</li>
</ol>

## Funções:
<ol>
  <li>- Funções CRUD(Create, Read, Update e Delete) com nova estrutura.</li>
  <li>- Função de Obter(GET) os nomes atráves do id, os completos(True) ou obter todos listados.</li>
  <li>- Função de Deletar(DELETE) atráves do id especificado.</li>
  <li>- Função de Atualizar(PUT) atráves do id especificado.</li>
  <li>- Função de Adicionar(POST) dados a API atráves do id especificado.</li>
  <li>- Adição de comentarios necessários no "Program.cs".</li>
</ol>


## atualização de segurança, alpha 0.0.4:
<ol>
  <li>- Adição de autenticação viá Token pelo JWTBearer.</li>
  <li>- Criação da de propriedade "Message" no arquivo "Todo.cs" para o CRUD.</li>
  <li>- Separação dos arquivos que representam (entidades de dados/objetos de transferência de dados) para o diretorio "Models".</li>
  <li>- Adição de string de conexão para conectar a API ao banco de dados.</li>
  <li>- Adição de comentarios necessários no "Todo.cs", "TodoDb.cs" e "TodoItemDTO".</li>
  <li>- Correção de bugs de conexão.</li>
</ol>

## Rodar o Back-end:
<ol>
  <li>Crie a (tela-de-comandos/prompt) no diretorio principal do projeto.</li>
  <li>Instale as dependencias: dotnet restore</li>
  <li>Rode projeto: dotnet watch run</li>
</ol>

## Criar um Token: 
<ol>
  <li>Abra o Prompt de comandos.</li>
  <li>Rode o código: dotnet user-jwts create.</li>
  <li>Copie o Token por completo.</li>
</ol>

## Usar os métodos de requisição com PostMan
<ol>
  <li>Instale o PostMan.</li>
  <li>Crie o método de requisição(GET, POST, PUT ou DELETE) no PostMan de acordo com sua preferencia.</li>
  <li>Adicione a URL de acordo com a API para fazer a requisição com sucesso.</li>
  <li>Vá na aba "authorization" e escolha "Bearer Token".</li>
  <li>Cole o Token no campo "Token".</li>
</ol>
