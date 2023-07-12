// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HomonculousMonsterRace : MonsterRace
{
    protected HomonculousMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerUSymbol>();
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "Homonculous";

    public override int ArmourClass => 32;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new ParalyzeAttackEffect(), 1, 2),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a small demonic spirit full of malevolence.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Homonculous";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override int LevelFound => 15;
    public override int Mexp => 40;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Homonculous ";
}
