// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WhiteJellyMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override int ArmorClass => 1;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 2),
    };
    public override string Description => "Its a large pile of white flesh.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "White jelly";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 2;
    public override int Mexp => 10;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 99;
    public override int Speed => 120;
    public override string? MultilineName => "White\njelly";
    public override bool Stupid => true;
}
