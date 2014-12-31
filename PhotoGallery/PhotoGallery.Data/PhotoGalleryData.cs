﻿namespace PhotoGallery.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using PhotoGallery.Models;

    public class ApplicationData : IPhotoGalleryData
    {
        private readonly PhotoGalleryDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ApplicationData(PhotoGalleryDbContext context)
        {
            this.context = context;
        }

        //public IRepository<Image> Images
        //{
        //    get { return this.GetRepository<Image>(); }
        //}

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public PhotoGalleryDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
