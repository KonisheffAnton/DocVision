using DocVision.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocVision.DataAccessLayer.EntityConfigurations
{
    public class MailEntityConfiguration : IEntityTypeConfiguration<MailEntity>
    {
        public void Configure(EntityTypeBuilder<MailEntity> builder) 
        {
            //builder
            //    .HasKey(x => x.Id);

            //builder
            //    .Property(x => x.ClientId)
            //    .IsRequired();

            //builder
            //    .Property(x => x.DepositProductName)
            //    .HasMaxLength(30)
            //    .IsRequired();

            //builder
            //    .Property(x => x.Amount)
            //    .IsRequired();

            //builder
            //    .Property(x => x.DurationMonths)
            //    .IsRequired();

            //builder
            //    .Property(x => x.OpenDate) 
            //    .IsRequired();

            //builder
            //    .Property(x => x.CloseDate)
            //    .IsRequired();

            //builder
            //    .Property(x => x.Status)
            //    .IsRequired();

            //builder
            //    .Property(x => x.IsActive)
            //    .IsRequired();

            //builder
            //    .HasOne(oae => oae.DepositProduct)
            //    .WithMany(dpe => dpe.OpenApplications)
            //    .HasForeignKey(oae => oae.DepositProductName)
            //    .HasPrincipalKey(dpe => dpe.Name)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasCheckConstraint("CK_EndDate", "\"CloseDate\" >= \"OpenDate\"");
        }
    }
}
