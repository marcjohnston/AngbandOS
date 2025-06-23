// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PowerDragonScript : Script, IActivateItemScript
{
    private PowerDragonScript(Game game) : base(game) { }

    public UsedResultEnum ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        Game.RunScript(nameof(Missile300r4ProjectileScript));
        Game.MsgPrint("Your armor glows many colors...");
        Game.FearTimer.ResetTimer();
        Game.SuperheroismTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.RestoreHealth(30);
        Game.RunScript(nameof(Blessing1d50p50TimerScript));
        Game.RunScript(nameof(AcidResistance1d50p50TimerScript));
        Game.LightningResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.RunScript(nameof(FireResistance1d50p50TimerScript));
        Game.ColdResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        Game.PoisonResistanceTimer.AddTimer(base.Game.DieRoll(50) + 50);
        return UsedResultEnum.True;
    }
}
