using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CarcharothTheJawsOfThirstMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new ScareMonsterSpell(),
            new HealMonsterSpell(),
            new SummonHoundMonsterSpell());
        public override char Character => 'C';
        public override Colour Colour => Colour.Black;
        public override string Name => "Carcharoth, the Jaws of Thirst";

        public override bool Animal => true;
        public override int ArmourClass => 110;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 4, 4)
        };
        public override bool BashDoor => true;
        public override string Description => "The first guard of Angband, Carcharoth, also known as 'The Red Maw', is the largest wolf to ever walk the earth. He is highly intelligent and a deadly opponent in combat.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Carcharoth, the Jaws of Thirst";
        public override int Hdice => 75;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 92;
        public override bool Male => true;
        public override int Mexp => 40000;
        public override bool MoveBody => true;
        public override int NoticeRange => 80;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Carcharoth ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
