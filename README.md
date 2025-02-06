

# Chaufferie Charges Management System (CCMS)

Welcome to the **Chaufferie Charges Management System (CCMS)**! This is a .NET Core 3.1 backend project built using the **CQRS (Command Query Responsibility Segregation)** architecture. It is designed to manage and track various operational charges and resources in a chaufferie (boiler room) environment.

---

## 🛠️ **Project Structure**

The project is organized into multiple layers, following the **CQRS pattern** and **clean architecture principles**. Below is an overview of the key components:

### **1. Data Layer (`Chaufferie.ChargeMS.Data`)**
- **Context**: Contains the `ChargesContext` for database interactions.
- **Repository**: Includes repositories for specific entities:
  - `ChaudiereRepository.cs`
  - `FicheSuiviRepository.cs`
  - `GenericRepository.cs`
  - `UserRepository.cs`
- **Project File**: `Chaufferie.ChargeMS.Data.csproj`

### **2. API Layer (`Chaufferie.ChargesMS.Api`)**
- **Controllers**: Contains API controllers for various entities:
  - `BureauControleController.cs`
  - `ChAmortissementController.cs`
  - `ChAssistExterneController.cs`
  - `ChCombustibleController.cs`
  - `ChConsommationsEauController.cs`
  - `ChElecController.cs`
  - `ChPersonnelController.cs`
  - `ChPieceRechangeController.cs`
  - `ConsommableController.cs`
  - `FilialesController.cs`
  - `TypeConsommableController.cs`
  - `TypeInterventionController.cs`
- **Mapper**: Contains `MappingProfiles.cs` for AutoMapper configurations.
- **Properties**: Includes `launchSettings.json` for runtime configurations.
- **Project File**: `Chaufferie.ChargesMS.Api.csproj`
- **Startup Files**: `Program.cs` and `Startup.cs` for application configuration.
- **App Settings**: Configuration files for different environments:
  - `appsettings.Development.json`
  - `appsettings.Production.json`
  - `appsettings.json`

### **3. Domain Layer (`Chaufferie.ChargesMS.Domain`)**
- **Commands**: Contains commands for CQRS operations:
  - `AddGenericCommand.cs`
  - `PutGenericCommand.cs`
  - `RemoveGenericCommand.cs`
- **Dtos**: Data Transfer Objects (DTOs) for various entities.
- **Handlers**: Command and query handlers for CQRS:
  - `AddGenericHandler.cs`
  - `GetGenericHandler.cs`
  - `GetListGenericHandler.cs`
  - `PutGenericHandler.cs`
  - `RemoveGenericHandler.cs`
- **Interfaces**: Contains `IGenericRepository.cs` for repository abstraction.
- **Models**: Entity models for the domain:
  - `BureauControle.cs`
  - `ChAmortissement.cs`
  - `ChAssistExterne.cs`
  - `ChCombustible.cs`
  - `ChEau.cs`
  - `ChElectrique.cs`
  - `ChPersonnel.cs`
  - `ChPieceRechange.cs`
  - `Consommable.cs`
  - `Filiale.cs`
  - `TypeConsommable.cs`
  - `TypeIntervention.cs`
- **Queries**: Contains queries for CQRS:
  - `GetGenericQuery.cs`
  - `GetListGenericQuery.cs`
- **Project File**: `Chaufferie.ChargesMS.Domain.csproj`

### **4. Infrastructure Layer (`Chaufferie.ChargesMS.Infra.IoC`)**
- **Dependency Injection**: Contains `DependencyContainer.cs` for IoC configuration.
- **Project File**: `Chaufferie.ChargesMS.Infra.IoC.csproj`

### **5. Root Files**
- `.gitattributes`
- `.gitignore`
- `.gitlab-ci.yml`: CI/CD pipeline configuration.
- `Dockerfile`: For containerizing the application.
- `Poulina.Energie.Chaufferie.sln`: Solution file.
- `k8s.yaml`: Kubernetes deployment configuration.

---

## 🚀 **Getting Started**

Follow these steps to set up the project locally:

### **Prerequisites**
- .NET Core 3.1 SDK
- Docker (optional, for containerization)
- Kubernetes (optional, for deployment)

### **Steps**
1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/Chaufferie-ChargesMS.git
   cd Chaufferie-ChargesMS
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run --project Chaufferie.ChargesMS.Api
   ```

4. **Access the API**:
   - Open your browser or API client (e.g., Postman).
   - Navigate to `http://localhost:5000` (or the specified port).

5. **Docker Setup (optional)**:
   - Build the Docker image:
     ```bash
     docker build -t chaufferie-charges-ms .
     ```
   - Run the container:
     ```bash
     docker run -p 5000:80 chaufferie-charges-ms
     ```

6. **Kubernetes Deployment (optional)**:
   - Apply the Kubernetes configuration:
     ```bash
     kubectl apply -f k8s.yaml
     ```

---

## 🛠️ **Technologies Used**
- **.NET Core 3.1**
- **CQRS Architecture**
- **Entity Framework Core**
- **AutoMapper**
- **Docker**
- **Kubernetes**
- **GitLab CI/CD**

---

## 🤝 **Contributing**

Contributions are welcome! If you'd like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/YourFeature
   ```
3. Make your changes and commit them:
   ```bash
   git commit -m 'Add some feature'
   ```
4. Push to the branch:
   ```bash
   git push origin feature/YourFeature
   ```
5. Open a pull request.

---

## 📄 **License**

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 **Author**

**Rayen Ameur**  

Feel free to explore, contribute, and make this project even better! 🚀

---

This README is designed to be **clear, concise, and GitHub-friendly**. Let me know if you need further adjustments! 😊
