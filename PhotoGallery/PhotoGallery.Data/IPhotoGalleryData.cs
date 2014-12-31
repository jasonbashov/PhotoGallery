namespace PhotoGallery.Data
{
    using System;
    using System.Data.Entity;
    using PhotoGallery.Models;

    public interface IPhotoGalleryData
    {
        PhotoGalleryDbContext Context { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Album> Albums { get; }

        //IRepository<Ticket> Tickets { get; }

        IRepository<User> Users { get; }

        void Dispose();

        int SaveChanges();
    }
}
