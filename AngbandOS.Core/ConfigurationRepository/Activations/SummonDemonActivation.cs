// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon a demon, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
internal class SummonDemonActivation : Activation
{
    private SummonDemonActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 5;

    public override bool Activate()
    {
        if (SaveGame.DieRoll(3) == 1)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, (int)(SaveGame.ExperienceLevel * 1.5), SaveGame.SingletonRepository.MonsterFilters.Get(nameof(DemonMonsterFilter))))
            {
                SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                SaveGame.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
            }
        }
        else
        {
            if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, (int)(SaveGame.ExperienceLevel * 1.5), SaveGame.SingletonRepository.MonsterFilters.Get(nameof(DemonMonsterFilter)), SaveGame.ExperienceLevel == 50))
            {
                SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                SaveGame.MsgPrint("'What is thy bidding... Master?'");
            }
        }
        return true;
    }

    public override int RechargeTime() => 666 + SaveGame.DieRoll(333);

    public override int Value => 20000;

    public override string Description => "summon demon every 666+d333 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
}
