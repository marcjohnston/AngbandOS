// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class DarknessPlayerEffect : PlayerEffect
{
    private DarknessPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int y, int x, int dam)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasDarkResistance)
        {
            dam *= 4;
            dam /= Game.DieRoll(6) + 6;
            if (!Game.Race.IsDamagedByDarkness)
            {
                dam = 0;
            }
        }
        else if (!blind && !Game.HasBlindnessResistance)
        {
            Game.BlindnessTimer.AddTimer(Game.DieRoll(5) + 2);
        }
        if (Game.EtherealnessTimer.Value != 0)
        {
            Game.RestoreHealth(dam);
        }
        else
        {
            Game.TakeHit(dam, killer);
        }
        return IdentifiedResultEnum.True;
    }
}
