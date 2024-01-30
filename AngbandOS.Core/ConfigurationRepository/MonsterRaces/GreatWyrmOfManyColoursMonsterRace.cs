// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatWyrmOfManyColorsMonsterRace : MonsterRace
{
    protected GreatWyrmOfManyColorsMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheAcidMonsterSpell),
        nameof(BreatheColdMonsterSpell),
        nameof(BreatheLightningMonsterSpell),
        nameof(BreatheFireMonsterSpell),
        nameof(BreathePoisonMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperDSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Great Wyrm of Many Colors";

    public override int ArmorClass => 170;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 6, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 6, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 6, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 9, 14)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A huge dragon whose scales shimmer in myriad hues.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Wyrm of Many Colors";
    public override int Hdice => 52;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 68;
    public override bool LightningAura => true;
    public override int Mexp => 31000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override int Speed => 120;
    public override string SplitName1 => " Great Wyrm ";
    public override string SplitName2 => "  of Many   ";
    public override string SplitName3 => "  Colors   ";
}
