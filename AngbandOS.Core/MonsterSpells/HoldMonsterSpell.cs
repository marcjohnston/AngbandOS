// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class HoldMonsterSpell : MonsterSpell
{
    private HoldMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool RestrictsFreeAction => true;
    public override bool Annoys => true;

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} stares deep into your eyes!";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} stares intently at {target.Name}";

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        if (game.HasFreeAction)
        {
            game.MsgPrint("You are unaffected!");
        }
        else if (Game.RandomLessThan(100) < game.SkillSavingThrow)
        {
            game.MsgPrint("You resist the effects!");
        }
        else
        {
            game.ParalysisTimer.AddTimer(Game.RandomLessThan(4) + 4);
        }
        game.UpdateSmartLearn(monster, Game.SingletonRepository.SpellResistantDetections.Get(nameof(FreeSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneStun)
        {
            if (seeTarget)
            {
                game.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else if (targetRace.Level > Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                game.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else
        {
            target.StunLevel += Game.DieRoll(4) + 4;
            if (seeTarget)
            {
                game.MsgPrint($"{targetName} is paralyzed!");
            }
        }
    }
}
