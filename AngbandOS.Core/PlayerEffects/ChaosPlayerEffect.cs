// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class ChaosPlayerEffect : PlayerEffect
{
    private ChaosPlayerEffect(Game game) : base(game) { } // This object is a singleton.
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
            Game.MsgPrint("You are hit by a wave of anarchy!");
        }
        if (Game.HasChaosResistance)
        {
            dam *= 6;
            dam /= Game.DieRoll(6) + 6;
        }
        if (!Game.HasConfusionResistance)
        {
            Game.ConfusedTimer.AddTimer(Game.RandomLessThan(20) + 10);
        }
        if (!Game.HasChaosResistance)
        {
            Game.HallucinationsTimer.AddTimer(Game.DieRoll(10));
            if (Game.DieRoll(3) == 1)
            {
                Game.MsgPrint("Your body is twisted by chaos!");
                Game.RunScript(nameof(GainMutationScript));
            }
        }
        if (!Game.HasNetherResistance && !Game.HasChaosResistance)
        {
            if (Game.HasHoldLife && Game.RandomLessThan(100) < 75)
            {
                Game.MsgPrint("You keep hold of your life force!");
            }
            else if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                Game.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (Game.HasHoldLife)
            {
                Game.MsgPrint("You feel your life slipping away!");
                Game.LoseExperience(500 + (Game.ExperiencePoints.IntValue / 1000 * Constants.MonDrainLife));
            }
            else
            {
                Game.MsgPrint("You feel your life draining away!");
                Game.LoseExperience(5000 + (Game.ExperiencePoints.IntValue / 100 * Constants.MonDrainLife));
            }
        }
        if (!Game.HasChaosResistance || Game.DieRoll(9) == 1)
        {
            Game.InvenDamage(Game.SetElecDestroy, 2);
            Game.InvenDamage(Game.SetFireDestroy, 2);
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}
