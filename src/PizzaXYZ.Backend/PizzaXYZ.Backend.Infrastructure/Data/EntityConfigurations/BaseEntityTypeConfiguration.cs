namespace PizzaXYZ.Backend.Infrastructure.Data.EntityConfigurations;
internal class BaseEntityTypeConfiguration<TEntity, IType> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<IType>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired();
    }
}
