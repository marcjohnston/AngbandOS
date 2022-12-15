using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HuntingHorrorMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheDarkMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new SummonCthuloidMonsterSpell());
        public override char Character => 'U';
        public override Colour Colour => Colour.Black;
        public override string Name => "Hunting horror";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new LoseDexAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 9, 4),
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "It is a winged serpent with a distorted head.";
        public override bool Drop_1D2 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Hunting horror";
        public override int Hdice => 30;
        public override int Hside => 17;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 42;
        public override int Mexp => 2300;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Hunting   ";
        public override string SplitName3 => "   horror   ";
    }
}
