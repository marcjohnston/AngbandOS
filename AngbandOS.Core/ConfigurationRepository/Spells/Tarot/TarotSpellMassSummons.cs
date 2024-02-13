// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellMassSummons : Spell
{
    private TarotSpellMassSummons(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        bool noneCame = true;
        SaveGame.MsgPrint("You concentrate on several images at once...");
        for (int dummy = 0; dummy < 3 + (SaveGame.ExperienceLevel / 10); dummy++)
        {
            if (SaveGame.DieRoll(10) > 3)
            {
                if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(NoUniquesMonsterFilter)), false))
                {
                    noneCame = false;
                }
            }
            else if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, null))
            {
                SaveGame.MsgPrint("A summoned creature gets angry!");
                noneCame = false;
            }
        }
        if (noneCame)
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    public override string Name => "Mass Summons";

    protected override string LearnedDetails => "control 70%";
}