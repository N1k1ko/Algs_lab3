namespace Exsr9
{
    class Segment
    {
        private int begin;
        private int end;
        private int length;
        public int Begin { get => begin; private set => begin = value; }
        public int End { get => end; private set => end = value; }
        public int Length { get => length; private set => length = value; }
        public Segment(int begin, int end) { Begin = begin; End = end; Length = end-begin; }
        public bool ContainDot(int dot) => this.begin <= dot && this.end >= dot;
    }

    class Programm
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Segment[] segments = new Segment[n];
            for (int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split();
                segments[i] = new(int.Parse(s[0]), int.Parse(s[1]));
            }

            int m = int.Parse(Console.ReadLine());
            for (int i=0; i<m;i++)
            {
                int dot = int.Parse(Console.ReadLine());
                int result = -2;
                for (int j=0; j<n; j++)
                {
                    if (segments[j].ContainDot(dot))
                        result = j;
                    else if (result != -2)
                        break;
                }   
                Console.WriteLine(result+1);
            }
        }
    }
}