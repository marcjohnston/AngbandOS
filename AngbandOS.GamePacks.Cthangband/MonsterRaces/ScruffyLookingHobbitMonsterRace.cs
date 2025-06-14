// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScruffyLookingHobbitMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.BrightOrange;
    
    public override int ArmorClass => 8;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatGoldAttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "A short little guy, in bedraggled clothes. He appears to be looking for a good tavern.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Scruffy looking hobbit";
    public override int Hdice => 3;
    public override int Hside => 5;
    public override int LevelFound => 3;
    public override bool Male => true;
    public override int Mexp => 4;
    public override int NoticeRange => 16;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Scruffy\nlooking\nhobbit";
    public override bool TakeItem => true;
}
