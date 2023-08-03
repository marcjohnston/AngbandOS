// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BrownYeekMonsterRace : MonsterRace
{
    protected BrownYeekMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerYSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Brown yeek";

    public override bool Animal => true;
    public override int ArmourClass => 18;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a strange small humanoid.";
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Brown yeek";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 8;
    public override int Mexp => 11;
    public override int NoticeRange => 18;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Brown    ";
    public override string SplitName3 => "    yeek    ";
}
