// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TimeElementalMonsterRace : MonsterRace
{
    protected TimeElementalMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheTimeMonsterSpell(),
        new SlowMonsterSpell());
    public override char Character => 'E';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Time elemental";

    public override int ArmourClass => 70;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new LoseAllAttackEffect(), 3, 4),
        new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 3, 4),
        new MonsterAttack(new TouchAttackType(), new LoseAllAttackEffect(), 3, 4),
        new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 3, 4)
    };
    public override string Description => "You have not seen it yet.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Time elemental";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillItem => true;
    public override int LevelFound => 37;
    public override int Mexp => 1000;
    public override bool Nonliving => true;
    public override int NoticeRange => 90;
    public override bool PassWall => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Time    ";
    public override string SplitName3 => " elemental  ";
}
