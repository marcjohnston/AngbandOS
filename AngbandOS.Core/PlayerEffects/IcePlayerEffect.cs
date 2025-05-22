// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class IcePlayerEffect : PlayerEffect
{
    private IcePlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override bool Apply(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by something sharp and cold!");
        }
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
        return true;
    }
}
