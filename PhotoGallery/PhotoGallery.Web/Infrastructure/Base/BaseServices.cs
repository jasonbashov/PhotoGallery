namespace PhotoGallery.Web.Infrastructure.Base
{
    using PhotoGallery.Data;

    public abstract class BaseServices
    {
        protected IPhotoGalleryData Data { get; private set; }

        public BaseServices(IPhotoGalleryData data)
        {
            this.Data = data;
        }
    }
}