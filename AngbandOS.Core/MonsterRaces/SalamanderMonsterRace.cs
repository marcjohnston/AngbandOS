// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SalamanderMonsterRace : MonsterRace
{
    protected SalamanderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'R';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "Salamander";

    public override bool Animal => true;
    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 1, 3),
    };
    public override string Description => "A small black and orange lizard.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Salamander";
    public override int Hdice => 4;
    public override int Hside => 6;
    public override bool ImmuneFire => true;
    public override int LevelFound => 2;
    public override int Mexp => 10;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Salamander ";
}
