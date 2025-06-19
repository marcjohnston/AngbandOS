// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronYig : PatronGameConfiguration
{
    public override string ShortName => "Yig";
    public override string LongName => "Yig, Father of Serpents";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.SerUndeReward),
        nameof(RewardsEnum.DestructReward),
        nameof(RewardsEnum.CarnageReward),
        nameof(RewardsEnum.MassGenReward),
        nameof(RewardsEnum.MassGenReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.AugmAblReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}