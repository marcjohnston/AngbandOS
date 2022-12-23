namespace AngbandOS.Core
{
    internal class WeightedRandom<T>
    {
        Dictionary<int, T> values = new Dictionary<int, T>();
        public void Add(int weight, T value)
        {
            for (int i = 0; i < weight; i++)
            {
                values.Add(values.Count, value);
            }
        }
        public T Choose()
        {
            int choice = Program.Rng.RandomLessThan(values.Count);
            return values[choice];
        }
    }
    internal class WeightedRandomAction
    {
        Dictionary<int, Action> values = new Dictionary<int, Action>();
        public void Add(int weight, Action value)
        {
            for (int i = 0; i < weight; i++)
            {
                values.Add(values.Count, value);
            }
        }
        public void Choose()
        {
            int choice = Program.Rng.RandomLessThan(values.Count);
            values[choice]();
        }
    }
}
