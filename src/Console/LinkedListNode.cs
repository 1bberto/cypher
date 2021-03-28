namespace ConsoleApp1
{
    public class LinkedListNode<T> where T : struct
    {
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
        public T Value { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
        }

        public LinkedListNode(T value, LinkedListNode<T> previous)
        {
            Value = value;
            Previous = previous;
        }

        public static bool operator ==(LinkedListNode<T> nodeA, LinkedListNode<T> nodeB)
        {
            if (nodeA?.Value == null && nodeB?.Value == null)
                return true;
            if (nodeA?.Value == null && nodeB?.Value != null)
                return false;
            if (nodeA?.Value != null && nodeB?.Value == null)
                return false;

            return nodeA.Value.Equals(nodeB.Value);
        }

        public static bool operator !=(LinkedListNode<T> nodeA, LinkedListNode<T> nodeB)
        {
            if (nodeA?.Value == null && nodeB?.Value == null)
                return false;
            if (nodeA?.Value == null && nodeB?.Value != null)
                return true;
            if (nodeA?.Value != null && nodeB?.Value == null)
                return true;

            return !nodeA.Value.Equals(nodeB.Value);
        }

        public static bool operator ==(LinkedListNode<T> nodeA, T data)
        {
            return nodeA.Value.Equals(data);
        }

        public static bool operator !=(LinkedListNode<T> nodeA, T data)
        {
            return !nodeA.Value.Equals(data);
        }
    }
}