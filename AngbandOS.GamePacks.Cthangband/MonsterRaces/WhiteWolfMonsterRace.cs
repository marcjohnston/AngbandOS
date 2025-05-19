// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WhiteWolfMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperCSymbol);
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "A large and muscled wolf from the northern wastes. Its breath is cold and icy and its fur coated in frost.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "White wolf";
    public override bool Friends => true;
    public override int Hdice => 7;
    public override int Hside => 7;
    public override bool ImmuneCold => true;
    public override int LevelFound => 12;
    public override int Mexp => 30;
    public override int NoticeRange => 30;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "White\nwolf";
}
