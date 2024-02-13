// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DreadCurseMonsterSpell : MonsterSpell
{
    private DreadCurseMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsAttack => true;
    public override string? VsPlayerBlindMessage => "You hear someone invoke the Dread Curse of Azathoth!";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} invokes the Dread Curse of Azathoth!";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} invokes the Dread Curse of Azathoth on {target.Name}";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        if (SaveGame.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You resist the effects!");
        }
        else
        {
            int dummy = (65 + SaveGame.DieRoll(25)) * saveGame.Health / 100;
            saveGame.MsgPrint("Your feel your life fade away!");
            saveGame.TakeHit(dummy, monster.Name);
            saveGame.CurseEquipment(100, 20);
            if (saveGame.Health < 1)
            {
                saveGame.Health = 1;
            }
        }
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        string targetName = target.Name;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique)
        {
            if (!blind && seeTarget)
            {
                saveGame.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            if (monster.Race.Level + SaveGame.DieRoll(20) > targetRace.Level + 10 + SaveGame.DieRoll(20))
            {
                target.Health -= (65 + SaveGame.DieRoll(25)) * target.Health / 100;
                if (target.Health < 1)
                {
                    target.Health = 1;
                }
            }
            else
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} resists!");
                }
            }
        }
    }
}
