// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MaliciousLeprechaunMonsterRace : MonsterRace
{
    protected MaliciousLeprechaunMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new CauseLightWoundsMonsterSpell(),
        new BlinkMonsterSpell(),
        new TeleportToMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override char Character => 'h';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Malicious leprechaun";

    public override int ArmourClass => 13;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new EatGoldAttackEffect(), 0, 0),
        new MonsterAttack(new TouchAttackType(), new EatItemAttackEffect(), 0, 0),
    };
    public override bool ColdBlood => true;
    public override string Description => "This little creature has a fiendish gleam in its eyes.";
    public override bool Evil => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Malicious leprechaun";
    public override int Hdice => 4;
    public override int Hside => 5;
    public override bool HurtByLight => true;
    public override bool Invisible => true;
    public override int LevelFound => 35;
    public override bool Male => true;
    public override int Mexp => 85;
    public override bool Multiply => true;
    public override int NoticeRange => 8;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 4;
    public override int Sleep => 8;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Malicious  ";
    public override string SplitName3 => " leprechaun ";
    public override bool TakeItem => true;
}
