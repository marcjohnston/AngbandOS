// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StarlightStaffItemFactory : StaffItemFactory
{
    private StarlightStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Starlight";

    public override int StaffChargeCount => Game.DieRoll(5) + 6;

    public override int Cost => 800;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Starlight";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.BlindnessTimer.Value == 0)
        {
            Game.MsgPrint("The end of the staff glows brightly...");
        }
        for (int k = 0; k < 8; k++)
        {
            Game.LightLine(Game.OrderedDirection[k]);
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
