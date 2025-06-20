// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BallOfAcid50r2AndResistAcid1d20p20Script : Script, IActivateItemScript
{
    private BallOfAcid50r2AndResistAcid1d20p20Script(Game game) : base(game) { }

    public UsedResult ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        Game.RunScript(nameof(Acid50r2ProjectileScript));
        Game.RunScript(nameof(AcidResistance1d20p20TimerScript));
        return new UsedResult(true);
    }
}
