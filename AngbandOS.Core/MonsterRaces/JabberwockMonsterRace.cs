// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class JabberwockMonsterRace : MonsterRace
{
    protected JabberwockMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheChaosMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseMortalWoundsMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperHSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Jabberwock";

    public override bool Animal => true;
    public override int ArmourClass => 125;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 10),
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 10),
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 10),
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 10)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "'Beware the Jabberwock, my son!The jaws that bite, the claws that catch!'";
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Jabberwock";
    public override int Hdice => 32;
    public override int Hside => 100;
    public override int LevelFound => 65;
    public override int Mexp => 19000;
    public override int NoticeRange => 35;
    public override bool OnlyDropItem => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Jabberwock ";
}
