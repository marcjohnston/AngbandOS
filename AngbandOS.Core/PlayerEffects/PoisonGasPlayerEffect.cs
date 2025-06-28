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
    public override string? BlindPreMessage => "You are hit by poison!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int dam)
    {
        string killer = mPtr.IndefiniteVisibleName;
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
        return IdentifiedResultEnum.True;
    }
}
