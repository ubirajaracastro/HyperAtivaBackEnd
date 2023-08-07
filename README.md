# HyperAtivaBackEnd
Features Utilizadas no Teste Backend

Microsoft VisUAL Studio 2019
.Net Core 3.1
EF Core Utilizado o Fluent Api para mapeamento de criação da base de dados no modelo CodeFirst  (Alterar a string de conexao para o servidor SQL em questao)

Banco de Dados - Microsoft SQL Server 2019
A autenticação da API Foi implementada com JWT para .net Core V 3.1.4

Adicionada a documentação do Swagger para descrição das operações dos controllers da api e teste na interface do Swagger.

No teste efetuado foi levado em consideração na operação de importação do arquivo de cartoes que o front end faça o upload do arquivo informado pelo cliente e em seguida faça a requisição Post para a api (Controller Cartao).

Por questão de simplificação do teste o mesmo foi efetuado no mesmo proj, camada do Ef, domínio e models e crosscuttin.  No cenário real de uma aplicação comercial, faríamos a separação de responsabilidade, domínio coeso, data, camadas comuns a aplicação até um cenário arquitetural mais voltado ao negócio como um DDD por exemplo.

Faria-se também a injeção e o seu escopo do DBContex do EF Core e demais contratos implementados na operação do negócio.


Obrigado.





