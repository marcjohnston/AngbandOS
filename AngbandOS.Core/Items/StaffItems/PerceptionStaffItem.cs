namespace AngbandOS.Core.Items;

[Serializable]
internal class PerceptionStaffItem : StaffItem
{
    public PerceptionStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StaffPerception>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(15) + 5;
    }
}