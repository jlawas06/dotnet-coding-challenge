namespace PizzaXYZ.Backend.Infrastructure.Data.EntityConfigurations;
internal class PizzaEntityTypeConfiguration : BaseEntityTypeConfiguration<Pizza, string>
{
    public override void Configure(EntityTypeBuilder<Pizza> builder)
    {
        base.Configure(builder);
        builder.ToTable("Pizzas");
        builder.Property(e => e.Size).IsRequired().HasMaxLength(5).HasConversion<string>();
        builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");

        // Configure one-to-many relationship with PizzaType
        builder.HasOne(p => p.PizzaType)
               .WithMany(pt => pt.Pizzas)
               .HasForeignKey(p => p.PizzaTypeId)
               .OnDelete(DeleteBehavior.Cascade);

        // Configure one-to-many relationship with OrderDetails
        builder.HasMany(p => p.OrderDetails)
               .WithOne(od => od.Pizza)
               .HasForeignKey(od => od.PizzaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
