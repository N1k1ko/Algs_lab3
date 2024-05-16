namespace Exsr3
{
    public class Node<T>
    {
        private T data;
        private Node<T> back;
        public T Data { get => data; private set => data = value; }
        public Node<T> Back { get => back; private set => back = value; }
        public Node(T i) { data = i; back = null; }
        public Node<T> Add(T i) => new(i) { back = this };
    }
    public class Stack<T>
    {
        private int length = 0;
        private Node<T> Tail = null;
        public int Length { get => length; private set => length = value; }
        public T Pop()
        {
            T result = Tail.Data;
            Tail = Tail.Back;
            length--;
            return result;
        }
        public void Push(T i)
        {
            if (Tail == null)
                Tail = new Node<T>(i);
            else
                Tail = Tail.Add(i);
            length++;
        }
    }

    public class Programm
    {
        static void Main()
        {
            string dir = "..\\..\\..\\..\\";
            string fileName = "Tests\\tests.txt";
            string[] f = File.ReadAllLines(dir + fileName);

            List<string> result = new();
            for (int i = 0; i < int.Parse(f[0]); i++)
                result.Add(GetResult(f[1 + i]));
            File.WriteAllLines(dir + "result.txt", result);
        }
        static string GetResult(string str)
        {
            if (str.Length % 2 != 0)
                return "NO";
            Stack<char> stack = new();
            foreach (char c in str)
            {
                if (c == '(' || c == '[')
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.Length == 0)
                    return "NO";

                char eq = stack.Pop();
                if ((c == ')' && eq != '(') ||
                    (c == ']' && eq != '['))
                    return "NO";
            }
            return "YES";
        }
    }
}
