// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RedJellyMonsterRace : MonsterRace
{
    protected RedJellyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerJSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Red jelly";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseStrAttackEffect>(), 1, 5),
    };
    public override string Description => "It is a large pulsating mound of red flesh.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Red jelly";
    public override int Hdice => 26;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 7;
    public override int Mexp => 26;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 99;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Red     ";
    public override string SplitName3 => "   jelly    ";
    public override bool Stupid => true;
}