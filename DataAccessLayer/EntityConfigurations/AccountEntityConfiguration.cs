using DocVision.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocVision.DataAccessLayer.EntityConfigurations
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            //builder
            //    .HasKey(accountEntity => accountEntity.Id);

            //builder
            //    .Property(accountEntity => accountEntity.AccountNumber)
            //    .HasMaxLength(30)
            //    .IsRequired();

            //builder
            //    .Property(accountEntity => accountEntity.AgreementId)
            //    .IsRequired();

            //builder
            //    .Property(accountEntity => accountEntity.CurrentBalance)
            //    .HasPrecision(19, 4)
            //    .IsRequired();

            //builder
            //    .Property(accountEntity => accountEntity.OpenDate)
            //    .IsRequired();

            //builder
            //    .Property(accountEntity => accountEntity.CloseDate)
            //    .IsRequired();

            //builder
            //    .Property(accountEntity => accountEntity.IsActive)
            //    .IsRequired();

            //builder.HasOne(accountEntity => accountEntity.Agreement)
            //    .WithOne(agreementEntity => agreementEntity.Account)
            //    .HasForeignKey<AccountEntity>(x => x.AgreementId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasIndex(accountEntity => accountEntity.AccountNumber)
            //    .IsUnique();

            //builder.HasCheckConstraint("CK_CloseDate", "\"CloseDate\" >= \"OpenDate\"");
        }
    }
}
