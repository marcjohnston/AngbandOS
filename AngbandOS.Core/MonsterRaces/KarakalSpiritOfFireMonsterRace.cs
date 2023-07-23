// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KarakalSpiritOfFireMonsterRace : MonsterRace
{
    protected KarakalSpiritOfFireMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<PlasmaBoltMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperESymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Karakal, Spirit of Fire";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 6, 6),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 6, 6),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 6, 6),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 6, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A towering fire elemental, Karakal burns everything beyond recognition.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Karakal, Spirit of Fire";
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 38;
    public override bool Male => true;
    public override int Mexp => 3000;
    public override int NoticeRange => 12;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Karakal   ";
    public override bool Unique => true;
}
