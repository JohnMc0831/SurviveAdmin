using System.Collections.Generic;
using Virgil.Models;

namespace Virgil.Repositories
{
    interface IHomeRepository
    {
        Topic GetTopicById(int id);
        Topic GetTopicByName(string name);
        List<Topic> GetTopics();
        void AddTopic(Topic topic);
        void UpdateTopic(Topic topic);
        void RemoveTopic(Topic topic);
        int GetNextTopicDisplayOrderValue();
    }
}