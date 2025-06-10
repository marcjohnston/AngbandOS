// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantTarantulaMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override bool Animal => true;
    public override int ArmorClass => 32;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A giant spider with hairy black and red legs.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant tarantula";
    public override int Hdice => 10;
    public override int Hside => 15;
    public override bool ImmunePoison => true;
    public override int LevelFound => 15;
    public override int Mexp => 70;
    public override int NoticeRange => 8;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string? MultilineName => "Giant\ntarantula";
    public override bool WeirdMind => true;
}
