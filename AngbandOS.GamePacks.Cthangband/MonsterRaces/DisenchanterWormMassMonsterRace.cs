// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchanterWormMassMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerWSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override bool Animal => true;
    public override int ArmorClass => 5;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrawlAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 1, 4),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "It is a strange mass of squirming worms. Magical energy crackles around its disgusting form.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Disenchanter worm mass";
    public override int Hdice => 10;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 40;
    public override int Mexp => 30;
    public override bool Multiply => true;
    public override int NoticeRange => 7;
    public override bool RandomMove50 => true;
    public override int Rarity => 3;
    public override bool ResistDisenchant => true;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string? MultilineName => "Disenchanter\nworm\nmass";
    public override bool Stupid => true;
    public override bool WeirdMind => true;
}
