namespace MSU.TI.mmalgo.Stack
{
    public class BasicOperationsTest
    {
        [Fact(DisplayName = "Test stack construction")]
        public void TestStackConstruction()
        {
            Stack<int> stack = new();
            Assert.Equal(16, stack.Capacity);

            stack = new(15);
            Assert.Equal(16, stack.Capacity);

            Assert.Throws<ArgumentOutOfRangeException>(() => stack = new(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => stack = new(-10));
        }

        [Fact(DisplayName = "Test push and pop")]
        public void TestPopAndPush()
        {
            Stack<int> stack = new();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var exception = Record.Exception(() => Assert.Equal(3, stack.Pop()));
            Assert.Null(exception);

            exception = Record.Exception(() => Assert.Equal(2, stack.Pop()));
            Assert.Null(exception);

            exception = Record.Exception(() => Assert.Equal(1, stack.Pop()));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Test pop on empty stack")]
        public void TestPopOnEmptyStack()
        {
            Stack<int> stack = new();

            Assert.Throws<StackUnderflowException>(() => stack.Pop());
        }
    }
}