// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FormlessSpawnOfTsathogguaMonsterRace : MonsterRace
{
    protected FormlessSpawnOfTsathogguaMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBoltMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(SummonCthuloidMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(AcidAttackEffect), 2, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(AcidAttackEffect), 2, 4),
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(HurtAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(AcidAttackEffect), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A black, protean being of amorphous slime.";
    public override bool Drop90 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Formless spawn of Tsathoggua";
    public override int Hdice => 22;
    public override int Hside => 20;
    public override bool HurtByFire => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 41;
    public override int Mexp => 1850;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string? MultilineName => "Formless\nspawn of\nTsathoggua";
}
