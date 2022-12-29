namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SoftArmorFilthyRag : SoftArmorItemClass
    {
        private SoftArmorFilthyRag(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '(';
        public override Colour Colour => Colour.Black;
        public override string Name => "Filthy Rag";

        public override int Ac => 1;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1;
        public override string FriendlyName => "& Filthy Rag~";
        public override int? SubCategory => 1;
        public override int ToA => -1;
        public override int Weight => 20;
    }
}
