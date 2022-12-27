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
}
