// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheEmperorQuylthulgMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.HiDragonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell)
    };

    public override string SymbolName => nameof(UpperQSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    
    public override bool Animal => true;
    public override int ArmorClass => 1;
    public override string Description => "A huge seething mass of flesh with a rudimentary intelligence, the Emperor Quylthulg changes colors in front of your eyes. Pulsating first one color then the next, it knows only it must bring help to protect itself.";
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "The Emperor Quylthulg";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 78;
    public override int Mexp => 20000;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override int Speed => 130;
    public override string? MultilineName => "The\nEmperor\nQuylthulg";
    public override bool Unique => true;
}
