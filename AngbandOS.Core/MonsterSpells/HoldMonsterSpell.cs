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

    public override string? VsPlayerActionMessage => "{0} stares deep into your eyes!";
    public override string? VsMonsterSeenMessage => "{0} stares intently at {3}";

    public override void ExecuteOnPlayer(Monster monster)
    {
        if (Game.HasFreeAction)
        {
            Game.MsgPrint("You are unaffected!");
        }
        else if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            Game.ParalysisTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.Get<SpellResistantDetection>(nameof(FreeSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Unique || targetRace.ImmuneStun)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else if (targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else
        {
            target.StunLevel += base.Game.DieRoll(4) + 4;
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is paralyzed!");
            }
        }
    }
}
