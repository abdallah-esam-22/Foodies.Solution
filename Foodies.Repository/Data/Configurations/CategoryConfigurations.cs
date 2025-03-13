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
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(C => C.Id)
                .UseIdentityColumn(101, 1);

            builder.Property(C => C.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(C => C.PictureUrl)
                .IsRequired();
        }
    }
}
