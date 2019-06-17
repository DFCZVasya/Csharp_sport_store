﻿using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace SportStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //public static void EnsurePopulated(IServiceProvider services)
            //{
            //    ApplicationDbContext context =
            //        services.GetRequiredService<ApplicationDbContext>();

            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275
                    },
                    
                    new Product
                    {
                        Name = "LifeJacket",
                        Description = "Protectiv and fashionable",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and widght",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },

                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain effiency by 75%",
                        Category = "Chess",
                        Price = 16
                    },

                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m 
                    },
                    
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75 
                    },

                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    });
                context.SaveChanges();
            }
        }
    }
}