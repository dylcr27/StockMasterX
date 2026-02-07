# 📦 StockMasterX - Sistema de Gestión de Inventario

[English Version](README.md)

Sistema web completo para la gestión de inventario desarrollado con ASP.NET Core MVC, diseñado para pequeñas y medianas empresas.

## ✨ Características Principales

- **Dashboard Interactivo**: Vista general con métricas clave y alertas de stock bajo
- **Gestión de Productos**: CRUD completo con seguimiento de stock en tiempo real
- **Categorías**: Organización eficiente de productos
- **Proveedores**: Administración de información de proveedores
- **Movimientos de Inventario**: Registro de entradas, salidas y ajustes
- **Alertas de Stock**: Notificaciones automáticas cuando el stock está bajo el mínimo
- **Interfaz Responsive**: Diseño adaptable a dispositivos móviles
- **Exportación de Datos**: Generación de reportes en Excel (próximamente)

## 🛠️ Tecnologías Utilizadas

- **Backend**: ASP.NET Core 8.0 MVC
- **Base de Datos**: SQL Server con Entity Framework Core
- **Autenticación**: ASP.NET Core Identity
- **Frontend**: Bootstrap 5, HTML5, CSS3, JavaScript
- **Patrones**: Repository Pattern, Dependency Injection

## 📋 Requisitos Previos

- .NET 8.0 SDK
- SQL Server 2019 o superior (o SQL Server Express)
- Visual Studio 2022 (recomendado) o VS Code

## 🚀 Instalación y Configuración

1. **Clonar el repositorio**
```bash
git clone [URL_DE_TU_REPO]
cd StockMasterX
```

2. **Configurar la cadena de conexión**
Edita `appsettings.json` y configura tu conexión a SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InventorySystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. **Aplicar migraciones**
```bash
dotnet ef database update
```

4. **Ejecutar la aplicación**
```bash
dotnet run
```

La aplicación estará disponible en `https://localhost:5001`

## 📊 Estructura del Proyecto
```
StockMasterX/
├── Controllers/        # Controladores MVC
├── Models/            # Modelos de datos
├── Views/             # Vistas Razor
├── Data/              # Contexto de BD y seeders
├── Services/          # Lógica de negocio
├── ViewModels/        # ViewModels
└── wwwroot/           # Archivos estáticos
```

## 💡 Funcionalidades Detalladas

### Productos
- Agregar, editar y eliminar productos
- Seguimiento de precios de compra y venta
- Control de stock actual vs stock mínimo
- Asociación con categorías y proveedores
- Indicadores visuales de stock bajo

### Movimientos de Inventario
- Registro de entradas (compras)
- Registro de salidas (ventas)
- Ajustes de inventario
- Historial completo de movimientos
- Razones y observaciones

### Dashboard
- Total de productos en sistema
- Número de categorías y proveedores
- Productos con stock bajo
- Movimientos recientes
- Métricas en tiempo real

### Categorías y Proveedores
- Operaciones CRUD completas
- Conteo de productos por categoría/proveedor
- Gestión de estado activo/inactivo
- Seguimiento de fecha de creación

## 🔐 Seguridad

- Autenticación mediante ASP.NET Core Identity
- Validación de datos en servidor y cliente
- Protección contra SQL Injection mediante EF Core
- Encriptación de contraseñas

## 🎯 Casos de Uso

Este sistema es ideal para:
- Pequeños negocios de retail
- Bodegas y almacenes
- Empresas de servicios con inventario
- Startups que gestionan productos
- Instituciones educativas

## 📸 Capturas de Pantalla

### Dashboard
![Dashboard](screenshots/dashboard.png)

### Gestión de Productos
![Productos](screenshots/products.png)

### Movimientos de Inventario
![Movimientos](screenshots/movements.png)

*Nota: Agregar capturas de pantalla en la carpeta `screenshots` en la raíz*

## 🚦 Guía de Inicio Rápido

1. Registra una cuenta de usuario
2. Agrega categorías para tus productos
3. Agrega proveedores
4. Crea productos con sus detalles
5. Registra movimientos de inventario (entradas/salidas)
6. Monitorea los niveles de stock desde el dashboard

## 📈 Mejoras Futuras

- [ ] Funcionalidad de exportación a Excel
- [ ] Escaneo de códigos de barras
- [ ] Roles multi-usuario (Admin, Operador, Visualizador)
- [ ] Reportería avanzada
- [ ] Notificaciones por email para stock bajo
- [ ] API para integraciones de terceros
- [ ] Soporte multi-idioma
- [ ] Modo oscuro

## 🐛 Problemas Conocidos

- La exportación a Excel requiere configuración de licencia EPPlus (actualmente deshabilitada)

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Por favor, abre un issue primero para discutir los cambios que te gustaría hacer.

1. Fork el proyecto
2. Crea tu rama de feature (`git checkout -b feature/CaracteristicaAsombrosa`)
3. Commit tus cambios (`git commit -m 'Agregar alguna CaracteristicaAsombrosa'`)
4. Push a la rama (`git push origin feature/CaracteristicaAsombrosa`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo LICENSE para más detalles.

## 👤 Autor

**Dylan**
- Analista de Software en INCAE Business School
- Especializado en ASP.NET Core, SQL Server y Desarrollo Web
- LinkedIn: [Tu Perfil]
- Portafolio: [Tu Sitio Web]
- GitHub: [@tuusuario](https://github.com/tuusuario)

## 📞 Contacto y Soporte

Para soporte o consultas:
- Email: [tu.email@ejemplo.com]
- Abre un issue en este repositorio

## 🙏 Agradecimientos

- Construido con ASP.NET Core MVC
- Diseño UI inspirado en principios modernos de dashboard
- Data seeding para pruebas rápidas y propósitos de demostración

---

⭐ Si encuentras útil este proyecto, ¡por favor dale una estrella!

Hecho con ❤️ en Costa Rica