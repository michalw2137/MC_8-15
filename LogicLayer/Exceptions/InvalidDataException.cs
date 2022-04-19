namespace LogicLayer.Exceptions
{
    [Serializable]
    public class InvalidDataException : Exception
    {
        public InvalidDataException() : base() { }
        public InvalidDataException(string message) : base(message) { }
        public InvalidDataException(string message, Exception inner) : base(message, inner) { }
    }
}