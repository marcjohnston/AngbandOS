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
    private ForgetMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone tries to blank your mind.";
    public override string? VsPlayerActionMessage => "{0} tries to blank your mind.";
    public override void ExecuteOnPlayer(Monster monster)
    {
        string monsterName = monster.Name;

        if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else if (Game.LoseAllInfo())
        {
            Game.MsgPrint("Your memories fade away.");
        }
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
    }
}
