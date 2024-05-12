## How to run
1. Clone the repository
2. Run `npm install` in frontend directory
3. Run postgres database img using docker-compose:  
```bash
docker-compose up -d
```  
4. run database migrations:  
```bash
dotnet ef database update --project backend/src/Vanto.Api
```
5. Run backend:  
```bash
dotnet run --project backend/src/Vanto.Api
```
6. Run frontend in frontend directory  
```bash
npm run start
```