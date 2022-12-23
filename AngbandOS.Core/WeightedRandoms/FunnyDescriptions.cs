namespace AngbandOS.Core.WeightedRandoms
{
    internal class FunnyDescriptions : WeightedRandom<string>
    {
        public FunnyDescriptions()
        {
            Add(1, "silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
                "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
                "amazing", "incredible", "chaotic", "wild", "preposterous");
        }
    }
}
