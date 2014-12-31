namespace PhotoGallery.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoGallery.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhotoGalleryDbContext : IdentityDbContext<User>
    {
        public PhotoGalleryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public static PhotoGalleryDbContext Create()
        {
            return new PhotoGalleryDbContext();
        }
    }
}
