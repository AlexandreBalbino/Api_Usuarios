namespace Domain.Resposta
{
    public class Resposta<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get => Value != null; }

        public Resposta(T value)
        {
            Value = value;
        }
    }
}
