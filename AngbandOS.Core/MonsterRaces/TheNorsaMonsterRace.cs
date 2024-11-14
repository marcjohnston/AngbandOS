// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TheNorsaMonsterRace : MonsterRace
{
    protected TheNorsaMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBreatheBallMonsterSpell),
        nameof(ColdBreatheBallMonsterSpell),
        nameof(LightningBreatheBallMonsterSpell),
        nameof(FireBreatheBallMonsterSpell),
        nameof(PoisonBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonMonstersMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override int ArmorClass => 125;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AcidAttackEffect), 8, 12),
        (nameof(CrushAttack), nameof(FireAttackEffect), 8, 12),
        (nameof(CrushAttack), nameof(ElectricityAttackEffect), 8, 12),
        (nameof(CrushAttack), nameof(PoisonAttackEffect), 10, 14)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "An elephantine horror with five trunks, each capable of breathing destructive blasts of elements.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "The Norsa";
    public override int Hdice => 100;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 70;
    public override bool LightningAura => true;
    public override int Mexp => 47500;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override int Sleep => 70;
    public override int Speed => 130;
    public override string? MultilineName => "The\nNorsa";
    public override bool Unique => true;
}
