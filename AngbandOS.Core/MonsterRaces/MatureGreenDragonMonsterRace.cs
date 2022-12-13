using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MatureGreenDragonMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreathePoisonMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.Green;
        public override string Name => "Mature green dragon";

        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A large dragon, scales tinted deep green.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Mature green dragon";
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 36;
        public override int Mexp => 1100;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "   Mature   ";
        public override string SplitName2 => "   green    ";
        public override string SplitName3 => "   dragon   ";
    }
}
