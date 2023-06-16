namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RodSpeed : RodItemFactory
{
    private RodSpeed(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    public override char Character => '-';
    public override string Name => "Speed";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 50000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Speed";
    public override int Level => 95;
    public override int[] Locale => new int[] { 95, 0, 0, 0 };
    public override int? SubCategory => 11;
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            if (SaveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(30) + 15))
            {
                zapRodEvent.Identified = true;
            }
        }
        else
        {
            SaveGame.Player.TimedHaste.AddTimer(5);
        }
        zapRodEvent.Item.TypeSpecificValue = 99;
    }
    public override Item CreateItem() => new SpeedRodItem(SaveGame);
}
