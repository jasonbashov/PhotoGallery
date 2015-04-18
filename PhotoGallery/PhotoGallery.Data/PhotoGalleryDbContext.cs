namespace PhotoGallery.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoGallery.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoGallery.Data.CodeFirstConventions;

    public class PhotoGalleryDbContext : IdentityDbContext<User>
    {
        public PhotoGalleryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoGalleryDbContext, PhotoGallery.Data.Migrations.Configuration>());
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public static PhotoGalleryDbContext Create()
        {
            return new PhotoGalleryDbContext();
        }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        
        public override int SaveChanges()
        {
            //this.ApplyAuditInfoRules();
            //this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //In case I return many-to-many relation with stocks and sales uncomment theses
            //modelBuilder.Entity<Sale>().HasMany(s => s.Stocks).WithMany(st => st.Sales).Map(
            //    m =>
            //    {
            //        m.ToTable("SaleCourse");
            //        m.MapLeftKey("SaleId");
            //        m.MapRightKey("CourseId");
            //    });
            //modelBuilder.Entity<Sale>()
            //    .HasRequired(s => s.SoldStocks)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //private void ApplyAuditInfoRules()
        //{
        //    // Approach via @julielerman: http://bit.ly/123661P
        //    foreach (var entry in
        //        this.ChangeTracker.Entries()
        //            .Where(
        //                e =>
        //                e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
        //    {
        //        var entity = (IAuditInfo)entry.Entity;

        //        if (entry.State == EntityState.Added)
        //        {
        //            if (!entity.PreserveCreatedOn)
        //            {
        //                entity.CreatedOn = DateTime.Now;
        //            }
        //        }
        //        else
        //        {
        //            entity.ModifiedOn = DateTime.Now;
        //        }
        //    }
        //}

        //private void ApplyDeletableEntityRules()
        //{
        //    // Approach via @julielerman: http://bit.ly/123661P
        //    foreach (
        //        var entry in
        //            this.ChangeTracker.Entries()
        //                .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
        //    {
        //        var entity = (IDeletableEntity)entry.Entity;

        //        entity.DeletedOn = DateTime.Now;
        //        entity.IsDeleted = true;
        //        entry.State = EntityState.Modified;
        //    }
        //}
    }
}
