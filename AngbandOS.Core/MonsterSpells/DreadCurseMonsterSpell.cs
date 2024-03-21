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

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        if (Game.RandomLessThan(100) < game.SkillSavingThrow)
        {
            game.MsgPrint("You resist the effects!");
        }
        else
        {
            int dummy = (65 + Game.DieRoll(25)) * game.Health.Value / 100;
            game.MsgPrint("Your feel your life fade away!");
            game.TakeHit(dummy, monster.Name);
            game.CurseEquipment(100, 20);
            if (game.Health.Value < 1)
            {
                game.Health.Value = 1;
            }
        }
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique)
        {
            if (!blind && seeTarget)
            {
                game.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            if (monster.Race.Level + Game.DieRoll(20) > targetRace.Level + 10 + Game.DieRoll(20))
            {
                target.Health -= (65 + Game.DieRoll(25)) * target.Health / 100;
                if (target.Health < 1)
                {
                    target.Health = 1;
                }
            }
            else
            {
                if (seeTarget)
                {
                    game.MsgPrint($"{targetName} resists!");
                }
            }
        }
    }
}
