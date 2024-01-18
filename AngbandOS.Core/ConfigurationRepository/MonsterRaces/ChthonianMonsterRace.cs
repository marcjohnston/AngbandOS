// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChthonianMonsterRace : MonsterRace
{
    protected ChthonianMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BrainSmashMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ConfuseMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HoldMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(MindBlastMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ForgetMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HasteMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HealMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonDemonMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperASymbol));
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "Chthonian";

    public override int ArmourClass => 90;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ShatterAttackEffect)), 3, 11),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ShatterAttackEffect)), 3, 11),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseConAttackEffect)), 1, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseConAttackEffect)), 1, 2)
    };
    public override bool Cthuloid => true;
    public override string Description => "A huge subterranean worm whose body ends in a mass of groping tentacles.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Chthonian";
    public override int Hdice => 100;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool KillWall => true;
    public override int LevelFound => 39;
    public override int Mexp => 2300;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override int Rarity => 2;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Chthonian  ";
}
