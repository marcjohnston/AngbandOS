// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChthonianMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.MindBlastMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell),
        nameof(MonsterSpellsEnum.HasteMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell),
        nameof(MonsterSpellsEnum.DemonSummonMonsterSpell)
    };

    public override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 90;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.ShatterAttackEffect), 3, 11),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.ShatterAttackEffect), 3, 11),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 1, 2),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 1, 2)
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
    public override string? MultilineName => "Chthonian";
}
