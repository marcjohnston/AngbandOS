namespace AngbandOS.Core.Items;

[Serializable]
internal class ConstitutionRingItem : RingItem
{
    public ConstitutionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ConstitutionRingItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
        {
            power = -1;
        }
        TypeSpecificValue = 1 + GetBonusValue(5, level);
        if (power < 0)
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - TypeSpecificValue;
        }
    }
}