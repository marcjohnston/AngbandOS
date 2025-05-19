// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarBearMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerQSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override bool Animal => true;
    public override int ArmorClass => 35;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "Bears with tusks, trained to kill.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "War bear";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 10;
    public override int LevelFound => 9;
    public override int Mexp => 25;
    public override int NoticeRange => 10;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "War\nbear";
    public override bool WeirdMind => true;
}
