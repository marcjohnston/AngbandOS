// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HippogriffMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override bool Animal => true;
    public override int ArmorClass => 14;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 5),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A strange hybrid of eagle, lion and horse. It looks weird.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hippogriff";
    public override int Hdice => 20;
    public override int Hside => 9;
    public override int LevelFound => 11;
    public override int Mexp => 30;
    public override int NoticeRange => 12;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Hippogriff";
}
