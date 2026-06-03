// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DreadCurseMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private DreadCurseMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            int dummy = (65 + base.Game.DieRoll(25)) * Game.Health.IntValue / 100;
            Game.MsgPrint("Your feel your life fade away!");
            Game.TakeHit(dummy, monster.Name);
            Game.CurseEquipment(100, 20);
            if (Game.Health.IntValue < 1)
            {
                Game.Health.IntValue = 1;
            }
        }
    }
}
