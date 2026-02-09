# 📦 StockMasterX - Inventory Management System

A complete web-based inventory management system developed with **ASP.NET Core MVC**, designed for small and medium-sized businesses.

## ✨ Key Features

- **Interactive Dashboard**: Overview with key metrics and low-stock alerts  
- **Product Management**: Full CRUD with real-time stock tracking  
- **Categories**: Efficient product organization  
- **Suppliers**: Supplier information management  
- **Inventory Movements**: Tracking of inbound, outbound, and adjustment operations  
- **Stock Alerts**: Automatic notifications when stock falls below the minimum  
- **Responsive Interface**: Mobile-friendly adaptive design  
- **Data Export**: Excel report generation  

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core 8.0 MVC  
- **Database**: SQL Server with Entity Framework Core  
- **Authentication**: ASP.NET Core Identity  
- **Frontend**: Bootstrap 5, HTML5, CSS3, JavaScript  
- **Patterns**: Repository Pattern, Dependency Injection  

## 📋 Prerequisites

- .NET 8.0 SDK  
- SQL Server 2019 or later (or SQL Server Express)  
- Visual Studio 2022 (recommended) or VS Code  

## 🚀 Installation and Setup

1. **Clone the repository**
```bash
git clone [YOUR_REPOSITORY_URL]
cd StockMasterX
Configure the connection string
Edit appsettings.json and configure your SQL Server connection:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InventorySystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
Apply migrations

dotnet ef database update
Run the application

dotnet run
The application will be available at https://localhost:5001

📊 Project Structure
StockMasterX/
├── Controllers/        # MVC Controllers
├── Models/             # Data models
├── Views/              # Razor views
├── Data/               # Database context and seeders
├── Services/           # Business logic
├── ViewModels/         # ViewModels
└── wwwroot/            # Static files
💡 Detailed Features
Products
Add, edit, and delete products

Purchase and selling price tracking

Current stock vs minimum stock control

Category and supplier association

Visual indicators for low stock

Inventory Movements
Inbound records (purchases)

Outbound records (sales)

Inventory adjustments

Complete movement history

Reasons and notes

Dashboard
Total products in the system

Number of categories and suppliers

Products with low stock

Recent inventory movements

Real-time metrics

Categories and Suppliers
Full CRUD operations

Product count per category/supplier

Active/inactive status management

Creation date tracking

🔐 Security
Authentication using ASP.NET Core Identity

Server-side and client-side data validation

SQL Injection protection through Entity Framework Core

Password encryption

🎯 Use Cases
This system is ideal for:

Small retail businesses

Warehouses and storage facilities

Service companies with inventory

Startups managing products

Educational institutions

🚦 Quick Start Guide
Register a user account

Add product categories

Add suppliers

Create products with details

Register inventory movements (inbound/outbound)

Monitor stock levels from the dashboard

📈 Future Improvements
 Excel export functionality

 Barcode scanning

 Multi-user roles (Admin, Operator, Viewer)

 Advanced reporting

 Email notifications for low stock

 API for third-party integrations

 Multi-language support

 Dark mode

🐛 Known Issues
Excel export requires EPPlus license configuration (currently disabled)

🤝 Contributions
Contributions are welcome!
Please open an issue first to discuss any changes you would like to make.

📄 License
This project is licensed under the MIT License.
See the LICENSE file for more details.

👤 Author
Dylan Molina Obando

Specialized in ASP.NET Core, SQL Server, and Web Development

LinkedIn: https://www.linkedin.com/in/dylan-molina-o/

Portfolio: [Your Website]

GitHub: https://github.com/dylcr27

📞 Contact and Support
For support or inquiries:

Email: dylanmo2794@gmail.com

Open an issue in this repository

🙏 Acknowledgements
Built with ASP.NET Core MVC

UI design inspired by modern dashboard principles

Data seeding for quick testing and demo purposes

⭐ If you find this project useful, please give it a star!

Made with ❤️ in Costa Rica 🇨🇷

Developed by Dylan Molina Obando

LinkedIn: https://www.linkedin.com/in/dylan-molina-o/