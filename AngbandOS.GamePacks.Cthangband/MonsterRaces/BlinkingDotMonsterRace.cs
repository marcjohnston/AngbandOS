// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlinkingDotMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlinkMonsterSpell)
    };

    public override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 1;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(SporeAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 1, 4),
    };
    public override string Description => "Is it there or is it not?";
    public override bool EmptyMind => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Blinking dot";
    public override int Hdice => 1;
    public override int Hside => 2;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string? MultilineName => "Blinking\ndot";
    public override bool Stupid => true;
}
