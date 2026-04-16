<!-- Titulo e Descrição: O que a Api faz -->
<!-- Tecnologias: Lista das ferramentas Usadas. -->
<!-- Configuração de Ambiente: Como configurar as Connection Strings ou variáveis de ambiente . env-->
<!-- Como Executar: Comandos para rodar o projeto localmente. -->
<!-- Documentação da API: Breve explicação das rotas principais ou link para o Swagger. -->
<!-- Autor: Seu nome e links de contato. -->


# Clínica Liberated 

## Visão geral

### Clínica Liberated fornece uma API REST para:

* Cadastrar pacientes e médicos;
* Consultar cadastros por paciente, médico e especialidade;
* Realizar chamadas/triagens agendadas ou em tempo real entre paciente e médico.

## Tecnologias

* Linguagem: C#
* Framework: ASP.NET Core
* IDE: Visual Studio
* Testes/cliente: Postman
* Execução: dotnet CLI (dotnet run)

## Requisitos e pré-requisitos

* .NET SDK compatível (versão do projeto);
* Visual Studio 2022+ com workload ASP.NET/Core instalado;
* Postman instalado;
* Permissões para executar serviços na porta configurada (ex.: 5000/5001).

## Extensões recomendadas (Visual Studio)

* Windows App SDK C# VS Templates
* Single-Project MSIX Packaging Tools for VS 2022-26
* ML.NET Model Builder 2022 (se usar ML)
* Microsoft Library Manager

## Configuração do ambiente

* Clonar o repositório para sua máquina.
* Abrir a solução (.sln) no Visual Studio.
* Restaurar pacotes NuGet (Visual Studio faz automaticamente ou via dotnet restore).
* Ajustar appsettings.json / variáveis de ambiente:
- ConnectionString do banco de dados;
- Portas (Kestrel) se necessário;
- Qualquer chave externa (serviço de chamadas, provider de autenticação).
* Criar/atualizar banco de dados (se houver migrations):
  - dotnet ef database update ou usar a rotina de migration no startup.

## Execução

* Em desenvolvimento (terminal na pasta do projeto):
  - dotnet run
  - Ou executar via Visual Studio (F5 ou Ctrl+F5).

## Endpoints principais (exemplos)

### Observação: ajuste rotas e modelos conforme implementação.

    Pacientes
        POST /api/pacientes
            Body (JSON): { "nome": "Fulano", "cpf": "...", "dataNascimento":"YYYY-MM-DD", "contato":"..." }
        GET /api/pacientes/{id}
        GET /api/pacientes?nome=... (filtro)

    Médicos
        POST /api/medicos
            Body (JSON): { "nome":"Dr. Silva", "crm":"...", "especialidade":"Cardiologia", "contato":"..." }
        GET /api/medicos/{id}
        GET /api/medicos?especialidade=Cardiologia

    Consultas / Chamadas
        POST /api/consultas
            Body (JSON): { "pacienteId":1, "medicoId":2, "dataHora":"YYYY-MM-DDTHH:MM:SS", "tipo":"presencial|remoto" }
        GET /api/consultas?pacienteId=1
        POST /api/chamadas/start
            Body (JSON): { "consultaId":123 } — inicia chamada entre paciente e médico
        GET /api/consultas/{id}/status

### Exemplo rápido: usar Postman

* Abra o Postman.
* Crie um Workspace (opcional).
* Crie uma nova Request (New → Request).
* Configure método e URL base (ex.: http://localhost:5000/api/pacientes).
* Em Headers, defina Content-Type: application/json e Authorization: Bearer (se houver).
* No Body selecione raw → JSON e cole o payload de exemplo.
* Envie (Send) e verifique resposta / status code.
* Salve requests em uma Collection para reutilizar e exportar.


### Troubleshooting rápido

    Erro de porta em uso: alterar porta em launchSettings.json ou encerrar processo que está usando.
    Erro de conexão com DB: verificar ConnectionString e se o banco está acessível.
    401/403: conferir token JWT e roles.

### Entregáveis sugeridos

    Collection Postman com todos endpoints e exemplos de payload.
    Swagger UI habilitado para exploração.
    README detalhado com instruções de configuração de ambiente e variáveis necessárias.


### Renan Vasconcelos 
