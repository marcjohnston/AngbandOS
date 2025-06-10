// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CaveSpiderMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override bool Animal => true;
    public override int ArmorClass => 16;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a black spider that moves in fits and starts.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cave spider";
    public override bool Friends => true;
    public override int Hdice => 2;
    public override int Hside => 6;
    public override bool HurtByLight => true;
    public override int LevelFound => 2;
    public override int Mexp => 7;
    public override int NoticeRange => 8;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string? MultilineName => "Cave\nspider";
    public override bool WeirdMind => true;
}
