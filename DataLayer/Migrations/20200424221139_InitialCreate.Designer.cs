﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLayer.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200424221139_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DataLayer.BankData", b =>
                {
                    b.Property<int>("BankDataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("LateFourNumbersOfBankCard")
                        .HasColumnType("integer");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("BankDataID");

                    b.ToTable("BankDatas");
                });

            modelBuilder.Entity("DataLayer.Colleague", b =>
                {
                    b.Property<int>("ColleagueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartActivity")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("code")
                        .HasColumnType("integer");

                    b.HasKey("ColleagueID");

                    b.ToTable("Colleagues");
                });

            modelBuilder.Entity("DataLayer.Sponsor", b =>
                {
                    b.Property<int>("SponsorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CauseOfSupport")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<int>("ColleagueID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OtherSupport")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<bool>("isValid")
                        .HasColumnType("boolean");

                    b.HasKey("SponsorID");

                    b.HasIndex("ColleagueID");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("DataLayer.SponsorTransaction", b =>
                {
                    b.Property<int>("SponsorTransactionsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("LateFourNumbersOfBankCard")
                        .HasColumnType("integer");

                    b.Property<int>("SponsorID")
                        .HasColumnType("integer");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("SponsorTransactionsID");

                    b.HasIndex("SponsorID");

                    b.ToTable("SponsorTransactions");
                });

            modelBuilder.Entity("DataLayer.Sponsor", b =>
                {
                    b.HasOne("DataLayer.Colleague", "MyColleague")
                        .WithMany("Sponsors")
                        .HasForeignKey("ColleagueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.SponsorTransaction", b =>
                {
                    b.HasOne("DataLayer.Sponsor", "MySponsor")
                        .WithMany("MyTransactions")
                        .HasForeignKey("SponsorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
