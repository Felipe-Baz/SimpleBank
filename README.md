# Aplicação SimpleBank

Bem-vindo à aplicação SimpleBank! Este README fornece instruções sobre como executar a aplicação, realizar testes e acessar a documentação Swagger.

## Descrição do Projeto

O SimpleBank é uma aplicação bancária simples que permite cadastrar usuários e realizar transferências entre eles. Com esta aplicação, você pode criar contas de usuário, efetuar transferências de fundos entre as contas cadastradas e explorar a funcionalidade da aplicação bancária.

## Primeiros Passos

Para executar a aplicação, siga estas etapas:

1. Certifique-se de que o Docker esteja instalado em seu sistema.

2. Abra um terminal e navegue até o diretório raiz do projeto.

3. Execute o seguinte comando para construir e iniciar a aplicação:

   ```bash
   make start
   ```

   Este comando executará os testes e, após o teste bem-sucedido, implantará a API usando o Docker.

## Execução de Testes

Para executar testes, use o seguinte comando:

```bash
make tests
```

Isso executará os testes automatizados para garantir a funcionalidade da aplicação.

## Acessando a Documentação Swagger

A documentação da API da aplicação é fornecida usando o Swagger. Você pode acessar o Swagger UI abrindo um navegador da web e indo para:

[http://localhost:8888/swagger/index.html](http://localhost:8888/swagger/index.html)

Essa documentação interativa fornece informações detalhadas sobre os pontos de extremidade da API disponíveis, parâmetros de solicitação e estruturas de resposta.

Sinta-se à vontade para explorar a API usando a interface do Swagger!

Para quaisquer dúvidas ou assistência, não hesite em entrar em contato.