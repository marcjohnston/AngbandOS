// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IpsissimusMonsterRace : MonsterRace
{
    protected IpsissimusMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(SummonDemonMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportToMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Ipsissimus";

    public override int ArmorClass => 50;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A gaunt figure, clothed in black robes.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Ipsissimus";
    public override int Hdice => 28;
    public override int Hside => 10;
    public override int LevelFound => 36;
    public override bool Male => true;
    public override int Mexp => 666;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Ipsissimus ";
}
