# Worker Blueprint Template

Este repositório contém um **template de Worker em .NET 8** para inicializar rapidamente novos projetos. O pacote está disponível de forma privada no **GitHub Packages**.

---

## 📦 Como consumir o pacote

### 1. Configure a source do GitHub Packages
No terminal, adicione o repositório do seu usuário/organização como fonte do NuGet:

```bash
dotnet nuget add source "https://nuget.pkg.github.com/YOUR_USER/index.json" \
    --name github \
    --username <YOUR_USER_OR_ORG> \
    --password <GITHUB_TOKEN> \
    --store-password-in-clear-tex
````

### 2. Instale o pacote
Depois de configurar a source, você pode instalar o pacote normalmente:

```bash
dotnet new install Worker_Blueprint::<version> --nuget-source github
````
ou, se for consumir como biblioteca NuGet:
```bash
dotnet add package Worker_Blueprint --version <version> --nuget-source github
````

### 3. Criar um projeto a partir do template
Depois de instalado, você pode criar um novo projeto com:

### 4. Atualizar o pacote
Para atualizar para a última versão:
```bash
dotnet new workerblueprint -n YourNewProjectName
````

```bash
dotnet new update
````
ou
```bash
dotnet add package worker_Blueprint --version x.y.z
````
