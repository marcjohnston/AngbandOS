// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronNyarlathotep : Patron
{
    private PatronNyarlathotep(Game game) : base(game) { }
    public override string ShortName => "Nyarlathotep";
    public override string LongName => "Nyarlathotep, the Crawling Chaos";
    public override Ability? PreferredAbility => Game.StrengthAbility;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Get<Reward>(nameof(DreadCurseReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HurtLotReward)),
        Game.SingletonRepository.Get<Reward>(nameof(CurseWpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(CurseArReward)),
        Game.SingletonRepository.Get<Reward>(nameof(RuinAblReward)),
        Game.SingletonRepository.Get<Reward>(nameof(SummonMReward)),
        Game.SingletonRepository.Get<Reward>(nameof(LoseExpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolySlfReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolySlfReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolyWndReward)),
        Game.SingletonRepository.Get<Reward>(nameof(SerUndeReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HealFulReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HealFulReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GainExpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GainExpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(ChaosWpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GoodObjReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GoodObsReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GreaObsReward)),
        Game.SingletonRepository.Get<Reward>(nameof(AugmAblReward))
    };
}