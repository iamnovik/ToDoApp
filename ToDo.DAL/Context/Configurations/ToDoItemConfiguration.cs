using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.DAL.Entity;

namespace ToDo.DAL.Context.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.HasKey(b => b.Id);
        builder
            .Property(b => b.ItemStatus)
            .HasConversion<string>() 
            .IsRequired();

        
    }
}
