# 🧠 Job Application Tracker (JAT)

A high-performance, lightweight ASP.NET Core Web API for managing job postings and candidate applications. Built using **Dapper**, this project demonstrates **database optimization** techniques like **indexing** and **caching** in a real-world scenario.

---

## 🚀 Features

- Track job posts and candidate applications
- Fast querying via **indexed columns**
- Minimized DB load using **in-memory caching**
- Lightweight and **high-performance** with **Dapper micro-ORM**
- Clean REST API with Swagger

---

## 🛠 Tech Stack

- **.NET 6+ / ASP.NET Core Web API**
- **Dapper** (micro ORM)
- **SQL Server** (or PostgreSQL with minor changes)
- **MemoryCache** (for caching)
- **Swagger** for API testing

---

## 🏗️ Project Structure

```plaintext

Controllers
│
├── ApplicationsController.cs
Services
├── JobService.cs // Caching active job posts
├── ApplicationService.cs // Dapper-based DB access
Models
├── JobPost.cs
└── Application.cs

