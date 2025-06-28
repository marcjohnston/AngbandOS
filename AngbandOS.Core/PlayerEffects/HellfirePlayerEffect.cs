// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class HellfirePlayerEffect : PlayerEffect
{
    private HellfirePlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int r, int y, int x, int dam, int aRad)
    {
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.PrimaryRealm.ResistantToHolyAndHellProjectiles || Game.SecondaryRealm.ResistantToHolyAndHellProjectiles)
        {
            dam /= 2;
        }
        else if (Game.PrimaryRealm.SusceptibleToHolyAndHellProjectiles || Game.SecondaryRealm.SusceptibleToHolyAndHellProjectiles)
        {
            dam *= 2;
        }
        Game.TakeHit(dam, killer);
        return IdentifiedResultEnum.True;
    }
}
