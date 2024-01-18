// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DoomDrakeMonsterRace : MonsterRace
{
    protected DoomDrakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheFireMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerDSymbol));
    public override ColourEnum Colour => ColourEnum.Beige;
    public override string Name => "Doom drake";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "Doom drakes are trained firedrakes, always moving in pairs, looking for a battle.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Doom drake";
    public override bool Friends => true;
    public override int Hdice => 40;
    public override int Hside => 11;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 34;
    public override int Mexp => 450;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Doom    ";
    public override string SplitName3 => "   drake    ";
}
