namespace Exsr2
{
    public class Node<T>
    {
        private T data;
        private Node<T> next;
        public T Data { get => data; private set => data = value; }
        public Node<T> Next { get => next; private set => next = value; }
        public Node(T i) { data = i; next = null; }
        public Node<T> Add(T i)
        {
            next = new Node<T>(i);
            return next;
        }
    }
    public class Queue<T>
    {
        private Node<T> Head = null;
        private Node<T> Tail = null;
        public T Pop()
        {
            T result = Head.Data;
            Head = Head.Next;
            return result;
        }
        public void Push(T i)
        {
            if (Head == null)
            {
                Head = new Node<T>(i);
                Tail = Head;
            }
            else
                Tail = Tail.Add(i);
        }
    }

    public class Programm
    {
        static void Main()
        {
            Queue<int> q = new();
            int M = int.Parse(Console.ReadLine());
            for (int i = 0; i < M; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "-")
                    Console.WriteLine($"{q.Pop()}");
                if (input[0] == "+")
                    q.Push(int.Parse(input[1]));
            }
        }
    }
}
