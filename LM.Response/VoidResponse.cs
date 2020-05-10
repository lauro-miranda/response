using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LM.Responses
{
    [DataContract]
    public class Response
    {
        internal protected Response() { }

        internal Response(Message message) => AddMessage(message);

        public static Response Ok() => new Response();

        public static Response Create() => new Response();

        public static Response Ok(Message message) => new Response(message);

        [DataMember]
        public IReadOnlyCollection<Message> Messages => _messages;

        private List<Message> _messages { get; set; } = new List<Message>();

        [DataMember]
        public bool HasError => _messages.Any(x => x.Type.Equals(MessageType.BusinessError) || x.Type.Equals(MessageType.CriticalError));

        public Response AddMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            _messages.Add(message);

            return this;
        }
    }
}