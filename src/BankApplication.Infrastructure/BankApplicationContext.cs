﻿using BankApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Infrastructure;

public class BankApplicationContext : DbContext
{
    public DbSet<User> users {get; set;}
    public DbSet<Transaction> transactions {get; set;}

    public BankApplicationContext() { }
    public BankApplicationContext(DbContextOptions<BankApplicationContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=DB_Bank;Uid=dev;Pwd=senhaforteuser;";
        if(!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Sender)
            .WithMany(u => u.SentTransactions)
            .HasForeignKey(t => t.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Receiver)
            .WithMany(u => u.ReceivedTransactions)
            .HasForeignKey(t => t.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
