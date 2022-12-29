namespace AngbandOS.Core.WeightedRandoms
{
    internal class StoreOwnerAcceptedComments : WeightedRandom<string>
    {
        public StoreOwnerAcceptedComments()
        {
            Add(1, "Okay.", "Fine.", "Accepted!", "Agreed!", "Done!", "Taken!");
        }
    }
}
