// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantFruitFlyMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperISymbol);
    public override ColorEnum Color => ColorEnum.BrightOrange;
    
    public override bool Animal => true;
    public override int ArmorClass => 14;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 2),
    };
    public override string Description => "A fast-breeding, annoying pest.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant fruit fly";
    public override int Hdice => 2;
    public override int Hside => 2;
    public override int LevelFound => 10;
    public override int Mexp => 4;
    public override bool Multiply => true;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 6;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Giant\nfruit\nfly";
    public override bool WeirdMind => true;
}
