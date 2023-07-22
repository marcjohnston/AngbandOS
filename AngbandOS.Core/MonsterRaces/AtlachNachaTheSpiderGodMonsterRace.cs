// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AtlachNachaTheSpiderGodMonsterRace : MonsterRace
{
    protected AtlachNachaTheSpiderGodMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheDarkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DarkBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HoldMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DarknessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonCthuloidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonSpiderMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperSSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Atlach-Nacha, the Spider God";

    public override bool Animal => true;
    public override int ArmourClass => 160;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 3, 9),
        new MonsterAttack(new BiteAttackType(), new LoseStrAttackEffect(), 3, 9),
        new MonsterAttack(new StingAttackType(), new PoisonAttackEffect(), 2, 5),
        new MonsterAttack(new StingAttackType(), new LoseStrAttackEffect(), 2, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "'...there was a kind of face on the squat ebon body, low down amid the several-jointed legs. The face peered up with a weird expression of doubt and inquiry...'";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Atlach-Nacha, the Spider God";
    public override bool GreatOldOne => true;
    public override int Hdice => 130;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 75;
    public override int Mexp => 35000;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 8;
    public override bool OnlyDropItem => true;
    public override int Rarity => 1;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Atlach-Nacha";
    public override bool Unique => true;
}
