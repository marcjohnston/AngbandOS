// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronAzathoth : Patron
{
    private PatronAzathoth(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Azathoth";
    public override string LongName => "Azathoth, the Daemon Sultan";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(DreadCurseReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DreadCurseReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PissOffReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(RuinAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(LoseAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CarnageReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(DispelCReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(SerMonsReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObsReward))
    };
}