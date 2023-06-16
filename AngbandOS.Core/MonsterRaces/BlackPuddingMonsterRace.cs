// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackPuddingMonsterRace : MonsterRace
{
    protected BlackPuddingMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'j';
    public override Colour Colour => Colour.Black;
    public override string Name => "Black pudding";

    public override int ArmourClass => 18;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10),
        new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10),
        new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10),
        new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A lump of rotting black flesh that slurrrrrrrps across the dungeon floor.";
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Black pudding";
    public override bool Friends => true;
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 37;
    public override int Mexp => 36;
    public override int NoticeRange => 12;
    public override bool OpenDoor => true;
    public override int Rarity => 5;
    public override int Sleep => 1;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Black    ";
    public override string SplitName3 => "  pudding   ";
    public override bool Stupid => true;
    public override bool TakeItem => true;
}
