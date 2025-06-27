// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class ExplodePlayerEffect : PlayerEffect
{
    private ExplodePlayerEffect(Game game) : base(game) { } // This object is a singleton.
    protected override bool Apply(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by an explosion of shrapnel!");
        }
        if (Game.HasShardResistance)
        {
            dam *= 6;
            dam /= Game.DieRoll(6) + 6;
        }
        else
        {
            Game.BleedingTimer.AddTimer(dam);
        }
        if (!Game.HasShardResistance || Game.DieRoll(13) == 1)
        {
            Game.InvenDamage(Game.SetColdDestroy, 2);
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}
