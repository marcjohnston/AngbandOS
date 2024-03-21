// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ForgetMonsterSpell : MonsterSpell
{
    private ForgetMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone tries to blank your mind.";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} tries to blank your mind.";
    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        string monsterName = monster.Name;

        if (SaveGame.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You resist the effects!");
        }
        else if (saveGame.LoseAllInfo())
        {
            saveGame.MsgPrint("Your memories fade away.");
        }
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
    }
}
