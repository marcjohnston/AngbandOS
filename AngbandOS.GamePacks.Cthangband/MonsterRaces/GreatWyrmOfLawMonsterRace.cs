// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatWyrmOfLawMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ShardsBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.SoundBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.DragonSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Silver;
    
    public override int ArmorClass => 170;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 8, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "A massive dragon of powerful intellect. It seeks to dominate the universe and despises all other life. It sees all who do not obey it as mere insects to be crushed underfoot.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Wyrm of Law";
    public override bool Good => true;
    public override int Hdice => 45;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 67;
    public override int Mexp => 29000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 255;
    public override int Speed => 120;
    public override string? MultilineName => "Great\nWyrm of\nLaw";
}
