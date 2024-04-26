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
    private DreadCurseMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;
    public override string? VsPlayerBlindMessage => "You hear someone invoke the Dread Curse of Azathoth!";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} invokes the Dread Curse of Azathoth!";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} invokes the Dread Curse of Azathoth on {target.Name}";

    public override void ExecuteOnPlayer(Monster monster)
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

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique)
        {
            if (!blind && seeTarget)
            {
                Game.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            if (monster.Race.Level + base.Game.DieRoll(20) > targetRace.Level + 10 + base.Game.DieRoll(20))
            {
                target.Health -= (65 + base.Game.DieRoll(25)) * target.Health / 100;
                if (target.Health < 1)
                {
                    target.Health = 1;
                }
            }
            else
            {
                if (seeTarget)
                {
                    Game.MsgPrint($"{targetName} resists!");
                }
            }
        }
    }
}
