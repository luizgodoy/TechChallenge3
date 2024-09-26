# TechChallenge3

Grupo: 70
Turma: 4NETT
Curso: Arquitetura de Sistemas .NET com Azure

Este projeto é uma aplicação .NET que pode ser facilmente restaurada e executada utilizando o Docker Compose. O Tech Challenge é o projeto da fase que engloba os conhecimentos obtidos 
em todas as disciplinas dela.

## Pré-requisitos

Certifique-se de que você tenha os seguintes softwares instalados em sua máquina:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Como Restaurar e Executar o Projeto

Siga os passos abaixo para restaurar e executar o projeto usando Docker Compose:

### 1. Clonar o Repositório

Primeiramente, clone o repositório para a sua máquina local:

```bash
git clone https://github.com/luizgodoy/TechChallenge3.git
cd TechChallenge3
````

### 2. Restaurar Dependências

Para restaurar as dependências do projeto, você pode executar o comando abaixo:

```bash
dotnet restore
```

### 3. Construir e Executar o Projeto com Docker Compose

Agora que as dependências foram restauradas, você pode construir e executar a aplicação utilizando o Docker Compose:

```bash
-- acesse a pasta /Devops
docker-compose up --build
```
Este comando irá:

1) Construir a imagem Docker da sua aplicação com base no Dockerfile.
2) Subir os serviços definidos no arquivo docker-compose.yml, incluindo a aplicação .NET e quaisquer outros serviços que possam ser necessários, como bancos de dados, grafana, prometheus, RabbitMQ e RabbitMQ-Exporter.

### 4. Acessando a Aplicação

Se tudo estiver configurado corretamente, a aplicação estará disponível em:

```bash
http://localhost:18080
```
Verifique o arquivo docker-compose.yml para garantir que a porta está correta.

### 5. Parando a Aplicação

Para parar a aplicação, basta pressionar CTRL+C no terminal onde está executando o Docker Compose. Se preferir, você pode executar o comando abaixo:

```bash
docker-compose down
```
Este comando irá parar e remover os containers, mas manterá as imagens Docker criadas.
