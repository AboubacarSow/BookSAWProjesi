using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category {CategoryId = 1,CategoryName = "Tarih Kitabı" },
                new Category {CategoryId = 2, CategoryName = "Şiir Kitabı" },
                new Category {CategoryId = 3, CategoryName = "Bilişim Kitabı" },
                new Category {CategoryId = 4, CategoryName = "Biyoloji Kitabı" },
                new Category {CategoryId = 5, CategoryName = "Felsefe Kitabı" });
        }
    }
}
