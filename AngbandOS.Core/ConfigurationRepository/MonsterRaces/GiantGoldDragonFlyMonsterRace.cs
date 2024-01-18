// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantGoldDragonFlyMonsterRace : MonsterRace
{
    protected GiantGoldDragonFlyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheSoundMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperFSymbol));
    public override ColourEnum Colour => ColourEnum.Gold;
    public override string Name => "Giant gold dragon fly";

    public override bool Animal => true;
    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "Large beating wings support this dazzling insect. A loud buzzing noise pervades the air.";
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Giant gold dragon fly";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 19;
    public override int Mexp => 78;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string SplitName1 => " Giant gold ";
    public override string SplitName2 => "   dragon   ";
    public override string SplitName3 => "    fly     ";
    public override bool WeirdMind => true;
}
