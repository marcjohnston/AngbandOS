// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DriderMonsterRace : MonsterRace
{
    protected DriderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<Arrow3D6MonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseLightWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<MagicMissileMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DarknessMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperSSymbol>();
    public override ColourEnum Colour => ColourEnum.Blue;
    public override string Name => "Drider";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A dark elven torso merged with the bloated form of a giant spider.";
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Drider";
    public override int Hdice => 10;
    public override int Hside => 13;
    public override bool ImmunePoison => true;
    public override int LevelFound => 13;
    public override int Mexp => 55;
    public override int NoticeRange => 8;
    public override int Rarity => 2;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Drider   ";
}
