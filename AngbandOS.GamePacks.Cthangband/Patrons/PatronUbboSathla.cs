// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronUbboSathla : PatronGameConfiguration
{
    public override string ShortName => "Ubbo-Sathla";
    public override string LongName => "Ubbo-Sathla, the Unbegotten Source";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.LoseAblReward),
        nameof(RewardsEnum.LoseExpReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.SerDemoReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}