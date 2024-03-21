// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class EogGolemMonsterRace : MonsterRace
{
    protected EogGolemMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string Name => "Eog golem";

    public override int ArmorClass => 125;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 8, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 8, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a massive deep brown statue, striding towards you with an all-too-familiar purpose. Your magic surprisingly feels much less powerful now.";
    public override bool Drop_2D2 => true;
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Eog golem";
    public override int Hdice => 100;
    public override int Hside => 20;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 35;
    public override int Mexp => 1200;
    public override bool Nonliving => true;
    public override int NoticeRange => 12;
    public override bool OnlyDropGold => true;
    public override int Rarity => 4;
    public override bool Reflecting => true;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Eog     ";
    public override string SplitName3 => "   golem    ";
}
