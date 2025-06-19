// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronRhanTegoth : PatronGameConfiguration
{
    public override string ShortName => "Rhan-Tegoth";
    public override string LongName => "Rhan-Tegoth, He of the Ivory Throne";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.DreadCurseReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.SerDemoReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.DoHavocReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.GreaObsReward)
    };
}