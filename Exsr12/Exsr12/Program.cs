namespace Exsr12
{
    class Tree
    {
        int ignore;
        Dictionary<int, List<int>> data;

        public void Add(int v, int u)
        {
            if (!data.ContainsKey(v))
                data[v] = new List<int>();
            data[v].Add(u);
            if (!data.ContainsKey(u))
                data[u] = new List<int>();
            data[u].Add(v);
        }
        public List<int> Get(int v)
        {
            List<int> vers = data[v];
            vers.Remove(v);
            return vers;
        }
    }
    class Program
    {
        static void Main()
        {
            string dir = "..\\..\\..\\..\\";
            string fileName = "Tests\\test.txt";
            string[] f = File.ReadAllLines(dir + fileName);
            Tree t = new();

            (int n, int q) = (int.Parse(f[0].Split()[0]), int.Parse(f[0].Split()[1]));

            for (int i = 1; i <= n; i++)
                t.Add(int.Parse(f[i].Split()[0]), int.Parse(f[i].Split()[1]));

            for (int i = n; i <= q; i++)
            {
                (int v, int d) = (int.Parse(f[i].Split()[0]), int.Parse(f[i].Split()[1]) - 1);
                List<int> vers = t.Get(v);
                vers.Remove(v);
                while (d - 1 > 0)
                {
                    List<int> newVers = new();
                    foreach(var e in vers)
                        _ = newVers.Concat(t.Get(e));
                    vers = newVers;
                }
            }

            throw new NotImplementedException();
        }
    }
}