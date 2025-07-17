# SkinCare Product Sale

## Mô tả

SkinCare Product Sale là một ứng dụng web quản lý và bán sản phẩm chăm sóc da, được xây dựng với ASP.NET Core và Entity Framework Core, giúp tự động hóa quy trình quản lý sản phẩm, đơn hàng và khách hàng.

## Tính năng chính

* **Quản lý sản phẩm**: Thêm, sửa, xóa, và phân loại sản phẩm.
* **Chức năng giỏ hàng**: Thêm sản phẩm vào giỏ, điều chỉnh số lượng, và xem tổng tiền.
* **Xử lý đơn hàng**: Tạo, theo dõi trạng thái và quản lý lịch sử đơn hàng.
* **Quản lý khách hàng**: Hồ sơ khách hàng, địa chỉ giao hàng và lịch sử mua sắm.
* **Hệ thống khuyến mãi**: Tạo mã giảm giá, áp dụng khuyến mãi cho đơn hàng.
* **Xử lý thanh toán**: Tích hợp cổng thanh toán, quản lý trạng thái thanh toán.
* **Xác thực và phân quyền**: Hệ thống phân quyền theo vai trò (Admin, Customer, Employee).
* **Bảng điều khiển Admin**: Giao diện quản lý toàn diện cho người quản trị.

## Cấu trúc dự án

```
SkinCare-Product-Sale/
├── Business_Layer/         # Business logic layer
│   ├── Services/           # Business services
│   └── Business_Layer.csproj
├── Data_Access_Layer/      # Data access layer
│   ├── DBContext/          # Database context
│   ├── Entities/           # Entity models
│   ├── Migrations/         # EF Core migrations
│   ├── Repositories/       # Data repositories
│   ├── Requests/           # Request models
│   └── Responses/          # Response models
└── SkinCare-Product-Sale/  # Web application
    ├── Controllers/        # MVC controllers
    ├── Models/             # View models
    ├── Views/              # Razor views
    └── wwwroot/            # Static files
```

## Công nghệ sử dụng

* ASP.NET Core
* Entity Framework Core
* SQL Server
* Bootstrap 5
* jQuery
* HTML/CSS/JavaScript

## Yêu cầu trước

* [.NET SDK](https://dotnet.microsoft.com/download) (phiên bản 6.0 trở lên)
* SQL Server (hoặc SQL Server Express)

## Hướng dẫn cài đặt

1. Clone repository:

   ```bash
   git clone https://github.com/username/SkinCare-Product-Sale.git
   cd SkinCare-Product-Sale
   ```
2. Cập nhật kết nối cơ sở dữ liệu trong `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=SkinCareSaleDb;Trusted_Connection=True;"
   }
   ```
3. Chạy EF Core migrations để tạo cơ sở dữ liệu:

   ```bash
   cd Data_Access_Layer
   dotnet ef database update
   ```
4. Chạy ứng dụng:

   ```bash
   cd ../SkinCare-Product-Sale
   dotnet run
   ```

## Xác thực và phân quyền

Hệ thống sử dụng role-based authentication với các vai trò:

* **Admin**: Toàn quyền quản lý hệ thống.
* **Customer**: Mua sắm và quản lý đơn hàng của chính mình.
* **Employee**: Hỗ trợ xử lý đơn hàng và quản lý khách hàng.

## Đóng góp

1. Fork repository.
2. Tạo feature branch (`git checkout -b feature/TênTínhNăng`).
3. Commit thay đổi (`git commit -m "Mô tả thay đổi"`).
4. Push branch lên origin (`git push origin feature/TênTínhNăng`).
5. Tạo Pull Request.


