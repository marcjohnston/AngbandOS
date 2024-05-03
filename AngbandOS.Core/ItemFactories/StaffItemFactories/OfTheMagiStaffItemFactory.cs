// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OfTheMagiStaffItemFactory : StaffItemFactory
{
    private OfTheMagiStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "the Magi";

    public override int StaffChargeCount => Game.DieRoll(2) + 2;
    public override int Cost => 4500;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string FriendlyName => "the Magi";
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (70, 2)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.TryRestoringAbilityScore(Ability.Intelligence))
        {
            eventArgs.Identified = true;
        }
        if (Game.Mana.IntValue < Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
            Game.FractionalMana = 0;
            eventArgs.Identified = true;
            Game.MsgPrint("Your feel your head clear.");
        }
    }
}
