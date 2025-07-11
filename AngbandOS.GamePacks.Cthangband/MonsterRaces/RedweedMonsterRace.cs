// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RedweedMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlinkMonsterSpell)
    };

    public override string SymbolName => nameof(LowerMSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 3;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 1),
    };
    public override string Description => "A strange fibrous growth springing up everywhere.";
    public override bool EmptyMind => true;
    public override int FreqInate => 20;
    public override int FreqSpell => 20;
    public override string FriendlyName => "Redweed";
    public override bool Friends => true;
    public override int Hdice => 1;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 10;
    public override int Rarity => 4;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string? MultilineName => "Redweed";
    public override bool Stupid => true;
}
