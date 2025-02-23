using System;
using System.Collections.Generic;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.DBContext;

public partial class SkincareManagementContext : DbContext
{
    public SkincareManagementContext() { }

    public SkincareManagementContext(DbContextOptions<SkincareManagementContext> options)
        : base(options) { }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderPromotion> OrderPromotions { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPromotion> ProductPromotions { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SkincareManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__F267251E4DAEF09E");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).ValueGeneratedNever().HasColumnName("accountId");
            entity.Property(e => e.Password).HasMaxLength(50).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Username).HasMaxLength(50).HasColumnName("username");

            entity
                .HasOne(d => d.Role)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__roleId__4BAC3F29");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__415B03B8F725E603");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).ValueGeneratedNever().HasColumnName("cartId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Cart__accountId__619B8048");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__Cart_Ite__283983B6220EF485");

            entity.ToTable("Cart_Item");

            entity.Property(e => e.CartItemId).ValueGeneratedNever().HasColumnName("cartItemId");
            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity
                .HasOne(d => d.Cart)
                .WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__Cart_Item__cartI__6477ECF3");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Cart_Item__produ__656C112C");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1D80D045828");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedNever().HasColumnName("categoryId");
            entity.Property(e => e.CategoryName).HasMaxLength(50).HasColumnName("categoryName");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7DA35A0B5D");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).ValueGeneratedNever().HasColumnName("customerId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.FullName).HasMaxLength(100).HasColumnName("fullName");
            entity.Property(e => e.Phone).HasMaxLength(15).HasColumnName("phone");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Customer__accoun__4E88ABD4");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C134C9C1F2DDE5B8");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever().HasColumnName("employeeId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.FullName).HasMaxLength(100).HasColumnName("fullName");
            entity.Property(e => e.Position).HasMaxLength(50).HasColumnName("position");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Employee__accoun__5165187F");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__2613FD24B05CC7C6");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).ValueGeneratedNever().HasColumnName("feedbackId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Feedback__accoun__6EF57B66");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Image__336E9B559269C996");

            entity.ToTable("Image");

            entity.Property(e => e.ImageId).ValueGeneratedNever().HasColumnName("imageId");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Image__productId__5EBF139D");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__5218041E4AAEFF92");

            entity.Property(e => e.NewsId).ValueGeneratedNever().HasColumnName("newsId");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Title).HasMaxLength(200).HasColumnName("title");

            entity
                .HasOne(d => d.Employee)
                .WithMany(p => p.News)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__News__employeeId__5441852A");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__0809335D65E1E68A");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).ValueGeneratedNever().HasColumnName("orderId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.OrderDate).HasColumnType("datetime").HasColumnName("orderDate");
            entity.Property(e => e.Status).HasMaxLength(50).HasColumnName("status");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Order__accountId__68487DD7");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Order_De__E4FEDE4A234C9FC4");

            entity.ToTable("Order_Detail");

            entity
                .Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("orderDetailId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)").HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Order_Det__order__6B24EA82");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Order_Det__produ__6C190EBB");
        });

        modelBuilder.Entity<OrderPromotion>(entity =>
        {
            entity.HasKey(e => e.OrderPromotionId).HasName("PK__Order_Pr__69F6C47326D5E729");

            entity.ToTable("Order_Promotion");

            entity
                .Property(e => e.OrderPromotionId)
                .ValueGeneratedNever()
                .HasColumnName("orderPromotionId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.PromotionId).HasColumnName("promotionId");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderPromotions)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Order_Pro__order__7B5B524B");

            entity
                .HasOne(d => d.Promotion)
                .WithMany(p => p.OrderPromotions)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Order_Pro__promo__7C4F7684");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__A0D9EFC67F613395");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).ValueGeneratedNever().HasColumnName("paymentId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity
                .Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("paymentDate");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50).HasColumnName("paymentMethod");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payment__orderId__7F2BE32F");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("PK__Point__4CB435AEA4B2E229");

            entity.ToTable("Point");

            entity.Property(e => e.PointId).ValueGeneratedNever().HasColumnName("pointId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Points).HasColumnName("points");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Points)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Point__accountId__571DF1D5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D16A8537E9D8");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever().HasColumnName("productId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)").HasColumnName("price");

            entity
                .HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__categor__5BE2A6F2");
        });

        modelBuilder.Entity<ProductPromotion>(entity =>
        {
            entity.HasKey(e => e.ProductPromotionId).HasName("PK__Product___3F1B3D11EDCBEC9A");

            entity.ToTable("Product_Promotion");

            entity
                .Property(e => e.ProductPromotionId)
                .ValueGeneratedNever()
                .HasColumnName("productPromotionId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.PromotionId).HasColumnName("promotionId");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductPromotions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Product_P__produ__778AC167");

            entity
                .HasOne(d => d.Promotion)
                .WithMany(p => p.ProductPromotions)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Product_P__promo__787EE5A0");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__99EB696E792C7FF3");

            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId).ValueGeneratedNever().HasColumnName("promotionId");
            entity
                .Property(e => e.Discount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.EndDate).HasColumnType("datetime").HasColumnName("endDate");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnType("datetime").HasColumnName("startDate");
        });

        modelBuilder.Entity<PromotionDetail>(entity =>
        {
            entity.HasKey(e => e.PromotionDetailId).HasName("PK__Promotio__74CA3CF1D2EEDDBF");

            entity.ToTable("Promotion_Detail");

            entity
                .Property(e => e.PromotionDetailId)
                .ValueGeneratedNever()
                .HasColumnName("promotionDetailId");
            entity.Property(e => e.DetailDescription).HasColumnName("detailDescription");
            entity.Property(e => e.PromotionId).HasColumnName("promotionId");

            entity
                .HasOne(d => d.Promotion)
                .WithMany(p => p.PromotionDetails)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Promotion__promo__74AE54BC");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__CD98462A4B269C18");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever().HasColumnName("roleId");
            entity.Property(e => e.RoleName).HasMaxLength(50).HasColumnName("roleName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
