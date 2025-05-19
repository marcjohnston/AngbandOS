// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MoonBeastMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.CauseSeriousWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell)
    };

    public override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 3),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 3),
        (nameof(ButtAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A great greyish-white slippery toad-creature with a mass of pink tentacles on the end of its snout.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Moon beast";
    public override int Hdice => 9;
    public override int Hside => 10;
    public override bool ImmuneFire => true;
    public override int LevelFound => 12;
    public override int Mexp => 57;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Moon\nbeast";
}
