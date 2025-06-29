// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NightcrawlerMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.NetherBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell)
    };

    public override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 160;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(StingAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 8, 8),
        (nameof(StingAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 8, 8),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 10, 10),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 10, 10)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "This intensely evil creature bears the form of a gargantuan black worm. Its gaping maw is a void of blackness, acid drips from its steely hide. It is like nothing you have ever seen before, and a terrible chill runs down your spine as you face it.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Nightcrawler";
    public override int Hdice => 80;
    public override int Hside => 60;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillWall => true;
    public override int LevelFound => 54;
    public override int Mexp => 8100;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Nightcrawler";
    public override bool Undead => true;
}
