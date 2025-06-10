// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantWhiteDragonFlyMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ColdBreatheBallMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperFSymbol);
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.ColdAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a large fly that drips frost.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Giant white dragon fly";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override int LevelFound => 14;
    public override int Mexp => 60;
    public override int NoticeRange => 20;
    public override bool RandomMove50 => true;
    public override int Rarity => 3;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Giant white\ndragon\nfly";
    public override bool WeirdMind => true;
}
