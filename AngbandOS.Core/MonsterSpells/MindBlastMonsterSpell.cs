// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class MindBlastMonsterSpell : MonsterSpell
{
    private MindBlastMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You feel something focusing on your mind.";

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} gazes deep into your eyes.";

    /// <summary>
    /// Returns null, because a blind player will not be aware this action is taking place.
    /// </summary>
    public override string? VsMonsterUnseenMessage => null;

    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} gazes intently at {target.Name}";

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        if (Game.RandomLessThan(100) < game.SkillSavingThrow)
        {
            game.MsgPrint("You resist the effects!");
        }
        else
        {
            game.MsgPrint("Your mind is blasted by psionic energy.");
            if (!game.HasConfusionResistance)
            {
                game.ConfusedTimer.AddTimer(Game.RandomLessThan(4) + 4);
            }
            if (!game.HasChaosResistance && Game.DieRoll(3) == 1)
            {
                game.HallucinationsTimer.AddTimer(Game.RandomLessThan(250) + 150);
            }

            string monsterDescription = monster.IndefiniteVisibleName;
            game.TakeHit(Game.DiceRoll(8, 8), monsterDescription);
        }
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = game.BlindnessTimer.Value != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneConfusion || targetRace.Level > Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (targetRace.ImmuneConfusion && seen)
            {
                targetRace.Knowledge.Characteristics.ImmuneConfusion = true;
            }
            if (!blind && target.IsVisible)
            {
                game.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            game.MsgPrint($"{targetName} is blasted by psionic energy.");
            target.ConfusionLevel += Game.RandomLessThan(4) + 4;
            target.TakeDamageFromAnotherMonster(game, Game.DiceRoll(8, 8), out _, " collapses, a mindless husk.");
        }
    }
}