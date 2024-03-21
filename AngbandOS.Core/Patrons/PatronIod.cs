// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronIod : Patron
{
    private PatronIod(Game game) : base(game) { }
    public override string ShortName => "Iod";
    public override string LongName => "Iod, the Shining Hunter";
    public override int PreferredAbility => Ability.Charisma;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObsReward))
    };
}