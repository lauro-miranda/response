using System.Runtime.Serialization;

namespace LM.Responses
{
    [DataContract]
    public class Maybe<TValue>
    {
        Maybe() { }

        Maybe(TValue value) => Value = value;

        public static Maybe<TValue> Create(TValue value) => new Maybe<TValue>(value);

        public static Maybe<TValue> Create() => new Maybe<TValue>();

        [DataMember]
        public bool HasValue => Value != null;

        [DataMember]
        public TValue Value { get; set; }

        public static implicit operator Maybe<TValue>(TValue value) => Create(value);
    }
}
