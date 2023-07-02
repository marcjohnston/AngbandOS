// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShuddeMellMonsterRace : MonsterRace
{
    protected ShuddeMellMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BrainSmashMonsterSpell(),
        new ConfuseMonsterSpell(),
        new HoldMonsterSpell(),
        new MindBlastMonsterSpell(),
        new ScareMonsterSpell(),
        new ForgetMonsterSpell(),
        new HasteMonsterSpell(),
        new HealMonsterSpell(),
        new SummonCthuloidMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override Colour Colour => Colour.Brown;
    public override string Name => "Shudde M'ell";

    public override int ArmourClass => 90;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrushAttackType(), new ShatterAttackEffect(), 3, 11),
        new MonsterAttack(new CrushAttackType(), new ShatterAttackEffect(), 3, 11),
        new MonsterAttack(new TouchAttackType(), new LoseConAttackEffect(), 1, 2),
        new MonsterAttack(new TouchAttackType(), new LoseConAttackEffect(), 1, 2)
    };
    public override bool Cthuloid => true;
    public override string Description => "The largest of the cthonians and leader of his kind.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Shudde M'ell";
    public override int Hdice => 100;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool KillWall => true;
    public override int LevelFound => 56;
    public override int Mexp => 2300;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override int Rarity => 2;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Shudde   ";
    public override string SplitName3 => "   M'ell    ";
    public override bool Unique => true;
}
