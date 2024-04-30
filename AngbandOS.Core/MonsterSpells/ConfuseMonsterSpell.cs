// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ConfuseMonsterSpell : MonsterSpell
{
    private ConfuseMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesConfusion => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone mumbles, and you hear puzzling noises.";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} creates a mesmerising illusion.";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} creates a mesmerising illusion in front of {target.Name}";

    public override void ExecuteOnPlayer(Monster monster)
    {
        if (Game.HasConfusionResistance)
        {
            Game.MsgPrint("You disbelieve the feeble spell.");
        }
        else if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You disbelieve the feeble spell.");
        }
        else
        {
            Game.ConfusedTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ConfSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        string targetName = target.Name;
        MonsterRace targetRace = target.Race;

        if (targetRace.ImmuneConfusion)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} disbelieves the feeble spell.");
            }
        }
        else if (targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} disbelieves the feeble spell.");
            }
        }
        else
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} seems confused.");
            }
            target.ConfusionLevel += 12 + base.Game.RandomLessThan(4);
        }
    }
}
