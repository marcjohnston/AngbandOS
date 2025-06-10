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

    public override string? VsPlayerActionMessage => "{0} gazes deep into your eyes.";

    /// <summary>
    /// Returns null, because a blind player will not be aware this action is taking place.
    /// </summary>
    public override string? VsMonsterUnseenMessage => null;

    public override string? VsMonsterSeenMessage => $"{0} gazes intently at {3}";

    public override void ExecuteOnPlayer(Monster monster)
    {
        if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            Game.MsgPrint("Your mind is blasted by psionic energy.");
            if (!Game.HasConfusionResistance)
            {
                Game.ConfusedTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
            }
            if (!Game.HasChaosResistance && base.Game.DieRoll(3) == 1)
            {
                Game.HallucinationsTimer.AddTimer(base.Game.RandomLessThan(250) + 150);
            }

            string monsterDescription = monster.IndefiniteVisibleName;
            Game.TakeHit(base.Game.DiceRoll(8, 8), monsterDescription);
        }
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool seen = !playerIsBlind && monster.IsVisible;
        string monsterName = monster.Name;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneConfusion || targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (targetRace.ImmuneConfusion && seen)
            {
                targetRace.Knowledge.Characteristics.ImmuneConfusion = true;
            }
            if (!blind && target.IsVisible)
            {
                Game.MsgPrint($"{targetName} is unaffected!");
            }
        }
        else
        {
            Game.MsgPrint($"{targetName} is blasted by psionic energy.");
            target.ConfusionLevel += base.Game.RandomLessThan(4) + 4;
            target.TakeDamageFromAnotherMonster(base.Game.DiceRoll(8, 8), out _, " collapses, a mindless husk.");
        }
    }
}