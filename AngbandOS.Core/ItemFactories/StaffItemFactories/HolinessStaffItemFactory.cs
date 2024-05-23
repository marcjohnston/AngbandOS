// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HolinessStaffItemFactory : StaffItemFactory
{
    private HolinessStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Holiness";

    public override int StaffChargeCount => Game.DieRoll(2) + 2;
    public override int Cost => 4500;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string CodedName => "Holiness";
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (70, 2)
    };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.RunSuccessfulScriptInt(nameof(DispelEvil4xScript), 120))
        {
            eventArgs.Identified = true;
        }
        int k = 3 * Game.ExperienceLevel.IntValue;
        if (Game.ProtectionFromEvilTimer.AddTimer(Game.DieRoll(25) + k))
        {
            eventArgs.Identified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (Game.FearTimer.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (Game.RestoreHealth(50))
        {
            eventArgs.Identified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            eventArgs.Identified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            eventArgs.Identified = true;
        }
    }
}
