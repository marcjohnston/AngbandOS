// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronCthulhu : PatronGameConfiguration
{
    public override string ShortName => "Cthulhu";
    public override string LongName => "Cthulhu, who Lies Dreaming";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.LoseAblReward),
        nameof(RewardsEnum.LoseExpReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.SerUndeReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}