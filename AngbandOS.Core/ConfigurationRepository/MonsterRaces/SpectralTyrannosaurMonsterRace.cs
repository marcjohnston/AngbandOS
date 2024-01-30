// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpectralTyrannosaurMonsterRace : MonsterRace
{
    protected SpectralTyrannosaurMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheNetherMonsterSpell),
        nameof(BreatheNexusMonsterSpell),
        nameof(BreathePoisonMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperRSymbol));
    public override ColorEnum Color => ColorEnum.Turquoise;
    public override string Name => "Spectral tyrannosaur";

    public override bool Animal => true;
    public override int ArmorClass => 120;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp40AttackEffect)), 2, 13),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp40AttackEffect)), 2, 13),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseStrAttackEffect)), 5, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(TerrifyAttackEffect)), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "A deadly undead horror which looks like a skeletal tyrannosaur surrounded by a sickly green glow.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Spectral tyrannosaur";
    public override int Hdice => 70;
    public override int Hside => 50;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 46;
    public override int Mexp => 15000;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistNexus => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Spectral  ";
    public override string SplitName3 => "tyrannosaur ";
    public override bool Undead => true;
}
