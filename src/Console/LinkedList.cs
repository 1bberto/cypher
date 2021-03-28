namespace ConsoleApp1
{
    public class LinkedList<T> where T : struct
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; } = 0;

        public void Append(T value)
        {
            var current = Head;

            while (current?.Next != null)
            {
                current = current.Next;
            }

            var newNode = new LinkedListNode<T>(value, current);

            if (current != null)
            {
                current.Next = newNode;
            }
            else
            {
                Head = newNode;
            }

            Tail = newNode;

            Count++;
        }

        public void Prepend(T value)
        {
            var newHead = new LinkedListNode<T>(value)
            {
                Next = Head
            };

            Head.Previous = newHead;

            Head = newHead;

            Count++;
        }

        public void RemoveWithValue(T data)
        {
            if (Head == null)
            {
                return;
            }

            if (Head == data)
            {
                Head = Head.Next;
                Count--;
                return;
            }

            var currentNode = Head;

            while (currentNode.Next != null)
            {
                if (currentNode.Next == data)
                {
                    currentNode.Next = currentNode.Next.Next;
                    Count--;
                    return;
                }

                currentNode = currentNode.Next;
            }
        }

        public void Join()
        {
            Tail.Next = Head;

            Head.Previous = Tail;
        }

        public LinkedListNode<T> FindItem(T value)
        {
            var internalCounter = 0;
            var current = Head;
            while (current?.Next != null)
            {
                if (current == value)
                {
                    return current;
                }

                current = current.Next;

                internalCounter++;

                if (internalCounter > Count)
                {
                    break;
                }
            }

            return null;
        }
    }
}