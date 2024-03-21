// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronHastur : Patron
{
    private PatronHastur(Game game) : base(game) { }
    public override string ShortName => "Hastur";
    public override string LongName => "Hastur, the Unspeakable";
    public override int PreferredAbility => -1;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        Game.SingletonRepository.Rewards.Get(nameof(SerDemoReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        Game.SingletonRepository.Rewards.Get(nameof(LoseExpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(LoseAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(DestructReward)),
        Game.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        Game.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        Game.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(RuinAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HSummonReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(AugmAblReward))
    };
}