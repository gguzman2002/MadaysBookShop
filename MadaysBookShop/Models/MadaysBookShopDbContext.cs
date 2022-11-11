﻿using Microsoft.EntityFrameworkCore;

namespace MadaysBookShop.Models
{
    public class MadaysBookShopDbContext: DbContext
    {
        public MadaysBookShopDbContext(DbContextOptions<MadaysBookShopDbContext>
            options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}