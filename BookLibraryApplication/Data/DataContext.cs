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
                        Description = "First published in 1979, The Joys of Motherhood is the story of Nnu Ego, a Nigerian woman struggling in a patriarchal society. " +
                        "Unable to conceive in her first marriage," +
                        " Nnu is banished to Lagos where she succeeds in becoming a mother.",
                        ISBN = "0807616095",
                        IsFavorite = true,
                        CategoryId = 1,
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "The 48 Laws of Power",
                        Description = "The 48 Laws of Power (1998) is a non-fiction book by American author Robert Greene.The book is a bestseller," +
                        "selling over 1.2 million copies in the United States, and is popular with prison inmates and celebrities",
                        ISBN = "0140280197",
                        IsFavorite = true,
                        CategoryId = 2,
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Things fall apart",
                        Description = "Traditionally structured, and peppered with Igbo proverbs, " +
                        "it describes the simultaneous disintegration of its protagonist Okonkwo and of his village",
                        ISBN = "0385474547",
                        IsFavorite = false,
                        CategoryId = 1,
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
                    new AuthorBook
                    {
                        Id = 1,
                        BookId = 1,
                        AuthorsId = 1
                    },
                    new AuthorBook
                    {
                        Id = 2,
                        BookId = 2,
                        AuthorsId = 2
                    },
                    new AuthorBook
                    {
                        Id = 3,
                        BookId = 3,
                        AuthorsId = 3
                    }
                );
            

            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.AuthorBooks)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<AuthorBook>()
              .HasOne(b => b.Author)
              .WithMany(ba => ba.AuthorBooks)
              .HasForeignKey(bi => bi.AuthorsId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }


    }
}
