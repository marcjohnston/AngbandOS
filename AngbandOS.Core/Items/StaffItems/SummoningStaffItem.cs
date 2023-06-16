namespace AngbandOS.Core.Items;

[Serializable]
internal class SummoningStaffItem : StaffItem
{
    public SummoningStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffSummoning>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
    }
}