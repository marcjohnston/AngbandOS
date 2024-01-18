// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class EtherealDrakeMonsterRace : MonsterRace
{
    protected EtherealDrakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDarkMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheLightMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ConfuseMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SlowMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerDSymbol));
    public override ColourEnum Colour => ColourEnum.BrightGrey;
    public override string Name => "Ethereal drake";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 6),
    };
    public override string Description => "A dragon of elemental power, with control over light and dark, the ethereal drake's eyes glare with white hatred from the shadows.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Ethereal drake";
    public override int Hdice => 45;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 33;
    public override int Mexp => 700;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override int Sleep => 15;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Ethereal  ";
    public override string SplitName3 => "   drake    ";
}
