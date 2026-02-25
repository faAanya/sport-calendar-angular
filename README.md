# Sport Calendar Application

This repository contains the Docker Compose configuration to run the Sport Calendar application locally. The setup orchestrates a Microsoft SQL Server database, an ASP.NET Core backend API, and a frontend application.

## 📋 Prerequisites

Before you begin, ensure you have the following installed on your machine:

* [Docker](https://docs.docker.com/get-docker/) (Docker Desktop for Windows/Mac, or Docker Engine for Linux)
* [Docker Compose](https://docs.docker.com/compose/install/)

## 📁 Expected Directory Structure

```text
.
├── docker-compose.yml
├── .env
├── sport-calendar-backend/
│   ├── Dockerfile
│   └── ... 
└── sport-calendar-frontend/
    ├── Dockerfile
    └── ... 

```

## ⚙️ Configuration (.env file)

Create a file named `.env` in the same directory as the `docker-compose.yml` file and add the following contents:

```env
MSSQL_SA_PASSWORD=yourpassword
DB_CONNECTION=Server=db,1433;Database=SportCalendarDb;User Id=sa;Password=yourpassword;TrustServerCertificate=true;

```

> **⚠️ Important:** The `MSSQL_SA_PASSWORD` in your `.env` file must exactly match the password used in the database `healthcheck` command within your `docker-compose.yml`.

## 🚀 Running the Application

1. Open your terminal in the project root directory.
2. Build and start the containers:
```bash
docker compose up -d --build

```



## 🌐 Accessing the Services

| Service | Internal Port | Local/Host Address |
| --- | --- | --- |
| **Frontend** | 4200 | `http://localhost:4200` |
| **Backend** | 8080 | `http://localhost:5000` |
| **Database** | 1433 | `localhost:1433` (User: `sa`) |

## 🛠️ Helpful Commands


* **Stop the application (preserves database data):**
```bash
docker compose down

```


* **Stop the application and wipe database data:**
```bash
docker compose down -v

```

# Sport Calendar & Workout Tracker

A full-stack web application designed to help users plan, track, and manage their daily fitness goals. The app features a modern, responsive layout with a side-by-side calendar and dashboard view, providing an intuitive and seamless user experience. 

## 🚀 Key Features

* **Interactive Calendar View:** A grid-based monthly calendar that displays visual chips for scheduled workouts. It automatically highlights the current day and updates dynamically as events are added or removed.
* **Daily Details Dashboard:** A sticky, scrollable sidebar that lists the full details of all workouts scheduled for the currently selected date.
* **Schedule Workouts:** A sleek modal form allowing users to add new workouts by selecting an activity type (e.g., Running, Yoga, Strength Training), a target goal, and the appropriate unit of measurement (km, minutes, reps).
* **Dynamic Progress Tracking:** Users can log their current progress against their target goals directly from the dashboard. The UI features a real-time progress bar that fills up as the user gets closer to their target.
* **Automatic Status Updates:** The application automatically calculates completion percentages and updates the visual status badges in real-time:
  * ⚪ **Planned:** 0% progress logged.
  * 🟡 **In Progress:** > 0% but < 100% progress logged.
  * 🟢 **Done:** 100% or more of the target goal reached.
