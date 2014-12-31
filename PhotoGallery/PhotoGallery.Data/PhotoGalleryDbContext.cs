using Microsoft.AspNet.Identity.EntityFramework;
using PhotoGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data
{
    public class PhotoGalleryDbContext : IdentityDbContext<User>
    {
        public PhotoGalleryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static PhotoGalleryDbContext Create()
        {
            return new PhotoGalleryDbContext();
        }
    }
}
