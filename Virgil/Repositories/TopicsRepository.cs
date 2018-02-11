using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgil.Models;
using WebGrease.Css.Extensions;


namespace Virgil.Repositories
{
    class TopicsRepository : ITopicsRepository
    {
        private readonly VirgilContext db = new VirgilContext();
        private bool disposed = false;

        public TopicsRepository()
        {
            
        }

        public Footnotes GetFootnotes()
        {
            return db.Footnotes.First();
        }

        public void UpdateFootnotes(Footnotes notes)
        {
            db.Entry(notes).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<EncounterDTO> GetEncounters()
        {
            List<Encounter> encounters = db.Encounters.Include(e => e.Sections).OrderBy(e => e.id).ToList();
            List<EncounterDTO> encs = encounters.Select(e => new EncounterDTO(e)).ToList();
            foreach (var enc in encs)
            {
                foreach (var section in enc.Sections)
                {
                    var s = db.Sections.Include(sect => sect.Topics).First(sect => sect.id == section.id);
                    section.Topics = s.Topics.Select(t => new TopicDTO(t)).ToList();
                }
            }
            return encs;
        }

        public List<Section> GetSections()
        {
            return db.Sections.OrderBy(s => s.id).ToList();
        }

        public List<Section> GetSectionsWithEncounters()
        {
            return db.Sections.Include(s => s.Encounter).Include(s => s.Topics).OrderBy(s => s.id).ToList();
        }

        public Section GetSectionById(int id)
        {
            return db.Sections.Find(id);
        }

        public Section GetSectionWithTopicsById(int id)
        {
            return db.Sections.Include(s => s.Topics).FirstOrDefault(s => s.id == id);
        }

        public void UpdateSection(Section section)
        {
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
        }

        //public List<Item> GetSectionsAsItems()
        //{
        //    return db.Sections.OrderBy(s => s.id).Select(s => new Item
        //    {
        //        SectionIcon = s.SectionIcon,
        //        SectionName = s.SectionName,
        //        Children = s.Topics.Select(t => new Item
        //        {
        //            Icon = t.TopicIcon,
        //            Name = t.Title,
        //            Summary = t.Summary
        //        }).ToList()
        //    }).ToList();
        //}

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

        public List<SectionDTO> GetSectionsWithTopics()
        {
            //var sectDTOs = new List<SectionDTO>();
            var sects = db.Sections.Include(s => s.Topics).ToList();
            return sects.Select(s => new SectionDTO(s)).ToList();
            //foreach (var s in sects)
            //{
            //    sectDTOs.Add(new SectionDTO
            //    {
            //        EncounterId = s.EncounterId,
            //        id = s.id,
            //        SectionName = s.SectionName,
            //        SectionIcon = s.SectionIcon,
            //        Topics = s.Topics.Select(t => new TopicDTO(t)).ToList()
            //    });
            //}
            //return sectDTOs;
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

        public List<Icon> GetIcons()
        {
            return db.Icons.OrderBy(i => i.icon1).ToList();
        }
    }
}
