\# 🧠 Job Application Tracker (JAT)

A high-performance, lightweight ASP.NET Core Web API for managing job postings and candidate applications. Built using \*\*Dapper\*\*, this project demonstrates \*\*database optimization\*\* techniques like \*\*indexing\*\* and \*\*caching\*\* in a real-world scenario.

\---

\## 🚀 Features

\- Track job posts and candidate applications

\- Fast querying via \*\*indexed columns\*\*

\- Minimized DB load using \*\*in-memory caching\*\*

\- Lightweight and \*\*high-performance\*\* with \*\*Dapper micro-ORM\*\*

\- Clean REST API with Swagger

\---

\## 🛠 Tech Stack

\- \*\*.NET 6+ / ASP.NET Core Web API\*\*

\- \*\*Dapper\*\* (micro ORM)

\- \*\*SQL Server\*\* (or PostgreSQL with minor changes)

\- \*\*MemoryCache\*\* (for caching)

\- \*\*Swagger\*\* for API testing

\---

\## 📐 Architecture

Controllers

│

├── ApplicationsController.cs

Services

├── JobService.cs // Caching active job posts

├── ApplicationService.cs // Dapper-based DB access

Models

├── JobPost.cs

└── Application.cs

pgsql

Copy

Edit

\---

\## ⚡ Performance Optimizations

\### ✅ Indexing

Speeds up data lookups by avoiding full table scans.

\`\`\`sql

\-- Fast lookup by email

CREATE INDEX IX\_Applications\_Email ON Applications(Email);

\-- Filter by job and status

CREATE INDEX IX\_Applications\_JobId\_Status ON Applications(JobId, Status);

✅ Caching

Reduces redundant queries for data that doesn't change often.

csharp

Copy

Edit

if (!\_cache.TryGetValue("active\_jobs", out List jobs)) {

jobs = await \_connection.QueryAsync("SELECT ...");

\_cache.Set("active\_jobs", jobs, TimeSpan.FromMinutes(10));

}

🧪 API Endpoints

EndpointMethodDescription

/api/applications/by-email?email=GETGet application by candidate email

/api/applications/by-job?jobId=1&status=InterviewedGETGet applications for a job/status

/api/applications/active-jobsGETGet cached list of active job posts

/api/applicationsPOSTSubmit a new application

🛠 Setup Instructions

Prerequisites

.NET 6+ SDK

SQL Server or compatible RDBMS

Steps

Clone the repo

bash

Copy

Edit

git clone https://github.com/your-username/job-application-tracker.git

cd job-application-tracker

Update Connection String

Edit appsettings.json:

json

Copy

Edit

"ConnectionStrings": {

"DefaultConnection": "Server=localhost;Database=JobAppDb;Trusted\_Connection=True;"

}

Create Database Schema

Use SQL Server Management Studio or any SQL client to run:

sql

Copy

Edit

\-- Tables and indexes (see schema in the code base)

Run the App

bash

Copy

Edit

dotnet run

Test the API

Navigate to https://localhost:{port}/swagger

📌 Notes

Replace DATEADD(DAY, -30, GETDATE()) with the PostgreSQL equivalent if needed.

Use Redis or distributed cache if deploying to multi-instance environments.
