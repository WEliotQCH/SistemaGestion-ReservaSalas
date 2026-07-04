# 🏢 Sistema de Reservas de Salas

Sistema web desarrollado para gestionar la reserva de salas mediante una arquitectura cliente-servidor.

El proyecto está dividido en un **Backend** desarrollado con **ASP.NET Core** siguiendo los principios de **Clean Architecture** y un **Frontend** desarrollado con **React + Material UI**.

---

# 🚀 Tecnologías utilizadas

## Backend

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MediatR (CQRS)
- JWT Authentication
- Swagger

## Frontend

- React
- Vite
- Material UI
- React Router
- Axios
- React Context API

---

# 📁 Arquitectura del Proyecto

```
SistemaReservasSalas
│
├── SistemaReservasSalas.API
├── SistemaReservasSalas.Application
├── SistemaReservasSalas.Domain
├── SistemaReservasSalas.Infrastructure
│
└── SistemaReservasSalas.Web
```

---

# Backend

El backend implementa **Clean Architecture**, separando cada responsabilidad en capas.

## Domain

Contiene:

- Entidades
- Enumeraciones
- Interfaces

Ejemplo:

- User
- Room
- Schedule
- Reservation

---

## Application

Contiene toda la lógica del negocio.

Se utiliza el patrón **CQRS** mediante **MediatR**.

Cada funcionalidad está dividida en:

```
Features
│
├── Users
│
├── Rooms
│
├── Schedules
│
├── RoomSchedules
│
└── Reservations
```

Cada módulo contiene:

```
Commands
Queries
Handlers
Validators
```

---

## Infrastructure

Implementa el acceso a datos mediante Entity Framework Core.

Incluye:

- DbContext
- Repositories
- Configuraciones
- Migraciones

---

## API

Expone los endpoints REST consumidos por el frontend.

Ejemplo:

```
GET /Users

POST /Users

PUT /Users

DELETE /Users
```

---

# Autenticación

La autenticación se realiza mediante **JWT**.

Flujo:

```
Login

↓

Validación de usuario

↓

Generación del Token JWT

↓

Frontend almacena el Token

↓

Cada petición protegida envía:

Authorization: Bearer {token}
```

El JWT contiene:

- UserId
- Email
- Rol

---

# Frontend

La aplicación está organizada por módulos.

```
src
│
├── api
│
├── components
│
│   ├── common
│   ├── layout
│   ├── rooms
│   ├── roomSchedules
│   ├── schedules
│   ├── users
│   └── reservations
│
├── config
│
├── context
│
├── hooks
│
├── layouts
│
├── pages
│
├── routes
│
└── services
```

---

## Organización

### Services

Se encargan de consumir la API utilizando Axios.

Ejemplo:

```
userService.js

roomService.js

scheduleService.js

reservationService.js
```

---

### Hooks

Contienen la lógica de negocio del frontend.

Ejemplo:

```
useUsers()

useRooms()

useSchedules()

useRoomSchedules()

useReservations()
```

---

### Components

Componentes reutilizables de la interfaz.

Ejemplo:

- Formularios
- Tablas
- Navbar
- Sidebar
- Dialogs

---

### Pages

Cada módulo posee su propia página.

```
Users

Rooms

Schedules

RoomSchedules

Reservations
```

---

# Funcionalidades

## Autenticación

- Inicio de sesión
- JWT
- Roles
- Protección de rutas

---

## Usuarios

- Listar usuarios
- Registrar usuario

---

## Salas

- Listar salas
- Registrar sala

---

## Horarios

- Listar horarios
- Registrar horario

---

## Asignación de Horarios

Permite asociar horarios disponibles a una sala.

Funciones:

- Asignar horario
- Eliminar asignación
- Consultar horarios por sala

---

## Reservas

Permite:

- Registrar reservas
- Consultar disponibilidad
- Cancelar reservas
- Listar reservas

---

# Flujo de una petición

```
Frontend

↓

Axios

↓

Controller

↓

MediatR

↓

Command / Query

↓

Handler

↓

Repository

↓

Entity Framework Core

↓

SQL Server
```

---

# Instalación

## Backend

1. Clonar el repositorio

```
git clone <repositorio>
```

2. Restaurar paquetes

```
dotnet restore
```

3. Configurar la cadena de conexión en:

```
appsettings.json
```

4. Ejecutar migraciones

```
dotnet ef database update
```

5. Ejecutar la API

```
dotnet run
```

---

## Frontend

Instalar dependencias

```
npm install
```

Crear el archivo:

```
.env
```

Agregar:

```
VITE_API_URL=http://localhost:5093/api
```

Ejecutar:

```
npm run dev
```

---

# Capturas

Aquí pueden agregarse imágenes de:

<img width="1366" height="639" alt="image" src="https://github.com/user-attachments/assets/b262b9c4-2ed6-4f47-8e3e-467c870b810a" />

<img width="1366" height="640" alt="image" src="https://github.com/user-attachments/assets/036fbd53-ca65-469a-8d06-eca6c5c1300d" />


---

# Autor

**William Quispe Chino**

Proyecto desarrollado como parte del curso de Desarrollo de Software.
