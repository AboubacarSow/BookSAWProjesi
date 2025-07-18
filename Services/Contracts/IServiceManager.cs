﻿namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IBookService BookService { get; }
        ISubscriberService SubscriberService { get; }
    }
}
