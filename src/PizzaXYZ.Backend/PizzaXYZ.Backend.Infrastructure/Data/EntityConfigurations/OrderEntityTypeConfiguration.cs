namespace PizzaXYZ.Backend.Infrastructure.Data.EntityConfigurations;
internal class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order, int>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        builder.ToTable("Orders");
        builder.Property(e => e.Date).IsRequired().HasColumnType("date");
        builder.Property(e => e.Time).IsRequired().HasColumnType("time");

        // Configure one-to-many relationship with OrderDetails
        builder.HasMany(o => o.OrderDetails)
               .WithOne(od => od.Order)
               .HasForeignKey(od => od.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
