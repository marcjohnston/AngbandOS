// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class QlzqqlzuupTheLordOfFleshMonsterRace : MonsterRace
{
    protected QlzqqlzuupTheLordOfFleshMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AntSummonMonsterSpell),
        nameof(CthuloidSummonMonsterSpell),
        nameof(DemonSummonMonsterSpell),
        nameof(DragonSummonMonsterSpell),
        nameof(GreatOldOneSummonMonsterSpell),
        nameof(HiDragonSummonMonsterSpell),
        nameof(HiUndeadSummonMonsterSpell),
        nameof(HoundSummonMonsterSpell),
        nameof(HydraSummonMonsterSpell),
        nameof(KinSummonMonsterSpell),
        nameof(MonsterSummonMonsterSpell),
        nameof(MonstersSummonMonsterSpell),
        nameof(SpiderSummonMonsterSpell),
        nameof(UndeadSummonMonsterSpell),
        nameof(UniqueSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperQSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override bool Animal => true;
    public override int ArmorClass => 1;
    public override bool AttrMulti => true;
    public override string Description => "This disgusting creature squeals and snorts as it writhes on the floor. It pulsates with evil. Its intent is to overwhelm you with monster after monster, until it can greedily dine on your remains.";
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 1;
    public override int FreqSpell => 1;
    public override string FriendlyName => "Qlzqqlzuup, the Lord of Flesh";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 78;
    public override int Mexp => 20000;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override int Speed => 130;
    public override string? MultilineName => "Qlzqqlzuup";
    public override bool Unique => true;
}
