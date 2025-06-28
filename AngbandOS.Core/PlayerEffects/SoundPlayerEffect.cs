// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class SoundPlayerEffect : PlayerEffect
{
    private SoundPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by a loud noise!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int r, int y, int x, int dam, int aRad)
    {
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasSoundResistance)
        {
            dam *= 5;
            dam /= Game.DieRoll(6) + 6;
        }
        else
        {
            int kk = Game.DieRoll(dam > 90 ? 35 : (dam / 3) + 5);
            Game.StunTimer.AddTimer(kk);
        }
        if (!Game.HasSoundResistance || Game.DieRoll(13) == 1)
        {
            Game.InvenDamage(Game.SetColdDestroy, 2);
        }
        Game.TakeHit(dam, killer);
        return IdentifiedResultEnum.True;
    }
}
