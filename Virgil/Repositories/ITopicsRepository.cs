using System.Collections.Generic;
using Virgil.Models;

namespace Virgil.Repositories
{
    public interface ITopicsRepository
    {
        Footnotes GetFootnotes();
        void UpdateFootnotes(Footnotes notes);
        List<EncounterDTO> GetEncounters();
        List<Section> GetSections();
        List<SectionDTO> GetSectionsWithTopics();
        Section GetSectionWithTopicsById(int id);
        Section GetSectionById(int id);
        List<Section> GetSectionsWithEncounters();
        void UpdateSection(Section section);
        Topic GetTopicById(int id);
        Topic GetTopicByName(string name);
        List<Topic> GetTopics();
        void AddTopic(Topic topic);
        void UpdateTopic(Topic topic);
        void RemoveTopic(Topic topic);
        int GetNextTopicDisplayOrderValue();
        void AddMedia(Medium file, Topic topic);
        List<Icon> GetIcons();
    }
}