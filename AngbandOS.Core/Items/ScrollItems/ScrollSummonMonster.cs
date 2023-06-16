namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollSummonMonster : ScrollItemClass
{
    private ScrollSummonMonster(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Summon Monster";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Summon Monster";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int? SubCategory => 4;
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        for (int i = 0; i < Program.Rng.DieRoll(3); i++)
        {
            if (eventArgs.SaveGame.Level.SummonSpecific(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, eventArgs.SaveGame.Difficulty, null))
            {
                eventArgs.Identified = true;
            }
        }
    }
    public override Item CreateItem() => new SummonMonsterScrollItem(SaveGame);
}
