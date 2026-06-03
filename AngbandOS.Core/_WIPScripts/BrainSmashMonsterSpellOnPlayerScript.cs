// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrainSmashMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private BrainSmashMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        string monsterDescription = monster.IndefiniteVisibleName;

        if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            Game.MsgPrint("Your mind is blasted by psionic energy.");
            Game.TakeHit(base.Game.DiceRoll(12, 15), monsterDescription);
            if (!Game.HasBlindnessResistance)
            {
                Game.BlindnessTimer.AddTimer(8 + base.Game.RandomLessThan(8));
            }
            if (!Game.HasConfusionResistance)
            {
                Game.ConfusionTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
            }
            if (!Game.HasFreeAction)
            {
                Game.ParalysisTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
            }
            Game.SlowTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
            while (base.Game.RandomLessThan(100) > Game.SkillSavingThrow)
            {
                Game.TryDecreasingAbilityScore(Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility)));
            }
            while (base.Game.RandomLessThan(100) > Game.SkillSavingThrow)
            {
                Game.TryDecreasingAbilityScore(Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility)));
            }
            if (!Game.HasChaosResistance)
            {
                Game.HallucinationsTimer.AddTimer(base.Game.RandomLessThan(250) + 150);
            }
        }
    }
}
