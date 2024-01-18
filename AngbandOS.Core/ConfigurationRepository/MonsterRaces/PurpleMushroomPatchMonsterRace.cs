// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PurpleMushroomPatchMonsterRace : MonsterRace
{
    protected PurpleMushroomPatchMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Purple mushroom patch";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<SporeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseConAttackEffect>(), 1, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<SporeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseConAttackEffect>(), 1, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<SporeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseConAttackEffect>(), 1, 2),
    };
    public override string Description => "Yum! It looks quite tasty.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Purple mushroom patch";
    public override int Hdice => 1;
    public override int Hside => 1;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 6;
    public override int Mexp => 15;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "   Purple   ";
    public override string SplitName2 => "  mushroom  ";
    public override string SplitName3 => "   patch    ";
    public override bool Stupid => true;
}
