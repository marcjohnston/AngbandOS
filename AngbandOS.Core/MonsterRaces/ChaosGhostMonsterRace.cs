// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChaosGhostMonsterRace : MonsterRace
{
    protected ChaosGhostMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new DrainManaMonsterSpell(),
        new HoldMonsterSpell(),
        new ForgetMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperGSymbol>();
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Chaos ghost";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new WailAttackType(), new TerrifyAttackEffect(), 0, 0),
        new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 0, 0),
        new MonsterAttack(new ClawAttackType(), new LoseIntAttackEffect(), 1, 10),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "An almost life-like creature which is nothing more than a phantom created by the chaos.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Chaos ghost";
    public override int Hdice => 14;
    public override int Hside => 20;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 33;
    public override int Mexp => 350;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Chaos    ";
    public override string SplitName3 => "   ghost    ";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
