// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PitifulLookingBeggarMonsterRace : MonsterRace
{
    protected PitifulLookingBeggarMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerTSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Pitiful looking beggar";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BegAttack)), null, 0, 0),
    };
    public override string Description => "You just can't help feeling sorry for him.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Pitiful looking beggar";
    public override int Hdice => 1;
    public override int Hside => 4;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "  Pitiful   ";
    public override string SplitName2 => "  looking   ";
    public override string SplitName3 => "   beggar   ";
    public override bool TakeItem => true;
}
