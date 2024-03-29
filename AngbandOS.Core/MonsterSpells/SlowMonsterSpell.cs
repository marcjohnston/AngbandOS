// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SlowMonsterSpell : MonsterSpell
{
    private SlowMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool RestrictsFreeAction => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone drains power from your muscles!";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} drains power from your muscles!";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target)
    {
        string monsterName = target.Name;
        string targetName = target.Name;
        string it = (targetName == "it" ? "s" : "'s");
        return $"{monsterName} drains power from {targetName}{it} muscles.";
    }

    public override void ExecuteOnPlayer(Monster monster)
    {
        string monsterName = monster.Name;

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
            Game.SlowTimer.AddTimer(base.Game.RandomLessThan(4) + 4);
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.SpellResistantDetections.Get(nameof(SpellResistantDetections.FreeSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;
        string targetName = target.Name;

        if (targetRace.Unique)
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
            target.Speed -= 10;
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} starts moving slower.");
            }
        }
    }
}
