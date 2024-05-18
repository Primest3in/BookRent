using BookRent.Models;
using BookRent.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRent.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Category> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Action", DisplayOrder=1},
                new Category {Id = 2, Name = "Scify", DisplayOrder=2},
                new Category {Id = 3, Name = "History", DisplayOrder=3}
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    Id = 1, 
                    Title = "অগ্নিবীণা",
                    Description = "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!",
                    Author = " কাজী নজরুল ইসলাম",
                    Price = 142
                },
                new Product
                {
                    Id = 2,
                    Title = "মৃত্যুক্ষুধা",
                    Description = "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!",
                    Author = " কাজী নজরুল ইসলাম",
                    Price = 142
                },
                new Product
                {
                    Id = 3,
                    Title = "বিশ্বকবি রবীন্দ্রনাথ ঠাকুর (জীবনীগ্রন্থ)",
                    Description = "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!",
                    Author = "আহমদ মতিউর রহমান",
                    Price = 200
                },

                new Product
                {
                    Id = 4,
                    Title = "গণতন্ত্রের মানসপুত্র হোসেন শহীদ সোহরাওয়ার্দী",
                    Description = "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!",
                    Author = "আহমদ মতিউর রহমান",
                    Price = 142
                },
                new Product
                {
                    Id = 5,
                    Title = "নবাব সিরাজউদ্দৌলার পতনের কারণ ও বাংলার ২০০ বছর",
                    Description = "২৫-৭০% ছাড়ে বই সাথে অতিরিক্ত ৩% ছাড় অ্যাপ অর্ডারে। ৫-১৯ মে চলছে শায়েস্তা খাঁ অফার!",
                    Author = "আহমদ মতিউর রহমান",
                    Price = 300
                }


                );
        }

    }
}
