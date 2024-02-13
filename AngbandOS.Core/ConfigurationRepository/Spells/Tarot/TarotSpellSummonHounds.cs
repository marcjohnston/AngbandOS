// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellSummonHounds : Spell
{
    private TarotSpellSummonHounds(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.MsgPrint("You concentrate on the image of a hound...");
        if (SaveGame.DieRoll(5) > 2)
        {
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HoundMonsterFilter)), true))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HoundMonsterFilter))))
        {
            SaveGame.MsgPrint("The summoned hounds get angry!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    public override string Name => "Summon Hounds";

    protected override string LearnedDetails => "control 60%";
}