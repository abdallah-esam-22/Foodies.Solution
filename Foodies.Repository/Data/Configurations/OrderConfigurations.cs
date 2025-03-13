using Foodies.Core.Entities.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Repository.Data.Configurations
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(O => O.DeliveryMethod)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(O => O.SubTotal)
                .HasColumnType("decimal(18, 2)");

            builder.OwnsOne(O => O.Address);
            
            builder.Property(O => O.Status)
                .HasConversion<string>();

            //builder.Property(O => O.Status)
            //    .HasConversion(
            //    OStatus => OStatus.ToString(),
            //    OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
            //    );
        }
    }
}
