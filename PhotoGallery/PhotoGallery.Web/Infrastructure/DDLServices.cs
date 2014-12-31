namespace PhotoGallery.Web.Infrastructure
{
    using PhotoGallery.Data;
    using PhotoGallery.Web.Infrastructure.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class DDLServices : BaseServices
    {
        public DDLServices(IPhotoGalleryData data)
            : base(data)
        {
        }

        public IEnumerable<SelectListItem> AlbumsCategoriesDDL
        {
            get
            {
                return this.GetAlbumsCategories();
            }
        }

        private IEnumerable<SelectListItem> GetAlbumsCategories()
        {
            var albumCategories = this.Data
                .Categories
                .All()
                .ToList();

            List<SelectListItem> categories = new List<SelectListItem>();
            categories.AddRange(new SelectList(albumCategories, "Id", "Name"));
            var result = new SelectList(categories, "Value", "Text");

            return result;
        }

    }
}