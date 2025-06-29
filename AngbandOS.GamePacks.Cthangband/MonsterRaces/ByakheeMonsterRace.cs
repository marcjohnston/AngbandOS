// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ByakheeMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell),
        nameof(MonsterSpellsEnum.DemonSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperBSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 40;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 3, 4),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.Exp20AttackEffect), 3, 4),
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "Hybrid demon birds: 'not altogether crows, nor moles, nor buzzards, nor ants, nor decomposed human beings...'";
    public override bool Drop_2D2 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Byakhee";
    public override bool Friends => true;
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 41;
    public override int Mexp => 1500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string? MultilineName => "Byakhee";
}
