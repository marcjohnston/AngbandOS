// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlinkDogMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlinkMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };

    public override string SymbolName => nameof(UpperCSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A strange magical member of the canine race, its form seems to shimmer and fade in front of your very eyes.";
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Blink dog";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 8;
    public override int LevelFound => 18;
    public override int Mexp => 50;
    public override int NoticeRange => 20;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Blink\ndog";
}
