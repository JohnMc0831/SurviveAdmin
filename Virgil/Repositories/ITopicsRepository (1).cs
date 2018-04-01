using System.Collections.Generic;
using Virgil.Models;

namespace Virgil.Repositories
{
    interface ITopicsRepository
    {
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