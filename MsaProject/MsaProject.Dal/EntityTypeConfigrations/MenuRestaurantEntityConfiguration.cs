using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Dal.EntityTypeConfigrations
{
    public class MenuRestaurantEntityConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder
            .HasOne(r => r.Menu)
            .WithOne(m => m.Restaurant)
            .HasForeignKey<Menu>(m => m.RestaurantId);
        }

    }
}
