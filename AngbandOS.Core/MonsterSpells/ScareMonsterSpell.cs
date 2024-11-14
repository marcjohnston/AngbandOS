// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ScareMonsterSpell : MonsterSpell
{
    private ScareMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesFear => true;
    public override bool IsAttack => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone mumbles, and you hear scary noises.";

    public override string? VsPlayerActionMessage => "{0} casts a fearful illusion.";

    public override string? VsMonsterSeenMessage => "{0} casts a fearful illusion at {3}";

    public override void ExecuteOnPlayer(Monster monster)
    {
        if (Game.HasFearResistance)
        {
            Game.MsgPrint("You refuse to be frightened.");
        }
        else if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You refuse to be frightened.");
        }
        else
        {
            Game.FearTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.Get<SpellResistantDetection>(nameof(FearSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        MonsterRace targetRace = target.Race;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !playerIsBlind && target.IsVisible;
        string targetName = target.Name;
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;

        if (targetRace.ImmuneFear)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} refuses to be frightened.");
            }
        }
        else if (targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} refuses to be frightened.");
            }
        }
        else
        {
            if (target.FearLevel == 0 && seeTarget)
            {
                Game.MsgPrint($"{targetName} flees in terror!");
            }
            target.FearLevel += base.Game.RandomLessThan(4) + 4;
        }

        // Most spells will wake up the target if it's asleep
        target.SleepLevel = 0;
    }
}
