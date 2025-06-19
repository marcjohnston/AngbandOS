// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronTsathoggua : PatronGameConfiguration
{
    public override string ShortName => "Tsathoggua";
    public override string LongName => "Tsathoggua, the Sleeper of N'Kai";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.LoseExpReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.MassGenReward),
        nameof(RewardsEnum.SerDemoReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}