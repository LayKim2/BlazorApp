﻿// <auto-generated />
using System;
using BlazorApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221117111533_UpdatePortfolio8")]
    partial class UpdatePortfolio8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorApp.Shared.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AboutAge")
                        .HasColumnType("int");

                    b.Property<string>("AboutBirthday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImageData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutIntroduce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutMainFilmograpy1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutMainFilmograpy2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutMainFilmograpy3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutMainFilmograpy4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CameraTestDateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("CamereTestUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept1ImageData1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept1ImageData2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept1ImageData3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept1VideoUrl1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept1VideoUrl2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept2ImageData1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept2ImageData2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept2ImageData3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept2VideoUrl1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concept2VideoUrl2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HighlightDateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("HighlightUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightEnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SideImageData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SideImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SideName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("BlazorApp.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlazorApp.Shared.Portfolio", b =>
                {
                    b.HasOne("BlazorApp.Shared.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
