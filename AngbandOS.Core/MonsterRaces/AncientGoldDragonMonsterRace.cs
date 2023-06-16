// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientGoldDragonMonsterRace : MonsterRace
{
    protected AncientGoldDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheSoundMonsterSpell(),
        new BlindnessMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => 'D';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Ancient gold dragon";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 10),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 10),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 5, 14),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form wreathed in a nimbus of light.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Ancient gold dragon";
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 40;
    public override int Mexp => 4000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 200;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "  Ancient   ";
    public override string SplitName2 => "    gold    ";
    public override string SplitName3 => "   dragon   ";
}
