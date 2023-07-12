// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlueJellyMonsterRace : MonsterRace
{
    protected BlueJellyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerJSymbol>();
    public override ColourEnum Colour => ColourEnum.Blue;
    public override string Name => "Blue jelly";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new ColdAttackEffect(), 1, 6),
    };
    public override bool ColdBlood => true;
    public override string Description => "It's a large pile of pulsing blue flesh.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Blue jelly";
    public override int Hdice => 12;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 4;
    public override int Mexp => 14;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 99;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Blue    ";
    public override string SplitName3 => "   jelly    ";
    public override bool Stupid => true;
}
