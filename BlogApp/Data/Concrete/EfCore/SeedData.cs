using BlogApp.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Web Programlama", URL = "web-programlama", Color = TagColors.warning },
                        new Tag { Text = "Backend", URL = "backend", Color = TagColors.success },
                        new Tag { Text = "Frontend", URL = "frontend", Color = TagColors.secondary },
                        new Tag { Text = "Fullstack", URL = "fullstack", Color = TagColors.primary },
                        new Tag { Text = "Php", URL = "php", Color = TagColors.info }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "BorayGulpinar", Name="Boray Gülpınar", Email="boray112@gmail.com", Password="123456", Image = "p1.jpg" },
                        new User { UserName = "KemalCinar", Name="Kemal Çınar", Email="info@kemalcinar.com", Password="123456", Image = "p2.jpg" }
                        );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.Net Core",
                            Content = "Asp.Net Core Dersleri",
                            URL = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserID = 1,
                            Comments = new List<Comment> {
                                new Comment { CommentText ="İyi bir kurs." , PublishedOn= new DateTime(),UserID=1},
                                new Comment { CommentText ="Çok faydalandığım bir kurs." , PublishedOn= new DateTime(),UserID=2},

                            }
                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php Dersleri",
                            URL = "php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-2),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserID = 1
                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django Dersleri",
                            URL = "django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserID = 2
                        },
                        new Post
                        {
                            Title = "React",
                            Content = "React Dersleri",
                            URL = "react-dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-12),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "1.jpg",
                            UserID = 2
                        },
                        new Post
                        {
                            Title = "Angular",
                            Content = "Angular Dersleri",
                            URL = "angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-22),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "2.jpg",
                            UserID = 2
                        },
                        new Post
                        {
                            Title = "Web Tasarım",
                            Content = "Web Tasarım Dersleri",
                            URL = "web-tasarim",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-45),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserID = 2
                        }
                        );
                    context.SaveChanges();

                }
            }
        }
    }
}
