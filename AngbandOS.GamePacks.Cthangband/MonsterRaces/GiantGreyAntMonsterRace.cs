// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantGreyAntMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerASymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override bool Animal => true;
    public override int ArmorClass => 40;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "It is an ant encased in shaggy grey fur.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant grey ant";
    public override int Hdice => 19;
    public override int Hside => 8;
    public override bool KillBody => true;
    public override int LevelFound => 26;
    public override int Mexp => 90;
    public override int NoticeRange => 10;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Giant\ngrey\nant";
    public override bool WeirdMind => true;
}
