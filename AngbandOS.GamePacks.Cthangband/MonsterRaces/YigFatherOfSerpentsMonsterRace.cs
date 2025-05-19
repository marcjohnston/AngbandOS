// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class YigFatherOfSerpentsMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.DisenchantBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell)
    };

    public override string SymbolName => nameof(UpperJSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 185;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 5, 10),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 5, 10),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 20, 10),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 5, 12)
    };
    public override bool BashDoor => true;
    public override string Description => "A humanoid snake, Yig is one of the most poisonous entities in existance.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Yig, Father of Serpents";
    public override bool GreatOldOne => true;
    public override int Hdice => 85;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 84;
    public override int Mexp => 35000;
    public override bool MoveBody => true;
    public override int NoticeRange => 50;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool ResistDisenchant => true;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override int Speed => 130;
    public override string? MultilineName => "Yig";
    public override bool Unique => true;
}
