# FitnessManager
Web application for managing your workouts.

## Getting Started

Before you start, make sure you have the following installed:

**PostgreSQL:** The application relies on a PostGreSQL database.
    
- We recommend to use **[Docker](https://www.docker.com/products/docker-desktop/).** to containerize your database for easy setup.
- After you download docker, you can use this command to pull the postgres image:
```bash
docker pull postgres
```
- After pulling the image you can run your docker using this command:
```bash
docker run --name fitnessManagerDB -e POSTGRES_PASSWORD="Enter your password here" -p 5432:5432 -d postgres
```
- Make notice that you can change your password.



Follow these steps to set up and run FitnessManager:

# 1. Clone the Repository

```bash
- git clone https://github.com/your-username/FitnessManager.git
- cd FitnessManager
```

# 2. Setting up your appsettings.json

All you have to do is enter any password.
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=fitnessManagerDB;Username=postgres;Password="Enter your password here";Port=5432;"
},
