// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreenIckyThingMonsterRace : MonsterRace
{
    protected GreenIckyThingMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerISymbol));
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Green icky thing";

    public override int ArmourClass => 12;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 2, 5),
    };
    public override string Description => "It is a smallish, slimy, icky, acidic creature.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Green icky thing";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 7;
    public override int Mexp => 18;
    public override int NoticeRange => 14;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "   Green    ";
    public override string SplitName2 => "    icky    ";
    public override string SplitName3 => "   thing    ";
}
