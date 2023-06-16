// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TyrannosaurMonsterRace : MonsterRace
{
    protected TyrannosaurMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'R';
    public override Colour Colour => Colour.Green;
    public override string Name => "Tyrannosaur";

    public override bool Animal => true;
    public override int ArmourClass => 70;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 6),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 6),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 3, 6),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 3, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A horror from prehistory, reawakened by chaos.";
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Tyrannosaur";
    public override int Hdice => 200;
    public override int Hside => 3;
    public override int LevelFound => 24;
    public override int Mexp => 350;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Tyrannosaur ";
}
