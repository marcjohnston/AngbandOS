// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantWhiteDragonFlyMonsterRace : MonsterRace
{
    protected GiantWhiteDragonFlyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheColdMonsterSpell());
    public override char Character => 'F';
    public override string Name => "Giant white dragon fly";

    public override bool Animal => true;
    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new ColdAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a large fly that drips frost.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Giant white dragon fly";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override int LevelFound => 14;
    public override int Mexp => 60;
    public override int NoticeRange => 20;
    public override bool RandomMove50 => true;
    public override int Rarity => 3;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "Giant white ";
    public override string SplitName2 => "   dragon   ";
    public override string SplitName3 => "    fly     ";
    public override bool WeirdMind => true;
}
