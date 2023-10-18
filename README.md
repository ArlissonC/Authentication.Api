<div align="center">
    <img src="https://i.imgur.com/VPaYfhT.png" alt="Authentication API" />
    <p>A .NET application to train and improve my knowledge about Authentication and user control</p>
</div>

## 💻 Overview

This project is built with .NET 7 and makes use of ASP.NET Identity for managing users and roles. Additionally, utilize Entity Framework Core (EF Core) to handle SQL Server database migrations. The main objective is to offer a complete authentication and authorization system, with attention to simplicity and functionality, while leveraging SQL Server as the database.

## ✅ Features

- [x] Register roles:
      Allows registration of user roles.
      Useful for administration and configuration of different permission levels within the application.

- [x] User registration:
      Provides the functionality for new users to register.
      Allows new users to create accounts on the app.

- [x] User Login:
      Allows existing users to securely log in to the app.
      Protects restricted areas of the application through authentication.

- [x] Forgot password:
      Provides a mechanism for users to reset forgotten passwords.
      Helps users regain access to their accounts in case of forgotten passwords.

- [x] User password reset:
      Allows users to reset their passwords.
      Useful when users want to update their passwords for security reasons.

- [x] Changing user password:
      Provides the functionality for users to change their passwords.
      Allows users to securely update their passwords when necessary.

## 🚀 Tech Stack

The following tools were used in the construction of the project:

<code><img height="32" src="https://cdn.simpleicons.org/csharp/512BD4" alt="csharp"/></code>
<code><img height="32" src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/dotnet/dotnet.png" alt=".NET"/></code>
<code><img height="32" src="https://cdn.simpleicons.org/microsoftsqlserver/CC2927" alt="microsoftsqlserver"/></code>
<code><img height="32" src="https://cdn.simpleicons.org/docker/2496ED" alt="docker"/></code>

## 👉 Run project

Before you begin, you will need to have the following tools installed on your machine:
[Git](https://git-scm.com), [npm](https://www.npmjs.com/)
In addition, it is good to have an editor to work with the code like [VSCode](https://code.visualstudio.com/).

```bash

# Clone this repository
$ git clone https://github.com/ArlissonC/authentication.api.git

# go to the project folder
$ cd Authentication

```

### Docker

In this application I used a Linux container, so I enforced a HTTPS. To do this we have to generate a trusted certificate.
**Generate certificate for windows**

```powershell
> dotnet dev-certs https -ep %USERPROFILE%.aspnet\https\aspnetapp.pfx -p password123

> dotnet dev-certs https --trust
```

**Up Container**

```bash
$ /Authentication> docker-compose up
```

**Up Migrations**

```bash
$ /Authentication> cd /Authentication
$ dotnet ef database update
```

**Running on: https://localhost:5001/swagger/index.html**
