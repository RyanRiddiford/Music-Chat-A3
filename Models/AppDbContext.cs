using Microsoft.EntityFrameworkCore;
using music_chat.Models.DTO;

namespace music_chat.Models
{
    /// <summary>
    /// Database Migrations schematics builder
    /// </summary>
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        //Configures model schematics and includes seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Post> seedPosts = new List<Post>();
            int seedPostId = 1;

            List<Guid> guids = new List<Guid>();

            for(int i = 0; i < 3; i++)
            {
                guids.Add(Guid.NewGuid());
            }

            //Composite key initialisation
            modelBuilder.Entity<Login>().HasKey(k => new { k.Email, k.AccountId });

            //Seed data for Account entity
            modelBuilder.Entity<Account>().HasData(

                new Account
                {
                    ImageUrl = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPEG",
                    Username = "user1",
                    Id = guids.ToArray()[0]
                },
                new Account
                {
                    ImageUrl = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user2.JPEG",
                    Username = "user2",
                    Id = guids.ToArray()[1]
                },
                new Account
                {
                    ImageUrl = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user3.JPEG",
                    Username = "user3",
                    Id = guids.ToArray()[2]
                }

            );

            //Seed data for Login entity
            modelBuilder.Entity<Login>().HasData(
                new Login
                {
                    Email = "user1@email.com",
                    Password = "user1",
                    AccountId = guids.ToArray()[0]

                },
                new Login
                {
                    Email = "user2@email.com",
                    Password = "user2",
                    AccountId = guids.ToArray()[1]
                },
                new Login
                {
                    Email = "user3@email.com",
                    Password = "user3",
                    AccountId = guids.ToArray()[2]
                }

                );

            //Generate posts for seeding
            for(int i = 0; i < 10; i++)
            {
                seedPosts.Add(new Post
                {
                    Id = seedPostId.ToString(),
                    AuthorProfileImage = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPEG",
                    AuthorUsername = "user1",
                    Content = "Test Message " + seedPostId,
                    timestamp = DateTime.Parse("2022-05-01").ToUniversalTime(),
                });
                seedPostId++;
            }

            for(int i = 0; i < 15; i++)
            {
                seedPosts.Add(new Post
                {
                    Id = seedPostId.ToString(),
                    AuthorProfileImage = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPEG",
                    AuthorUsername = "user1",
                    Content = "Test Message " + seedPostId,
                    timestamp = DateTime.Parse("2022-05-02").ToUniversalTime(),
                });
                seedPostId++;
            }
            for(int i = 0; i < 18; i++)
            {
                seedPosts.Add(new Post
                {
                    Id = seedPostId.ToString(),
                    AuthorProfileImage = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPEG",
                    AuthorUsername = "user1",
                    Content = "Test Message " + seedPostId,
                    timestamp = DateTime.Parse("2022-05-03").ToUniversalTime(),
                });
                seedPostId++;
            }
            for(int i = 0; i < 20; i++)
            {
                seedPosts.Add(new Post
                {
                    Id = seedPostId.ToString(),
                    AuthorProfileImage = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPEG",
                    AuthorUsername = "user1",
                    Content = "Test Message " + seedPostId,
                    timestamp = DateTime.Parse("2022-05-04").ToUniversalTime(),
                });
                seedPostId++;
            }
            for(int i = 0; i < 25; i++)
            {
                seedPosts.Add(new Post
                {
                    Id = seedPostId.ToString(),
                    AuthorProfileImage = "https://myapp-a3-cloud.s3.ap-southeast-2.amazonaws.com/user1.JPEG",
                    AuthorUsername = "user1",
                    Content = "Test Message " + seedPostId,
                    timestamp = DateTime.Parse("2022-05-05").ToUniversalTime(),
                });
                seedPostId++;
            }

            //Add seed posts
            modelBuilder.Entity<Post>().HasData(seedPosts);

        }

    }
}