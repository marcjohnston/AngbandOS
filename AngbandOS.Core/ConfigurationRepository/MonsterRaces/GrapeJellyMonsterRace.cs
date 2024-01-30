// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GrapeJellyMonsterRace : MonsterRace
{
    protected GrapeJellyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(DrainManaMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerJSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Grape jelly";

    public override int ArmorClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp10AttackEffect)), 0, 0),
    };
    public override string Description => "It is a pulsing mound of glowing flesh.";
    public override bool EmptyMind => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Grape jelly";
    public override int Hdice => 52;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 12;
    public override int Mexp => 60;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 3;
    public override int Sleep => 99;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Grape    ";
    public override string SplitName3 => "   jelly    ";
    public override bool Stupid => true;
}
