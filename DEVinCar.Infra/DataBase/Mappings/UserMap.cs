using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.DataBase.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(u => u.BirthDate);
            builder
                .HasData(new[] {
                    new User (1, "jose@email.com", "123456opp78", "Jose","Gerente", new DateTime(2000, 12, 10)),
                    new User (2, "andrea@email.com", "987dasd654321", "Andrea","Comprador", new DateTime(1999, 05, 11)),
                    new User (3, "adao@email.com", "2589asd", "Adao","Vendedor", new DateTime(2005, 09, 02)),
                    new User (4, "monique@email.com", "asd45uio", "Monique","Vendedor", new DateTime(2001, 06, 07)),
                });   
    }
    }
}