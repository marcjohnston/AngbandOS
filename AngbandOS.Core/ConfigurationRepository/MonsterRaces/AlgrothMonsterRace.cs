// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AlgrothMonsterRace : MonsterRace
{
    protected AlgrothMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperTSymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Algroth";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(PoisonAttackEffect)), 3, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(PoisonAttackEffect)), 3, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A powerful troll form. Venom drips from its needlelike claws.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Algroth";
    public override bool Friends => true;
    public override int Hdice => 21;
    public override int Hside => 12;
    public override int LevelFound => 27;
    public override int Mexp => 150;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Algroth   ";
    public override bool Troll => true;
}
