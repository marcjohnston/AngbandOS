// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronCyaegha : Patron
{
    private PatronCyaegha(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Cyaegha";
    public override string LongName => "Cyaegha, the Destroying Eye";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PissOffReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(LoseAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(LoseExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DispelCReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DoHavocReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DoHavocReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SerMonsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward))
    };
}