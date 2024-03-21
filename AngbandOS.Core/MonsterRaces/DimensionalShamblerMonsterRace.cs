// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DimensionalShamblerMonsterRace : MonsterRace
{
    protected DimensionalShamblerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Dimensional shambler";

    public override int ArmorClass => 68;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 3, 5),
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A shabby humanoid with a wrinkled skin. It seems to shift in and out of existance as you watch.";
    public override bool Drop_2D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Dimensional shambler";
    public override bool Good => true;
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 29;
    public override int Mexp => 400;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 6;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "Dimensional ";
    public override string SplitName3 => "  shambler  ";
    public override bool TakeItem => true;
}
