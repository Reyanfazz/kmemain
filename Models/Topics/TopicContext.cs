
using Microsoft.EntityFrameworkCore;
using kme.Models.Topics;

namespace kme.Models.Topics
{
    public class TopicContext : DbContext
    {
        public TopicContext(DbContextOptions options) : base(options) 
        { 
              
        }

        public DbSet<Topic>Topics { get; set; }

        public DbSet<kme.Models.Topics.TopicsModel> TopicsModel { get; set; } = default!;

    }
}
