// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DeathDrakeMonsterRace : MonsterRace
{
    protected DeathDrakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheNetherMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell(),
        new SlowMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperDSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Death drake";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 10),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 10),
        new MonsterAttack(new BiteAttackType(), new Exp80AttackEffect(), 3, 6),
        new MonsterAttack(new BiteAttackType(), new Exp80AttackEffect(), 3, 6)
    };
    public override string Description => "It is a dragon-like form wrapped in darkness. You cannot make out its true form but you sense its evil.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Death drake";
    public override int Hdice => 10;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 40;
    public override int Mexp => 3500;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool ResistNether => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Death    ";
    public override string SplitName3 => "   drake    ";
    public override bool TakeItem => true;
}
