// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class QuiverSlotMonsterRace : MonsterRace
{
    protected QuiverSlotMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<Arrow1D6MonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Quiver slot";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new SporeAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<ConfuseAttackEffect>(), 1, 1),
    };
    public override bool ColdBlood => true;
    public override string Description => "An arrow hole in the floor, covered in fungal tendrils.";
    public override bool EmptyMind => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Quiver slot";
    public override int Hdice => 1;
    public override int Hside => 1;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 10;
    public override int Mexp => 3;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 4;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Quiver   ";
    public override string SplitName3 => "    slot    ";
    public override bool Stupid => true;
}
