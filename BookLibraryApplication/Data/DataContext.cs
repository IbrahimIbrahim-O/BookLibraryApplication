using BookLibraryApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasData(
                    new Book
                    {
                        Id = 1,
                        Title = "Joys of Motherhood",
                        Description = "About the expectations of the African Woman",
                        ISBN = "145866",
                        IsFavorite = true,
                        CategoryId = 1,
                        //AuthorBooks = new List<AuthorBook> { 
                        //    new AuthorBook(){BookId = 1, AuthorsId = 1 },
                        //}
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "The 48 Laws of Power",
                        Description = "Title speaks for itself",
                        ISBN = "45698",
                        IsFavorite = true,
                        CategoryId = 2,
                        //AuthorBooks = new List<AuthorBook> {
                        //    new AuthorBook(){BookId = 2, AuthorsId = 2 },
                        //}
                    },
                    new Book
                    {
                        Id = 3, 
                        Title = "Things fall apart",
                        ISBN = "",
                        IsFavorite = false,
                        CategoryId = 1,
                        //AuthorBooks = new List<AuthorBook>
                        //{
                        //    new AuthorBook(){BookId = 3, AuthorsId = 3}
                        //}
                    }

                );

            modelBuilder.Entity<Author>()
                .HasData(
                    new Author
                    {
                        Id = 1,
                        AuthorName = "Buchi Emecheta"
                    },
                    new Author
                    {
                        Id = 2,
                        AuthorName = "Robert Greene"
                    },
                    new Author
                    {
                        Id = 3,
                        AuthorName = "Chinua Achebe"
                    }

                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        CategoryName = "Fiction"
                    },
                    new Category
                    {
                        Id = 2,
                        CategoryName = "Biographies & Memoirs"
                    }
                );

            modelBuilder.Entity<AuthorBook>()
                .HasData(
                    new AuthorBook() { BookId = 1, AuthorsId = 1},
                    new AuthorBook() { BookId = 2, AuthorsId = 2},
                    new AuthorBook() { BookId = 3, AuthorsId = 3}
                    );
                //.HasOne(b => b.Book)
                //.WithMany(ba => ba.AuthorBooks)
                //.HasForeignKey(bi => bi.BookId));

            //modelBuilder.Entity<AuthorBook>()
            //  .HasOne(b => b.Author)
            //  .WithMany(ba => ba.AuthorBooks)
            //  .HasForeignKey(bi => bi.AuthorsId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }


    }
}
