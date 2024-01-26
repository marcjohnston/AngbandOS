// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ScruffyLookingHobbitMonsterRace : MonsterRace
{
    protected ScruffyLookingHobbitMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerHSymbol));
    public override ColorEnum Color => ColorEnum.BrightOrange;
    public override string Name => "Scruffy looking hobbit";

    public override int ArmorClass => 8;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(EatGoldAttackEffect)), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "A short little guy, in bedraggled clothes. He appears to be looking for a good tavern.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Scruffy looking hobbit";
    public override int Hdice => 3;
    public override int Hside => 5;
    public override int LevelFound => 3;
    public override bool Male => true;
    public override int Mexp => 4;
    public override int NoticeRange => 16;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "  Scruffy   ";
    public override string SplitName2 => "  looking   ";
    public override string SplitName3 => "   hobbit   ";
    public override bool TakeItem => true;
}
