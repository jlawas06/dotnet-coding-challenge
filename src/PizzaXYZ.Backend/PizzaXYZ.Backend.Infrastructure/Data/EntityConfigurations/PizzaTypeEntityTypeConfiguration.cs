namespace PizzaXYZ.Backend.Infrastructure.Data.EntityConfigurations;
internal class PizzaTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<PizzaType, string>
{
    public override void Configure(EntityTypeBuilder<PizzaType> builder)
    {
        base.Configure(builder);
        builder.ToTable("PizzaTypes");
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Category).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Ingredients).IsRequired().HasMaxLength(255);

        // Configure one-to-many relationship with Pizza
        builder.HasMany(pt => pt.Pizzas)
               .WithOne(p => p.PizzaType)
               .HasForeignKey(p => p.PizzaTypeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
