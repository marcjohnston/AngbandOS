// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon an elemental, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
internal class SummonElementalActivation : Activation
{
    private SummonElementalActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override bool Activate()
    {
        if (SaveGame.DieRoll(3) == 1)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, (int)(SaveGame.ExperienceLevel * 1.5), SaveGame.SingletonRepository.MonsterFilters.Get(nameof(ElementalMonsterFilter))))
            {
                SaveGame.MsgPrint("An elemental materializes...");
                SaveGame.MsgPrint("You fail to control it!");
            }
        }
        else
        {
            if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, (int)(SaveGame.ExperienceLevel * 1.5), SaveGame.SingletonRepository.MonsterFilters.Get(nameof(ElementalMonsterFilter)), SaveGame.ExperienceLevel == 50))
            {
                SaveGame.MsgPrint("An elemental materializes...");
                SaveGame.MsgPrint("It seems obedient to you.");
            }
        }
        return true;
    }

    public override int RechargeTime() => 750;

    public override int Value => 15000;

    public override string Description => "summon elemental every 750 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
}
