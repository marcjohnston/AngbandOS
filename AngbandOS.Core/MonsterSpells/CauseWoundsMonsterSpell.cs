// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal abstract class CauseWoundsMonsterSpell : MonsterSpell
{
    protected CauseWoundsMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You hear someone mumble.";

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} points at you and curses.";

    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name} and curses.";

    /// <summary>
    /// Returns the amount of damage inflicted.
    /// </summary>
    protected abstract int Damage { get; }

    /// <summary>
    /// Returns the chance that an item of equipment that the player is wearing will be cursed.
    /// </summary>
    protected abstract int CurseEquipmentChance { get; }

    /// <summary>
    /// Returns the chance that an item of equipment that the player is wearing will be heavily cursed.
    /// </summary>
    protected abstract int HeavyCurseEquipmentChance { get; }

    /// <summary>
    /// Returns an additional amount of time the player will bleed.  Returns 0, by default.
    /// </summary>
    protected virtual int TimedBleeding => 0;
    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        if (Game.RandomLessThan(100) < game.SkillSavingThrow)
        {
            game.MsgPrint("You resist the effects!");
        }
        else
        {
            string monsterDescription = monster.IndefiniteVisibleName;

            game.CurseEquipment(CurseEquipmentChance, HeavyCurseEquipmentChance);
            game.TakeHit(Damage, monsterDescription);

            if (TimedBleeding > 0)
            {
                game.BleedingTimer.AddTimer(TimedBleeding);
            }
        }
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.Level > Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                game.MsgPrint($"{targetName} resists!");
            }
        }
        else
        {
            target.TakeDamageFromAnotherMonster(game, Damage, out _, " is destroyed.");
        }
    }
}
