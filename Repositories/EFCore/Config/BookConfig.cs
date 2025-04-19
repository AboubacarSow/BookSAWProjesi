using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book {Id=1, Name="Frasques d'Ebinto",Price=300,Stock=45,CategoryId=2},
                new Book {Id=2, Name="Soleil des Independances", Price=500,Stock=20,CategoryId= 2 },
                new Book {Id=3, Name="Les Crapeaux Brousses", Price=550,Stock=25,CategoryId = 5}
                );
        }
    }
}
