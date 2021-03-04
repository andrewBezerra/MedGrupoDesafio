using MedGrupo.BackEnd.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedGrupo.BackEnd.Data.Mappings
{
    public class ContactMapper : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar(32)");

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasColumnType("varchar(32)");

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar(32)");

        }
    }
}
