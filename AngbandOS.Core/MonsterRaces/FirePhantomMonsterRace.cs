// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FirePhantomMonsterRace : MonsterRace
{
    protected FirePhantomMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HoldMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<MindBlastMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperGSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Fire Phantom";

    public override int ArmourClass => 90;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 5, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "He's back from the grave for vengeance on those whoburnt him. He has no mercy for those in his way.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Fire Phantom";
    public override int Hdice => 10;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 34;
    public override bool Male => true;
    public override int Mexp => 1200;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool PassWall => true;
    public override int Rarity => 5;
    public override bool Regenerate => true;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Fire    ";
    public override string SplitName3 => "  Phantom   ";
    public override bool TakeItem => true;
    public override bool Undead => true;
    public override bool Unique => true;
}
