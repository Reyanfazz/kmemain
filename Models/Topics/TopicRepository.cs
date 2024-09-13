
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace kme.Models.Topics
{

    public class TopicRepository
    {
        private readonly TopicContext _context;

        public TopicRepository(TopicContext context)
        {
            _context = context;
        }

        public void ATopic(Topic topic)
        {
            _context.Topics.Add(topic);
            _context.SaveChanges();
        }
    }

}


