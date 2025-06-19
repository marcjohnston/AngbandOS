// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronEihort : PatronGameConfiguration
{
    public override string ShortName => "Eihort";
    public override string LongName => "Eihort, God of the Labyrinth";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.LoseAblReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.AugmAblReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}