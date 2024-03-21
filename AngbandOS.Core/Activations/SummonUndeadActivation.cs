// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon undead, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
internal class SummonUndeadActivation : Activation
{
    private SummonUndeadActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 5;

    protected override bool OnActivate(Item item)
    {
        if (SaveGame.DieRoll(3) == 1)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, (int)(SaveGame.ExperienceLevel.Value * 1.5), SaveGame.ExperienceLevel.Value > 47 ? SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadMonsterFilter)) : SaveGame.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter))))
            {
                SaveGame.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                SaveGame.MsgPrint("'The dead arise... to punish you for disturbing them!'");
            }
        }
        else
        {
            if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, (int)(SaveGame.ExperienceLevel.Value * 1.5), SaveGame.ExperienceLevel.Value > 47 ? SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadNoUniquesMonsterFilter)) : SaveGame.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter)), SaveGame.ExperienceLevel.Value > 24 && SaveGame.DieRoll(3) == 1))
            {
                SaveGame.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                SaveGame.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
            }
        }
        return true;
    }

    public override int RechargeTime() => 666 + SaveGame.DieRoll(333);

    public override int Value => 20000;

    public override string Name => "Summon undead";

    public override string Frequency => "666+d333";
}
