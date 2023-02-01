namespace AngbandOS.Core.WeightedRandoms
{
    internal class WeightedRandom<T>
    {
        Dictionary<int, T> dictionary = new Dictionary<int, T>();

        public WeightedRandom() { }

        public WeightedRandom(IEnumerable<T> values, Func<T, bool>? predicate)
        {
            foreach (T value in values)
            {
                if (predicate == null || predicate(value))
                {
                    Add(1, value);
                }
            }
        }

        public WeightedRandom(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Add(1, value);
            }
        }

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
        public T? Choose()
        {
            if (dictionary.Count == 0)
            {
                return default;
            }
            int choice = Program.Rng.RandomLessThan(dictionary.Count);
            return dictionary[choice];
        }
    }
}
