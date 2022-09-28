using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.DataBase.Mappings
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("int");

        builder.Property(s => s.SaleDate);
            

        builder.HasOne(u => u.UserBuyer)
            .WithMany()
            .HasForeignKey(u => u.BuyerId);

        builder.HasOne(u => u.UserSeller)
            .WithMany()
            .HasForeignKey(u => u.SellerId);     
    }
    }
}