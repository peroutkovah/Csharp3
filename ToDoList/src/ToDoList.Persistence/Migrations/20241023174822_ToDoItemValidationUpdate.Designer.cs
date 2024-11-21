﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Persistence;

#nullable disable

namespace ToDoList.Persistence.Migrations
{
    [DbContext(typeof(ToDoItemsContext))]
    [Migration("20241023174822_ToDoItemValidationUpdate")]
    partial class ToDoItemValidationUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ToDoList.Domain.Models.ToDoItem", b =>
                {
                    b.Property<int>("ToDoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ToDoItemId");

                    b.ToTable("ToDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}