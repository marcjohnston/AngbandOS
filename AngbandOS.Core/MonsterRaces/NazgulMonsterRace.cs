// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NazgulMonsterRace : MonsterRace
{
    protected NazgulMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheNetherMonsterSpell(),
        new DrainManaMonsterSpell(),
        new HoldMonsterSpell(),
        new ScareMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperWSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Nazgul";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new TerrifyAttackEffect(), 6, 6),
        new MonsterAttack(new HitAttackType(), new TerrifyAttackEffect(), 6, 6),
        new MonsterAttack(new HitAttackType(), new Exp80AttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new Exp80AttackEffect(), 4, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A tall black cloaked Ringwraith, radiating an aura of fear.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Nazgul";
    public override int Hdice => 50;
    public override int Hside => 40;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 45;
    public override bool Male => true;
    public override int Mexp => 9500;
    public override bool MoveBody => true;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistNether => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Nazgul   ";
    public override bool Undead => true;
}
