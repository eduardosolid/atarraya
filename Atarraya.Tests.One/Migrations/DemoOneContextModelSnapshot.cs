﻿// <auto-generated />
using System;
using Atarraya.Tests.One.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atarraya.Tests.One.Migrations
{
    [DbContext(typeof(DemoOneContext))]
    partial class DemoOneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Atarraya.Tests.One.Data.Entities.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BirthState")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FatherLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MotherLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });
#pragma warning restore 612, 618
        }
    }
}
