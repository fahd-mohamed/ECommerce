using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistencs.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table Name
            builder.ToTable("Products");

            // Primary Key
            builder.HasKey(P => P.Id);

            // Properties Configuration
            builder.Property(P => P.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(P => P.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(P => P.ImageUrl)
                .IsRequired();

            builder.Property(P => P.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relationship With ProductBrand
            builder.HasOne(P => P.ProductBrand)
                .WithMany(pb => pb.Products)
                .HasForeignKey(P => P.ProductBrandId)
                .OnDelete(DeleteBehavior.NoAction);

            // Relationship With ProductType
            builder.HasOne(x => x.ProductType)
                .WithMany(pt=> pt.Products)
                .HasForeignKey(P => P.ProductTypeId)
                .OnDelete(DeleteBehavior.NoAction   );


            builder.HasIndex(P => P.Name);
            builder.HasIndex(P => P.Price);
                
        }
    }
}
