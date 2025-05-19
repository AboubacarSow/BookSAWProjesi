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
                new Book {Id=1,
                    Name="Frasques d'Ebinto",
                    ImageUrl="eowjel",
                    Price=300,
                    Stock=45,
                    CategoryId=2,
                    Author="Amadou Kourouma",
                    Description="Ce livre decrit la vie d'un jeune ambitieux qui a fini par arrêter les études"},
                new Book {Id=2,
                    Name="Soleil des Independances",
                    ImageUrl="sowejr",
                    Price=500,
                    Stock=20,
                    CategoryId= 2,
                    Author="Amadou Kourouma",
                    Description= "Les Soleils des indépendances est le premier ouvrage écrit par Ahmadou Kourouma. Il a été édité en 1968, aux Presses de l'Université de Montréal puis aux Éditions du Seuil en 1970." },
                new Book {Id=3,
                    Name="Les Crapeaux Brousses",
                    ImageUrl="soeis",
                    Price=550,
                    Stock=25,
                    CategoryId = 5,
                    Author="Thierno Monenombo",
                    Description="Crapeaux brousses retracent le comportement adopté par certains intellectuels dans la periode des indepandances"}
                );

        }
    }
}
