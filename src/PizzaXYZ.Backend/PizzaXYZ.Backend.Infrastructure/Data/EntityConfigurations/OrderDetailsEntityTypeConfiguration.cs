namespace PizzaXYZ.Backend.Infrastructure.Data.EntityConfigurations;
internal class OrderDetailsEntityTypeConfiguration : BaseEntityTypeConfiguration<OrderDetails, int>
{
    public override void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        base.Configure(builder);
        builder.ToTable("OrderDetails");
        builder.Property(e => e.Quantity).IsRequired();

        // Configure one-to-many relationship with Order
        builder.HasOne(od => od.Order)
               .WithMany(o => o.OrderDetails)
               .HasForeignKey(od => od.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        // Configure one-to-many relationship with Pizza
        builder.HasOne(od => od.Pizza)
               .WithMany(p => p.OrderDetails)
               .HasForeignKey(od => od.PizzaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
