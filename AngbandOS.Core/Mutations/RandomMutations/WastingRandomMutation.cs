// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class WastingRandomMutation : Mutation
{
    private WastingRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You suddenly contract a horrible wasting disease.";
    public override string HaveMessage => "You have a horrible wasting disease.";
    public override string LoseMessage => "You are cured of the horrible wasting disease!";

    public override void ProcessWorld()
    {
        if (Game.DieRoll(3000) != 13)
        {
            return;
        }
        WeightedRandom<Ability> abilitiesWeightedRandom = Game.SingletonRepository.ToWeightedRandom<Ability>();
        Ability whichStat = abilitiesWeightedRandom.Choose();
        bool sustained = whichStat.HasSustain;
        if (sustained)
        {
            return;
        }
        Game.Disturb(false);
        if (base.Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(LobonGod)).AdjustedFavour)
        {
            Game.MsgPrint("Lobon's favour protects you from wasting away!");
            Game.MsgPrint(string.Empty);
            return;
        }
        Game.MsgPrint("You can feel yourself wasting away!");
        Game.MsgPrint(string.Empty);
        Game.DecreaseAbilityScore(whichStat, base.Game.DieRoll(6) + 6, base.Game.DieRoll(3) == 1);
    }
}