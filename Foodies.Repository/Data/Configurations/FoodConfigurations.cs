using Foodies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Repository.Data.Configurations
{
    internal class FoodConfigurations : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(F => F.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(F => F.Description)
                .IsRequired()
                .HasMaxLength(250);

            //builder.Property(F => F.PictureUrl)
            //    .IsRequired();

            builder.Property(F => F.UnitPrice)
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(F => F.Category)
                .WithMany();

            builder.HasOne(F => F.Vendor)
                .WithMany();
        }
    }
}
