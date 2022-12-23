namespace AngbandOS.Core.WeightedRandoms
{
    internal class HorrificDescriptions : WeightedRandom<string>
    {
        public HorrificDescriptions() 
        {
            Add(1, "abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
                "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
                "sacrilegious", "terrible", "unclean", "unspeakable");
        }
    }
}
