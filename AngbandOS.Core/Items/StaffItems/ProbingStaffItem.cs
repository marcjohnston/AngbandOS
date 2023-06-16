namespace AngbandOS.Core.Items;

[Serializable]
internal class ProbingStaffItem : StaffItem
{
    public ProbingStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffProbing>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
    }
}