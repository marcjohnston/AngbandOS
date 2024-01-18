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
    private PatronIod(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Iod";
    public override string LongName => "Iod, the Shining Hunter";
    public override int PreferredAbility => Ability.Charisma;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GreaObsReward))
    };
}