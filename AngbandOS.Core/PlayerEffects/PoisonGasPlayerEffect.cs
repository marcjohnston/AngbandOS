// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class PoisonGasPlayerEffect : PlayerEffect
{
    private PoisonGasPlayerEffect(Game game) : base(game) { } // This object is a singleton.
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
            Game.MsgPrint("You are hit by poison!");
        }
        if (Game.HasPoisonResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (Game.PoisonResistanceTimer.Value != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (!(Game.PoisonResistanceTimer.Value != 0 || Game.HasPoisonResistance) &&
            Game.DieRoll(Game.HurtChance) == 1)
        {
            Game.TryDecreasingAbilityScore(Game.ConstitutionAbility);
        }
        Game.TakeHit(dam, killer);
        if (!(Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0))
        {
            if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                Game.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                Game.PoisonTimer.AddTimer(Game.RandomLessThan(dam) + 10);
            }
        }
        return true;
    }
}
