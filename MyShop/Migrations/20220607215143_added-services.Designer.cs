﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyShop.Models;

#nullable disable

namespace MyShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220607215143_added-services")]
    partial class addedservices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyShop.Models.AccountTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("MyShop.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<double>("ItemsTotal")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MyShop.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Cart_Id")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Product_Id")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Cart_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("MyShop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyShop.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("State_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("State_Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MyShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("City_Id")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<double>("Items_Discount")
                        .HasColumnType("float");

                    b.Property<double>("Items_Total")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Promo_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Shipping")
                        .HasColumnType("float");

                    b.Property<int?>("State_Id")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("type_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("City_Id");

                    b.HasIndex("State_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyShop.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Order_Id")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Product_Id")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MyShop.Models.OrdersTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Order_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("OrdersTransactions");
                });

            modelBuilder.Entity("MyShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Discount_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Discount_Start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyShop.Models.ProductsReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cons")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Last_Update")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Product_Id")
                        .HasColumnType("int");

                    b.Property<string>("Pros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("ProductsReviews");
                });

            modelBuilder.Entity("MyShop.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Arrange_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("MyShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("Last_Login")
                        .HasColumnType("datetime2");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Register_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("type_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("type_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyShop.Models.Cart", b =>
                {
                    b.HasOne("MyShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyShop.Models.CartItem", b =>
                {
                    b.HasOne("MyShop.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("Cart_Id");

                    b.HasOne("MyShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyShop.Models.City", b =>
                {
                    b.HasOne("MyShop.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("State_Id");

                    b.Navigation("State");
                });

            modelBuilder.Entity("MyShop.Models.Order", b =>
                {
                    b.HasOne("MyShop.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("City_Id");

                    b.HasOne("MyShop.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("State_Id");

                    b.HasOne("MyShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id");

                    b.Navigation("City");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyShop.Models.OrderDetails", b =>
                {
                    b.HasOne("MyShop.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_Id");

                    b.HasOne("MyShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyShop.Models.OrdersTransaction", b =>
                {
                    b.HasOne("MyShop.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_Id");

                    b.HasOne("MyShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyShop.Models.Product", b =>
                {
                    b.HasOne("MyShop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Category_Id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyShop.Models.ProductsReviews", b =>
                {
                    b.HasOne("MyShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id");

                    b.HasOne("MyShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyShop.Models.User", b =>
                {
                    b.HasOne("MyShop.Models.AccountTypes", "AccountTypes")
                        .WithMany()
                        .HasForeignKey("type_Id");

                    b.Navigation("AccountTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
