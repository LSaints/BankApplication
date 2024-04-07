﻿// <auto-generated />
using System;
using BankApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankApplication.Infrastructure.Migrations
{
    [DbContext(typeof(BankApplicationContext))]
    partial class BankApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BankApplication.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("BankApplication.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BankApplication.Domain.Transaction", b =>
                {
                    b.HasOne("BankApplication.Domain.User", "Receiver")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BankApplication.Domain.User", "Sender")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("BankApplication.Domain.User", b =>
                {
                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
