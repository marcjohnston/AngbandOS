// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class ConfusionPlayerEffect : PlayerEffect
{
    private ConfusionPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something puzzling!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int dam)
    {
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasConfusionResistance)
        {
            dam *= 5;
            dam /= Game.DieRoll(6) + 6;
        }
        if (!Game.HasConfusionResistance)
        {
            Game.ConfusionTimer.AddTimer(Game.DieRoll(20) + 10);
        }
        Game.TakeHit(dam, killer);
        return IdentifiedResultEnum.True;
    }
}
