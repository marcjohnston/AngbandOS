// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AimlessLookingMerchantMonsterRace : MonsterRace
{
    protected AimlessLookingMerchantMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    public override string Name => "Aimless looking merchant";

    public override int ArmorClass => 1;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "The typical ponce around town, with purse jingling, and looking for more amulets of adornment to buy.";
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Aimless looking merchant";
    public override int Hdice => 3;
    public override int Hside => 3;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 255;
    public override int Speed => 110;
    public override string SplitName1 => "  Aimless   ";
    public override string SplitName2 => "  looking   ";
    public override string SplitName3 => "  merchant  ";
    public override bool TakeItem => true;
}
