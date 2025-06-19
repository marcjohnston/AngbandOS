// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronAbhoth : PatronGameConfiguration
{
    public override string ShortName => "Abhoth";
    public override string LongName => "Abhoth, the Unclean";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.SerMonsReward),
        nameof(RewardsEnum.SerDemoReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.GreaObsReward)
    };
}