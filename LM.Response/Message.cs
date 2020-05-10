using System;
using LM.Responses.Extensions;

namespace LM.Responses
{
    public class Message
    {
        [Obsolete("Para desserialização da classe.", true)]
        Message() { }

        public static Message Create(string property, string text, MessageType type = MessageType.BusinessError) => new Message(property, text, type);

        public static Message Create(string text, MessageType type = MessageType.Success) => new Message(text, type);

        internal Message(string text, MessageType type)
        {
            if (string.IsNullOrEmpty(text))
                throw new InvalidOperationException(nameof(text));

            Text = text;
            Type = type;
        }

        internal Message(string nameOfProperty, string text, MessageType type = MessageType.BusinessError)
        {
            if (string.IsNullOrEmpty(text))
                throw new InvalidOperationException(nameof(nameOfProperty));

            if (string.IsNullOrEmpty(text))
                text = $"{nameof(nameOfProperty)} não é válido(a).";

            Text = text;
            Type = type;
            Property = nameOfProperty;
        }

        public MessageType Type { get; set; }

        public string Property { get; set; }

        public string TypeDescription => Type.GetDescription();

        public string Text { get; set; }
    }
}