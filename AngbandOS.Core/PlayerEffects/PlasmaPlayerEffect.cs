// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class PlasmaPlayerEffect : PlayerEffect
{
    private PlasmaPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something *HOT*!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int r, int y, int x, int dam, int aRad)
    {
        string killer = mPtr.IndefiniteVisibleName;
        Game.TakeHit(dam, killer);
        if (!Game.HasSoundResistance)
        {
            int kk = Game.DieRoll(dam > 40 ? 35 : (dam * 3 / 4) + 5);
            Game.StunTimer.AddTimer(kk);
        }
        if (!(Game.HasFireResistance || Game.FireResistanceTimer.Value != 0 || Game.HasFireImmunity))
        {
            Game.InvenDamage(Game.SetAcidDestroy, 3);
        }
        return IdentifiedResultEnum.True;
    }
}
