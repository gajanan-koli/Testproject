# Testproject

#Tools used
1. Entity framework core
2. DBup 
3. .Net core
4. Clean architecture
5. repository pattern
6. web api
7. react

## first run SCM.DB.DEploy project to deploy Database 

#Project structure

1. SCM.Domain : created internal contract and interface/service
2. SCM.Web.api : used to login to generate token and access notes endpoint
3. SCM.Repository: Added all business logic to access DB using entity core
4. SCM.DB.Deploy : used to create database using DBup
5. SCM.WEb.Client: it contain front end using react
