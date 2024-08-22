using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Core.Models;
using TechChallenge.Domain.Models;

namespace TechChallenge.Infrastructure.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State", "TechChallenge");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasColumnType("VARCHAR(100)").IsRequired();
        }        
    }
}