// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FangFarmerMaggotsDogMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperCSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A rather vicious dog belonging to Farmer Maggot. It thinks you are stealing mushrooms.";
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Fang, Farmer Maggot's dog";
    public override int Hdice => 5;
    public override int Hside => 5;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 2;
    public override int Mexp => 30;
    public override int NoticeRange => 30;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Fang";
    public override bool Unique => true;
}
