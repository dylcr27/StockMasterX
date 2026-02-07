# 📦 StockMasterX - Inventory Management System

[Versión en Español](README.es.md)

A complete web-based inventory management system built with ASP.NET Core MVC, designed for small and medium-sized businesses.

## ✨ Key Features

- **Interactive Dashboard**: Overview with key metrics and low stock alerts
- **Product Management**: Complete CRUD with real-time stock tracking
- **Categories**: Efficient product organization
- **Suppliers**: Supplier information management
- **Inventory Movements**: Record entries, exits, and adjustments
- **Stock Alerts**: Automatic notifications when stock falls below minimum
- **Responsive Interface**: Mobile-friendly design
- **Data Export**: Excel report generation (coming soon)

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core 8.0 MVC
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Frontend**: Bootstrap 5, HTML5, CSS3, JavaScript
- **Patterns**: Repository Pattern, Dependency Injection

## 📋 Prerequisites

- .NET 8.0 SDK
- SQL Server 2019 or higher (or SQL Server Express)
- Visual Studio 2022 (recommended) or VS Code

## 🚀 Installation and Setup

1. **Clone the repository**
```bash
git clone [YOUR_REPO_URL]
cd StockMasterX
```

2. **Configure the connection string**
Edit `appsettings.json` and set your SQL Server connection:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InventorySystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. **Apply migrations**
```bash
dotnet ef database update
```

4. **Run the application**
```bash
dotnet run
```

The application will be available at `https://localhost:5001`

## 📊 Project Structure
```
StockMasterX/
├── Controllers/        # MVC Controllers
├── Models/            # Data Models
├── Views/             # Razor Views
├── Data/              # DB Context and Seeders
├── Services/          # Business Logic
├── ViewModels/        # ViewModels
└── wwwroot/           # Static Files
```

## 💡 Detailed Features

### Products
- Add, edit, and delete products
- Track purchase and sale prices
- Monitor current stock vs minimum stock
- Associate with categories and suppliers
- Visual indicators for low stock

### Inventory Movements
- Record entries (purchases)
- Record exits (sales)
- Inventory adjustments
- Complete movement history
- Reasons and observations

### Dashboard
- Total products in system
- Number of categories and suppliers
- Products with low stock
- Recent movements
- Real-time metrics

### Categories & Suppliers
- Complete CRUD operations
- Product count per category/supplier
- Active/inactive status management
- Creation date tracking

## 🔐 Security

- Authentication via ASP.NET Core Identity
- Server and client-side data validation
- SQL Injection protection via EF Core
- Password encryption

## 🎯 Use Cases

This system is ideal for:
- Small retail businesses
- Warehouses
- Service companies with inventory
- Startups managing products
- Educational institutions

## 📸 Screenshots

### Dashboard
![Dashboard](screenshots/dashboard.png)

### Product Management
![Products](screenshots/products.png)

### Inventory Movements
![Movements](screenshots/movements.png)

*Note: Add screenshots to a `screenshots` folder in the root*

## 🚦 Getting Started - Quick Guide

1. Register a new user account
2. Add categories for your products
3. Add suppliers
4. Create products with their details
5. Record inventory movements (entries/exits)
6. Monitor stock levels from the dashboard

## 📈 Future Enhancements

- [ ] Excel export functionality
- [ ] Barcode scanning
- [ ] Multi-user roles (Admin, Operator, Viewer)
- [ ] Advanced reporting
- [ ] Email notifications for low stock
- [ ] API for third-party integrations
- [ ] Multi-language support
- [ ] Dark mode

## 🐛 Known Issues

- Excel export requires EPPlus license configuration (currently disabled)

## 🤝 Contributing

Contributions are welcome! Please open an issue first to discuss what you would like to change.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👤 Author

**Dylan**
- Software Analyst at INCAE Business School
- Specialized in ASP.NET Core, SQL Server, and Web Development
- LinkedIn: [Your Profile]
- Portfolio: [Your Website]
- GitHub: [@yourusername](https://github.com/yourusername)

## 📞 Contact & Support

For support or inquiries:
- Email: [your.email@example.com]
- Open an issue in this repository

## 🙏 Acknowledgments

- Built with ASP.NET Core MVC
- UI design inspired by modern dashboard principles
- Data seeding for quick testing and demo purposes

---

⭐ If you find this project useful, please give it a star!

Made with ❤️ in Costa Rica