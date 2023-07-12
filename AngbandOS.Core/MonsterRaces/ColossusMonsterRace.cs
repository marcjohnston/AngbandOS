// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ColossusMonsterRace : MonsterRace
{
    protected ColossusMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new Arrow7D6MonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerGSymbol>();
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "Colossus";

    public override int ArmourClass => 150;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 10, 10),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 10, 10),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "An enormous construct resembling a titan made from stone. It strides purposefully towards you, swinging its slow fists with earth-shattering power.";
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Colossus";
    public override int Hdice => 30;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 900;
    public override bool Nonliving => true;
    public override int NoticeRange => 15;
    public override int Rarity => 4;
    public override bool Reflecting => true;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Colossus  ";
}
