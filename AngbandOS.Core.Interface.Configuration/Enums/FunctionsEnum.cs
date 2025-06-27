// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

public enum FunctionsEnum
{
    CanStudyBoolFunction,
    ExperienceLevelAtMaxBoolFunction,
    ExperienceLevelsLostBoolFunction,
    ExperiencePointsLostBoolFunction,
    HasBlindnessResistanceBoolFunction,
    HasFreeActionBoolFunction,
    HasConfusionResistanceBoolFunction,
    PlayerIsHallucinatingBoolFunction,
    PlayerIsTrackingMonsterBoolFunction,
    TrackedMonsterIsAfraidBoolFunction,
    TrackedMonsterIsDeadBoolFunction,
    TrackedMonsterIsFriendlyBoolFunction,
    TrackedMonsterIsInvisibleBoolFunction,
    TrackedMonsterIsSleepingBoolFunction,
    TrapsDetectedBoolFunction,
    UsesManaBoolFunction,

    RefreshMapFunction,

    ArmorClassIntFunction,
    ExperiencePointsForNextLevelIntFunction,
    TrackedMonsterHealthIntFunction,
    TrackedMonsterMaxHealthIntFunction,
    TrapCountIntFunction,

    CharacterSubclassNameStringFunction,
    DepthStringFunction,
    RaceTitleStringFunction,

    TrackedMonsterRaceNameTextFunction,
}