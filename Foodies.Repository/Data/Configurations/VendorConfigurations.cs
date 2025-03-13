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
    internal class VendorConfigurations : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(V => V.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(V => V.PictureUrl)
                .IsRequired(false);

            builder.Property(V => V.Address)
                .IsRequired()
                .HasMaxLength(50);


        }
    }
}
