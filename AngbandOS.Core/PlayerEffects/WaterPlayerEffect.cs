// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class WaterPlayerEffect : PlayerEffect
{
    private WaterPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something wet!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int r, int y, int x, int dam, int aRad)
    {
        string killer = mPtr.IndefiniteVisibleName;
        if (!Game.HasSoundResistance)
        {
            Game.StunTimer.AddTimer(Game.DieRoll(40));
        }
        if (!Game.HasConfusionResistance)
        {
            Game.ConfusionTimer.AddTimer(Game.DieRoll(5) + 5);
        }
        if (Game.DieRoll(5) == 1)
        {
            Game.InvenDamage(Game.SetColdDestroy, 3);
        }
        Game.TakeHit(dam, killer);
        return IdentifiedResultEnum.True;
    }
}
