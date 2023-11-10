using System.Collections;
using System.Numerics;

namespace MSU.TI.mmalgo.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int _defaultCapacity = 16;

        // array with actual stack values
        private T[] _values;

        // index of the top element. -1 when empty
        private int _top = -1;

        private readonly int _minimumCapacity;

        // Constructs a stack with provided capacity
        public Stack(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException("Initial capacity should be greater than zero");

            // set minimum capacity to the next power of 2
            this._minimumCapacity = 2 << (31 - BitOperations.LeadingZeroCount((uint)(capacity - 1)));

            _values = new T[_minimumCapacity];
        }

        // Constructs a stack with default capacity of _defaultCapacity
        public Stack() : this(_defaultCapacity) { }

        // Push value on top of this stack
        public void Push(T value) 
        {
            ResizeIfNeeded();

            _values[++_top] = value;
        }

        // Pops value from this stack
        public T Pop() {
            // throw exception if stack is empty
            if (_top == -1) throw new StackUnderflowException();

            ResizeIfNeeded();

            // return top element and decrement top pointer
            return _values[_top--];
        }

        // Actual size of this stack
        public int Size
        { get { return _top + 1; } }

        // Stack capacity
        public int Capacity
        { get { return _values.Length; } }

        private void ResizeIfNeeded()
        {
            // check if we need to extend the array
            if (_top == _values.Length - 1)
            {
                Resize(_values.Length * 2);
            }

            // check if we need to shrink the array
            if ((_top <= _values.Length / 4) && (_values.Length > _minimumCapacity))
            {
                Resize(_values.Length / 2);
            }
        }

        private void Resize(int newSize)
        {
            T[] newValues = new T[newSize];

            for (int i = 0; i <= _top; i++) newValues[i] = _values[i];

            _values = newValues;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i <= _top; i++)
            {
                yield return _values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

}
