// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronYig : Patron
{
    private PatronYig(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Yig";
    public override string LongName => "Yig, Father of Serpents";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(RuinAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SerUndeReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DestructReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CarnageReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward))
    };
}