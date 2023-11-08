using System;

namespace MSU.TI.mmalgo.Stack
{
    public class CapacityManagementTests
    {

        [Fact(DisplayName = "Test array extension")]
        public void TestArrayExtension()
        {
            Stack<int> stack = new(3);
            Assert.Equal(4, stack.Capacity);

            for (var i = 0; i <= 3; i++) stack.Push(i);

            Assert.Equal(4, stack.Size);
            Assert.Equal(4, stack.Capacity);

            stack.Push(4);

            Assert.Equal(5, stack.Size);
            Assert.Equal(8, stack.Capacity);
        }

        [Fact(DisplayName = "Test array shrink")]
        public void TestArrayShrink()
        {
            Stack<int> stack = new(3);
            Assert.Equal(4, stack.Capacity);

            // push 17 elements
            for (var i = 0; i <= 16; i++) stack.Push(i);

            Assert.Equal(17, stack.Size);
            Assert.Equal(32, stack.Capacity);

            // pop 9 elements
            for (var i = 0; i <= 8; i++)
            {
                var exception = Record.Exception(() => stack.Pop());
                Assert.Null(exception);
            }

            Assert.Equal(8, stack.Size);
            Assert.Equal(16, stack.Capacity);

            // pop 4 elements
            for (var i = 0; i <= 3; i++)
            {
                var exception = Record.Exception(() => stack.Pop());
                Assert.Null(exception);
            }
            Assert.Equal(4, stack.Size);
            Assert.Equal(8, stack.Capacity);
        }
    }
}
