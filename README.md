# TodoListAPI

<details open="open">
    <summary>Conteúdo</summary>
    <ol>
        <li>
            <a href="#sobre-o-projeto">Sobre o projeto</a>
            <ul>
                <li><a href="#built-with">Built With</a>
                <li><a href="#features">Feautures</a>
            </ul>
        </li>
        <li>
            <a href="#getting-started">Getting Started</a>
            <ul>
                <li><a href="#requisitos">Requisitos</a>
                <li><a href="#instalação">Instalação</a>
            </ul>
        </li>
        <li><a href="#licença">Licença</a>
    </ol>
</details>

### **Sobre o projeto**

Este é um projeto de uma Web API desenvolvida em .NET Core 7 para um app de todo-list.

Desenvolvi este projeto para dar continuidade a minha jornada com os estudos em .net core e o objetivo era implementar uma API utilizando a arquitetura onion.

Como mencionado a cima, é uma API para um clássico app de todo-list. Desse modo, o usuário cria uma conta e consegue criar um planejamento das tarefas a serem realizadas.

Para isso a API fornece endpoints para o usuário (cadastro, recuperação de perfil, alteração de senha) e fornece também serviço de autenticação utilizando **token JWT** para que o usuário consiga acessar os recursos da API.

Ao logar na API, o usuário consegue inserir, recupera, atualizar e remover tarefas de seus afazeres.

Também consegue inserir anotações, sobre por exemplo uma análise de sua produtividade diária.

#### **Built With**

![ubuntu-shield]
![net-core]
![csharp-shield]
![swagger-shield]
![postman-shield]
![mysql-shield]
![vscode-shield]
![git-shield]

#### features

- Registrar usuário;
- Criar tarefa;
- Cadastrar anotação;
- Recuperar tarefas e anotações;
- Dashboard de performance (tarefas concluídas e pendentes);

E outras.

### Getting Started

#### Requisitos

- Visual Studio Code

- MySql

#### Instalação

1. Clone o repositório
   ```sh
   git clone https://github.com/matheuz-siqueira/TodoListAPI
   ```
2. Preenche as informações no arquivo `appsettings.Development.json`

3. Execute a API

   ```sh
   dotnet watch run
   ```

   ou

   ```sh
   dotnet run
   ```

4. Ótimos testes :)

### Licença

Fique a vontade para estudar e aprender com este projeto. Você não tem permissão para utiliza-lo para distribuição ou comercialização.

<!-- Badges -->

[ubuntu-shield]: https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=ubuntu&logoColor=white
[swagger-shield]: https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white
[net-core]: https://img.shields.io/badge/.NET_%20_Core_7.0-5C2D91?style=for-the-badge&logo=.net&logoColor=white
[postman-shield]: https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white
[csharp-shield]: https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white
[mysql-shield]: https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white
[vscode-shield]: https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white
[git-shield]: https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white
