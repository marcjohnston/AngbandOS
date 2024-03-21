// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronYogSothoth : Patron
{
    private PatronYogSothoth(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Yog Sothoth";
    public override string LongName => "Yog Sothoth, the Gate and the Key";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PissOffReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HSummonReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SummonMReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DestructReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SerUndeReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CarnageReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DispelCReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward))
    };
}