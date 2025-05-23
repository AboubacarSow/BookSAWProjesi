﻿using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges);
        Task<List<Book>> GetBannerBooksAsync(bool trackChanges);
        Task<Book>? GetOneBookByIdAsync(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);


    }
}
