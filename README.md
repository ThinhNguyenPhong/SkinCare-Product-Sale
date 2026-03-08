# SkinCare Product Sale

## Description

SkinCare Product Sale is a web application for managing and selling skincare products, built with ASP.NET Core and Entity Framework Core. It streamlines product catalog management, order processing, customer relationships, and promotional campaigns.

## Key Features

* **Product Management**: Create, edit, delete, and categorize products.
* **Shopping Cart**: Add products to the cart, adjust quantities, and view order totals.
* **Order Processing**: Create orders, track status updates, and manage order history.
* **Customer Management**: Maintain customer profiles, shipping addresses, and purchase history.
* **Promotion System**: Create discount codes and apply promotional offers to orders.
* **Payment Handling**: Integrate with payment gateways and manage payment statuses.
* **Authentication & Authorization**: Role-based access control with Admin, Customer, and Employee roles.
* **Admin Dashboard**: A comprehensive interface for administrators to manage all aspects of the system.

## Project Structure

```
SkinCare-Product-Sale/
├── Business_Layer/         # Business logic layer
│   ├── Services/           # Business service implementations
│   └── Business_Layer.csproj
├── Data_Access_Layer/      # Data access layer
│   ├── DBContext/          # Entity Framework database context
│   ├── Entities/           # Entity models
│   ├── Migrations/         # EF Core migrations
│   ├── Repositories/       # Repository classes
│   ├── Requests/           # Request DTOs
│   └── Responses/          # Response DTOs
└── SkinCare-Product-Sale/  # Web application
    ├── Controllers/        # MVC controllers
    ├── Models/             # View models
    ├── Views/              # Razor views
    └── wwwroot/            # Static files (CSS, JS, images)
```

## Technologies Used

* ASP.NET Core 6.0+
* Entity Framework Core
* SQL Server / SQL Server Express
* Bootstrap 5
* jQuery
* HTML, CSS, JavaScript




