// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FasoltTheGiantMonsterRace : MonsterRace
{
    protected FasoltTheGiantMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperPSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Fasolt the Giant";

    public override int ArmorClass => 70;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 2, 10),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(EatGoldAttackEffect), 2, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "Big, brawny, powerful and with a greed for gold.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Fasolt the Giant";
    public override bool Giant => true;
    public override int Hdice => 11;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 33;
    public override bool Male => true;
    public override int Mexp => 2000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 7;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "   Fasolt   ";
    public override string SplitName2 => "    the     ";
    public override string SplitName3 => "   Giant    ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
