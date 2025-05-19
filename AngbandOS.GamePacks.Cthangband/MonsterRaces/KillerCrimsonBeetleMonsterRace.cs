// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KillerCrimsonBeetleMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperKSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override bool Animal => true;
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 4, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A giant beetle with poisonous mandibles.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer crimson beetle";
    public override int Hdice => 20;
    public override int Hside => 8;
    public override int LevelFound => 25;
    public override int Mexp => 85;
    public override int NoticeRange => 14;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Killer\ncrimson\nbeetle";
    public override bool WeirdMind => true;
}
