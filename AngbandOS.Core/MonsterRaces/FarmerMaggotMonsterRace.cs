// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FarmerMaggotMonsterRace : MonsterRace
{
    protected FarmerMaggotMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 't';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Farmer Maggot";

    public override int ArmourClass => 10;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new MoanAttackType(), null, 0, 0),
        new MonsterAttack(new MoanAttackType(), null, 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He's lost his dogs. He's had his mushrooms stolen. He's not a happy hobbit!";
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Farmer Maggot";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override int Sleep => 3;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Farmer   ";
    public override string SplitName3 => "   Maggot   ";
    public override bool Unique => true;
}
