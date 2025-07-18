// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class UndeadMassMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 12;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 6),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 1, 6),
    };
    public override bool ColdBlood => true;
    public override string Description => "A sickening mound of decaying flesh, bones, hands and so on. It seems to be growing.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Undead mass";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 10;
    public override int Mexp => 33;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 70;
    public override int Rarity => 2;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Undead\nmass";
    public override bool Undead => true;
}
