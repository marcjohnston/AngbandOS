// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MemoryMossMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ForgetMonsterSpell)
    };

    public override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 1;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 1, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 1, 4),
    };
    public override string Description => "A mass of green vegetation. You don't remember seeing anything like it before.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Memory moss";
    public override int Hdice => 1;
    public override int Hside => 2;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override int Mexp => 150;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Memory\nmoss";
    public override bool Stupid => true;
}
