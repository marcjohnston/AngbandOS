// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronGlaaki : PatronGameConfiguration
{
    public override string ShortName => "Glaaki";
    public override string LongName => "Glaaki, Lord of Dead Dreams";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.SummonMReward),
        nameof(RewardsEnum.SummonMReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.SerUndeReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GoodObsReward)
    };
}