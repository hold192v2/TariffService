﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TariffService.Infrastructure.Context;

#nullable disable

namespace TariffService.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TariffCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NewPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TariffId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TempUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TariffCarts");
                });

            modelBuilder.Entity("TariffService.Domain.Entities.DynamicTariff", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Gigabytes")
                        .HasColumnType("numeric");

                    b.Property<bool>("LongDistanceCall")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Minutes")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Sms")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimMusic")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimSocials")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimVideo")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("DynamicTariffs");
                });

            modelBuilder.Entity("TariffService.Domain.Entities.StaticTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Gigabytes")
                        .HasColumnType("numeric");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LongDistanceCall")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Minutes")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Sms")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimMusic")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimSocials")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimVideo")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("StaticTariffs");
                });

            modelBuilder.Entity("TariffService.Domain.Entities.UnitPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("GigabytePrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("LongDistanceCallPrice")
                        .HasColumnType("boolean");

                    b.Property<decimal>("MinutePrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SmsPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("UnlimMusicPrice")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimSocialsPrice")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnlimVideoPrice")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("UnitPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
