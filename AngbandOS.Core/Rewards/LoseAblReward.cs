// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class LoseAblReward : Reward
{
    private LoseAblReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} booms out:");
        Game.MsgPrint("'I grow tired of thee, mortal.'");
        if (Game.DieRoll(3) == 1 && patron.PreferredAbility is not null)
        {
            Game.TryDecreasingAbilityScore(patron.PreferredAbility);
        }
        else
        {
            WeightedRandom<Ability> abilitiesWeightedRandom = Game.SingletonRepository.ToWeightedRandom<Ability>();
            Ability ability = abilitiesWeightedRandom.Choose();
            Game.TryDecreasingAbilityScore(ability);
        }
    }
}