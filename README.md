# Angular + ASP.NET Core User Management System

A full-stack User Management application built using Angular, ASP.NET Core Web API, and SQL Server.

## Features
- Add, update, delete users
- Bulk delete using checkboxes
- Select all / unselect all users
- Live UI updates without page refresh
- REST API integration

## 🛠️ Technologies Used

### Frontend
- Angular
- TypeScript
- HTML, CSS
- Angular Forms
- HttpClient

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- Swagger

### Database
- SQL Server

### Tools
- Visual Studio
- Visual Studio Code
- Git & GitHub

angular-dotnet-user-management
├── user-ui (Angular frontend)
├── Backend (ASP.NET Core API)


## ▶️ How to Run

### Frontend
cd user-ui
npm install
ng serve


### Backend
- Open backend project in Visual Studio
- Run the project
- Swagger URL:
http://localhost:5062/swagger


## 👨‍💻 Author
Puli Phanindra Ratna Gopi


Click Commit new file.

## 📂 Project Structure

ProjectRoot
├── Backend (ASP.NET Core API)
├── user-ui (Angular Frontend)
---

## ⚙️ Backend Setup (ASP.NET Core API)

1. Open Backend project in Visual Studio
2. Update `appsettings.json` with SQL Server connection string
3. Run migrations:


Add-Migration Initial
Update-Database

4. Run the project
5. Swagger will open at:


http://localhost:5062/swagger

---

## ⚙️ Frontend Setup (Angular)

1. Open `user-ui` folder in VS Code
2. Install dependencies:


npm install

3. Run Angular app:

ng serve

4. Open browser:

http://localhost:4200

---

## 🔗 API Endpoints

| Method | Endpoint |
|------|---------|
| GET | /api/Users/GetUsers |
| POST | /api/Users/AddUser |
| PUT | /api/Users/UpdateUser |
| DELETE | /api/Users/DeleteUser/{id} |

---

## 💡 Key Learnings

- Angular standalone components
- Handling bulk operations in UI
- REST API integration
- CORS configuration
- Clean architecture & separation of concerns

This is a full-stack Angular and ASP.NET Core application where I implemented CRUD operations and bulk delete functionality using checkboxes. The frontend communicates with REST APIs and updates data dynamically without page refresh.
