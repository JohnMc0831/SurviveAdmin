using System.Collections.Generic;
using Virgil.Models;

namespace Virgil.Repositories
{
public interface ITopicsRepository
    {
        List<EncounterDTO> GetEncounters();
        List<Section> GetSections();
        List<SectionDTO> GetSectionsWithTopics();
        Section GetSectionById(int id);

        void UpdateSection(Section section);
        //List<Item> GetSectionsAsItems();
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