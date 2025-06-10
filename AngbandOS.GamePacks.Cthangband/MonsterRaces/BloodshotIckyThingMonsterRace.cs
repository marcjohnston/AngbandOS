// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BloodshotIckyThingMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell)
    };

    public override string SymbolName => nameof(LowerISymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 18;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(CrawlAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 2, 4),
    };
    public override string Description => "It is a strange, slimy, icky creature.";
    public override bool EmptyMind => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Bloodshot icky thing";
    public override int Hdice => 7;
    public override int Hside => 8;
    public override bool ImmunePoison => true;
    public override int LevelFound => 9;
    public override int Mexp => 24;
    public override int NoticeRange => 14;
    public override bool RandomMove50 => true;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Bloodshot\nicky\nthing";
}
