namespace MSU.TI.mmalgo.Stack
{
    [Serializable]
    public class StackUnderflowException : Exception
    {
        public StackUnderflowException() : base("Stack is empty") { }
    }
}