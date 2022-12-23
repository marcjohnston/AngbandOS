namespace AngbandOS.Core
{
    internal class WeightedRandom<T>
    {
        Dictionary<int, T> dictionary = new Dictionary<int, T>();
        public void Add(int weight, params T[] values)
        {
            for (int i = 0; i < weight; i++)
            {
                foreach (T value in values)
                {
                    dictionary.Add(dictionary.Count, value);
                }
            }
        }
        public T Choose()
        {
            int choice = Program.Rng.RandomLessThan(dictionary.Count);
            return dictionary[choice];
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
