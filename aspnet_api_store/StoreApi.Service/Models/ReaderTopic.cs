using StoreApi.Service.Models;
using StoreApi.Service.Models.Abstracts;

namespace StoreApi.Service.Models
{
    public class ReaderTopic : AEntity
    {
        public Reader Reader { get; set; }

        public Topic Topic { get; set; }

        public ReaderTopic() {}

        public ReaderTopic(Reader reader, Topic topic)
        {
            Reader = reader;
            Topic = topic;
        }
    }
}