namespace AngbandOS.Core.WeightedRandoms
{
    internal class FunnyComments : WeightedRandom<string>
    {
        public FunnyComments()
        {
            Add(1, "Wow, cosmic, man!", "Rad!", "Groovy!", "Cool!", "Far out!");
        }
    }
}
