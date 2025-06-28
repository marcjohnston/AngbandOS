// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class IcePlayerEffect : PlayerEffectUniversalScript
{
    private IcePlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something sharp and cold!";
    public override IdentifiedResultEnum Apply(Monster mPtr, int dam)
    {
        string killer = mPtr.IndefiniteVisibleName;
        Game.ColdDam(dam, killer);
        if (!Game.HasShardResistance)
        {
            Game.BleedingTimer.AddTimer(Game.DiceRoll(5, 8));
        }
        if (!Game.HasSoundResistance)
        {
            Game.StunTimer.AddTimer(Game.DieRoll(15));
        }
        if (!(Game.HasColdResistance || Game.ColdResistanceTimer.Value != 0) || Game.DieRoll(12) == 1)
        {
            if (!Game.HasColdImmunity)
            {
                Game.InvenDamage(Game.SetColdDestroy, 3);
            }
        }
        return IdentifiedResultEnum.True;
    }
}
