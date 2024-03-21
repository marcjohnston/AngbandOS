// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BlindnessMonsterSpell : MonsterSpell
{
    private BlindnessMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesBlindness => true;
    public override bool Annoys => true;

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} casts a spell, burning your eyes!";

    public override string? VsMonsterSeenMessage(Monster monster, Monster target)
    {
        string targetName = target.Name;
        string it = targetName != "it" ? "s" : "'s";
        return $"{monster.Name} casts a spell, burning {targetName}{it} eyes.";
    }

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {

        if (game.HasBlindnessResistance)
        {
            game.MsgPrint("You are unaffected!");
        }
        else if (Game.RandomLessThan(100) < game.SkillSavingThrow)
        {
            game.MsgPrint("You resist the effects!");
        }
        else
        {
            game.BlindnessTimer.SetTimer(12 + Game.RandomLessThan(4));
        }
        game.UpdateSmartLearn(monster, Game.SingletonRepository.SpellResistantDetections.Get(nameof(BlindSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.ImmuneConfusion)
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
            if (seeTarget)
            {
                game.MsgPrint($"{targetName} is blinded!");
            }
            target.ConfusionLevel += 12 + Game.RandomLessThan(4);
        }
    }
}
