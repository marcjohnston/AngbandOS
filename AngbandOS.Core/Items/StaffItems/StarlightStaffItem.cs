namespace AngbandOS.Core.Items;

[Serializable]
internal class StarlightStaffItem : StaffItem
{
    public StarlightStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffStarlight>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
    }
}