# Bank-LINQ-Blazor

## 📖 Overview
This project is a modern version of a N-Tier banking application, it replaces traditional presentation layers with a reactive Blazor front-end while keeping a traditional Business Logic Layer and Data Access Layer.

The system is designed to simulate core banking operations including:
* Account Management: Real-time lifecycle management of customer accounts.

* Transaction Auditing: Comprehensive tracking of all ledger movements.

* Fund Transfers: ACID-compliant processing of peer-to-peer transfers.

---
## ☁️ Cloud-Based Database

This project utilizes [CockroachDB](https://cockroachlabs.cloud).

* Why CockroachDB? It offers a free cloud-based, distributed PostgreSQL environment.

* Benefit: It provides serverless scaling and allows for secure, encrypted connection strings, making it ideal for distributed banking simulations.

---

## 🛠 Tech Stack

Frontend: [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor), CSS3

Backend/Logic: C#, .NET 8.0, LINQ

Database: [CockroachDB](https://cockroachlabs.cloud) (PostgreSQL Protocol)

Tools: Visual Studio 2022
