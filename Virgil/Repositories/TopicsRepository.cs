using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgil.Models;


namespace Virgil.Repositories
{
    class TopicsRepository : ITopicsRepository
    {
        private readonly VirgilContext db = new VirgilContext();
        private bool disposed = false;

        public TopicsRepository()
        {
            
        }

        public List<string> GetSupportedLanguages()
        {
            var languages = new List<string>
            {
                "English",
                "German",
                "Spanish"
            };
            return languages;
        }

        public List<Topic> GetTopics()
        {
            return db.Topics.OrderBy(t => t.DisplayOrder).ToList();
        }

        public Topic GetTopicById(int id)
        {
            return db.Topics.Find(id);
        }

        public Topic GetTopicByName(string name)
        {
            return db.Topics.First(t => t.Title.Contains(name));
        }

        public int GetNextTopicDisplayOrderValue()
        {
            if (db.Topics.Any())
            {
                int maxDisplayOrder = db.Topics.Max(t => t.DisplayOrder);
                return maxDisplayOrder + 1;
            }
            return 1;
        }

        public void AddTopic(Topic topic)
        {
            db.Topics.Add(topic);
            db.SaveChanges();
        }

        public void UpdateTopic(Topic topic)
        {
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveTopic(Topic topic)
        {
            db.Entry(topic).State = EntityState.Deleted;
            db.SaveChanges();
        }

        //Media
        public void AddMedia(Medium file, Topic topic)
        {
            topic.Media.Add(file);
            db.SaveChanges();
        }
    }
}
