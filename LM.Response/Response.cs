using System.Runtime.Serialization;

namespace LM.Responses
{
    [DataContract]
    public class Response<TValue> : Response
    {
        Response() { }

        internal Response(Message message)
            : base(message) { }

        internal Response(Message message, TValue value)
            : base(message) => SetValue(value);

        internal Response(TValue value) => SetValue(value);

        public static new Response<TValue> Create() => new Response<TValue>();

        public static Response<TValue> Create(TValue value) => new Response<TValue>(value);

        public static new Response<TValue> Ok() => new Response<TValue>();

        public static Response<TValue> Ok(Message message, TValue value) => new Response<TValue>(message, value);

        public static Response<TValue> Ok(TValue value) => new Response<TValue>(value);

        [DataMember]
        public Maybe<TValue> Data { get; set; } = Maybe<TValue>.Create();

        public Response<TValue> SetValue(TValue value)
        {
            Data = Maybe<TValue>.Create(value);
            return this;
        }

        public new Response<TValue> AddMessage(Message message)
        {
            base.AddMessage(message);

            return this;
        }

        public static implicit operator Response<TValue>(TValue value) => Create(value);
    }
}