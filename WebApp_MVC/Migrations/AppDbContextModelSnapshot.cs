﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_MVC.Models;

#nullable disable

namespace WebApp_MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp_MVC.Models.DanhMuc", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DanhMuc", (string)null);

                    b.HasData(
                        new
                        {
                            ID = new Guid("35c0128c-cebd-4501-afc4-74a686be8018"),
                            TenDanhMuc = "Đồ ăn",
                            TrangThai = 1
                        },
                        new
                        {
                            ID = new Guid("c031e6c3-4074-4236-ad30-3e83acd5b770"),
                            TenDanhMuc = "Quần áo",
                            TrangThai = 1
                        });
                });

            modelBuilder.Entity("WebApp_MVC.Models.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Luong")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("WebApp_MVC.Models.SanPham", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("money");

                    b.Property<Guid>("IDDanhMuc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDDanhMuc");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("WebApp_MVC.Models.SanPham", b =>
                {
                    b.HasOne("WebApp_MVC.Models.DanhMuc", "DanhMuc")
                        .WithMany("SanPhams")
                        .HasForeignKey("IDDanhMuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");
                });

            modelBuilder.Entity("WebApp_MVC.Models.DanhMuc", b =>
                {
                    b.Navigation("SanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
