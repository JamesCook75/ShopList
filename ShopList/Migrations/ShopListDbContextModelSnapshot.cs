﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShopList.Data;
using System;

namespace ShopList.Migrations
{
    [DbContext(typeof(ShopListDbContext))]
    partial class ShopListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopList.Models.Checklist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Checklists");
                });

            modelBuilder.Entity("ShopList.Models.ChecklistItem", b =>
                {
                    b.Property<int>("ItemID");

                    b.Property<int>("ChecklistID");

                    b.HasKey("ItemID", "ChecklistID");

                    b.HasIndex("ChecklistID");

                    b.ToTable("ChecklistItems");
                });

            modelBuilder.Entity("ShopList.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("StoreID");

                    b.HasKey("ID");

                    b.HasIndex("StoreID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ShopList.Models.ItemStore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ShopList.Models.ChecklistItem", b =>
                {
                    b.HasOne("ShopList.Models.Checklist", "Checklist")
                        .WithMany("ChecklistItems")
                        .HasForeignKey("ChecklistID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopList.Models.Item", "Item")
                        .WithMany("ChecklistItem")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopList.Models.Item", b =>
                {
                    b.HasOne("ShopList.Models.ItemStore", "Store")
                        .WithMany("Items")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
