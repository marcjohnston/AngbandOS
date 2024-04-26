// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class GrowMoldActiveMutation : Mutation
{
    private GrowMoldActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(1, 6, Ability.Constitution, 14))
        {
            return;
        }
        for (int i = 0; i < 8; i++)
        {
            Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre1MonsterFilter)), false);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 1 ? "grow mold        (unusable until level 1)" : "grow mold        (cost 6, CON based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "You feel a sudden affinity for mold.";
    public override string HaveMessage => "You can cause mold to grow near you.";
    public override string LoseMessage => "You feel a sudden dislike for mold.";
}