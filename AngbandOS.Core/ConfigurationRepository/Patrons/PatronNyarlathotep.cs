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
    private PatronNyarlathotep(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Nyarlathotep";
    public override string LongName => "Nyarlathotep, the Crawling Chaos";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(DreadCurseReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(RuinAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SummonMReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(LoseExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SerUndeReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GreaObsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward))
    };
}