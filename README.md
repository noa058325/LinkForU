# 🔗 LinkForU

A clean and modern web application that centralizes useful links by categories – Education, Design, Technology, Online Tools, and more. Featuring a fast search, smooth navigation, and an enjoyable user experience 🤍

---

## 📘 Table of Contents

* [🎯 What is LinkForU?](#-what-is-linkforu)
* [⚙️ Key Features](#️-key-features)
* [🛠️ Tech Stack](#️-tech-stack)
* [🚀 Installation & Setup](#-installation--setup)

  * [🔧 Backend – ASP.NET Core](#-backend--aspnet-core)
  * [🌐 Frontend – Angular + SSR](#-frontend--angular--ssr)
* [📂 Project Structure](#-project-structure)
* [⚡ Environment Variables](#-environment-variables)
* [🤝 Contributing](#-contributing)
* [👥 Contributors](#-contributors)
* [💡 Future Ideas](#-future-ideas)
* [📜 License](#-license)

---

## 🎯 What is LinkForU?

**LinkForU** is a modern web platform that allows users to browse curated links by categories, search for resources, and discover new tools with ease. It provides a clean UI, interactive features such as likes and comments, and category-based navigation.

---

## ⚙️ Key Features

* ✨ **Powerful Search** – Find useful links instantly by keywords
* 🗂️ **Organized Categories** – Browse by structured topics
* 💬 **Community Feedback** – Add comments on links
* 👍 **Upvote System** – Like & highlight useful resources
* 🧭 **One-Click Access** – Navigate directly to websites
* 📱 **Responsive Design** – Works smoothly on all devices
* 🔒 **Secure Backend** – ASP.NET Core with EF Core
* ⚡ **SSR Support** – Angular Universal for fast rendering

---

## 🛠️ Tech Stack

**Frontend**

* Angular 17
* Angular Universal (SSR)
* TypeScript
* Tailwind CSS / SCSS

**Backend**

* ASP.NET Core 8
* Entity Framework Core
* RESTful APIs
* SQL Server / SQLite

**DevOps & Tools**

* Docker (Optional)
* Git & GitHub Actions (CI/CD)
* Node.js & npm

---

## 🚀 Installation & Setup

### 🔧 Backend – ASP.NET Core

```bash
cd linksProject-server
dotnet restore
dotnet ef database update
dotnet run
```

Server will run at: `https://localhost:5001`

### 🌐 Frontend – Angular + SSR

```bash
cd links-project-client
npm install
npm run dev:ssr
```

Frontend will run at: `http://localhost:4200`

---

## 📂 Project Structure

```
LinkForU/
│── linksProject-server/      # ASP.NET Core backend
│   ├── Controllers/          # API controllers
│   ├── Models/               # Entity models
│   ├── Data/                 # EF Core DbContext
│   └── Program.cs            # Entry point
│
│── links-project-client/     # Angular frontend
│   ├── src/app/              # Angular app source code
│   ├── src/environments/     # Environment configs
│   └── angular.json          # Angular config
│
└── README.md
```

---

## ⚡ Environment Variables

Create an `.env` file (or use `appsettings.json` for ASP.NET Core) with the following keys:

```env
# ASP.NET Core
ConnectionStrings__DefaultConnection=Server=.;Database=LinkForU;Trusted_Connection=True;

# Angular
API_BASE_URL=http://localhost:5001/api
```

---

## 🤝 Contributing

Contributions are welcome! To get started:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/my-feature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to your branch (`git push origin feature/my-feature`)
5. Open a Pull Request 🎉

---

## 👥 Contributors

* **Project Owner:** Noa Herbert & ([riki250](https://github.com/riki250))
* **Collaborators:** Open for contributions

---

## 💡 Future Ideas

* 🔗 User profiles & personalized link collections
* 🌙 Dark mode toggle
* 📊 Analytics for link popularity
* 🔒 Authentication & role-based access
* 📱 Mobile PWA support

---

## 📜 License

This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.
