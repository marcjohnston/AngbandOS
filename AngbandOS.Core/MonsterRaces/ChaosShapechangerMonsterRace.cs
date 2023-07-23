// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChaosShapechangerMonsterRace : MonsterRace
{
    protected ChaosShapechangerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ColdBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBoltMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperHSymbol>();
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Chaos shapechanger";

    public override int ArmourClass => 14;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ConfuseAttackEffect>(), 1, 3),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override string Description => "A vaguely humanoid form constantly changing its appearance.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Chaos shapechanger";
    public override int Hdice => 20;
    public override int Hside => 9;
    public override int LevelFound => 11;
    public override int Mexp => 38;
    public override int NoticeRange => 10;
    public override int Rarity => 2;
    public override bool Shapechanger => true;
    public override int Sleep => 12;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Chaos    ";
    public override string SplitName3 => "shapechanger";
}
