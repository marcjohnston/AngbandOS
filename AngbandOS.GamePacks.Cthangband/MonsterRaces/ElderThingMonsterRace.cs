// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElderThingMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.RadiationBallMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBallMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.CthuloidSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportAwayMonsterSpell)
    };

    public override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 70;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseWisAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override bool Demon => true;
    public override string Description => "It is barrel-shaped, with horizontal arms and a starfish head.";
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Elder thing";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 800;
    public override bool Nonliving => true;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Elder\nthing";
}
