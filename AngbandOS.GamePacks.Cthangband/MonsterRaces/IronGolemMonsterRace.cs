// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronGolemMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.SlowMonsterSpell)
    };

    public override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 12),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a massive metal statue that moves steadily towards you.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Iron golem";
    public override int Hdice => 80;
    public override int Hside => 12;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 22;
    public override int Mexp => 160;
    public override bool Nonliving => true;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Iron\ngolem";
}
