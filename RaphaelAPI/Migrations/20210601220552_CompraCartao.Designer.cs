﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaphaelAPI.Data;

namespace RaphaelAPI.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20210601220552_CompraCartao")]
    partial class CompraCartao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RaphaelAPI.Models.Cartao", b =>
                {
                    b.Property<string>("numero")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bandeira")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cvv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data_expiracao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titular")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("numero");

                    b.ToTable("cartao");
                });

            modelBuilder.Entity("RaphaelAPI.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cartaonumero")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("produto_Id")
                        .HasColumnType("int");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("cartaonumero");

                    b.ToTable("compra");
                });

            modelBuilder.Entity("RaphaelAPI.Models.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("data_last")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qtde_estoque")
                        .HasColumnType("int");

                    b.Property<float>("valor_last")
                        .HasColumnType("real");

                    b.Property<float>("valor_unitario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("RaphaelAPI.Models.Compra", b =>
                {
                    b.HasOne("RaphaelAPI.Models.Cartao", "cartao")
                        .WithMany()
                        .HasForeignKey("cartaonumero");

                    b.Navigation("cartao");
                });
#pragma warning restore 612, 618
        }
    }
}
