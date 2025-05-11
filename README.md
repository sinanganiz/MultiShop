# MultiShop - Microservices Based E-Commerce Platform

MultiShop is a comprehensive e-commerce application built with a microservices architecture using ASP.NET Core. This project simulates a real-world, scalable, and modular e-commerce platform, showcasing modern development practices and industry-grade tools.

## 🚀 Technologies & Tools

This project is developed following **best practices** in distributed systems. Below is a breakdown of the key technologies and patterns used across the services:

- **ASP.NET Core Web APIs**
- **Microservices Architecture**
- **Onion Architecture**
- **CQRS & Mediator Pattern**
- **Repository Pattern**
- **API Gateway (Ocelot)**
- **IdentityServer4** for Authentication & Authorization
- **JWT Bearer Tokens**
- **Redis**
- **MongoDB**, **PostgreSQL**, **MSSQL**, **SQLite**
- **Entity Framework Core** & **Dapper**
- **SignalR**
- **Google Drive Integration** for media storage
- **Swagger** for API documentation
- **Postman** collections for API testing
- **AJAX** interactions for dynamic UI behaviors
- **RapidAPI** integrations
- **Role-based Access Control (RBAC)** for Admin, Users, and Guests

## 🧱 Microservices Overview

MultiShop is composed of independently deployable services, each responsible for a specific domain:

- **Catalog Service**
- **Basket Service**
- **Discount Service**
- **Order Service**
- **Payment Service**
- **Identity Service**
- **User Management Service**
- **Photo Stock Service**
- **Notification Service (SignalR)**
- **Gateway Service (Ocelot)**
- **Token Service**
- **Admin Panel & UI Layer**

Each service runs in its own container, communicates via HTTP or messaging, and follows domain-driven design principles. The system is designed for scalability, fault tolerance, and maintainability.

## 📦 Architecture Highlights

- Modular structure with clearly defined service boundaries
- Loose coupling through API Gateway and internal service interfaces
- Secure and token-based authentication using IdentityServer4 + JWT
- Rich API documentation with Swagger

## 🧑‍💻 Author

Developed by Sinan Ganiz
Inspired by the Udemy course: "Asp.Net Core MultiShop Mikroservis E-Ticaret Kursu"
