// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheKingInYellowMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ColdBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.AcidBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBallMonsterSpell),
        nameof(MonsterSpellsEnum.WaterBoltMonsterSpell)
    };

    public override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    
    public override int ArmorClass => 150;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "A sentient arcane tome casting spells with malevolent intent.";
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "The King in Yellow";
    public override int Hdice => 50;
    public override int Hside => 15;
    public override bool HurtByFire => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 1500;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 20;
    public override int Rarity => 4;
    public override bool ResistNether => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 15;
    public override int Speed => 120;
    public override string? MultilineName => "The\nKing in\nYellow";
}
