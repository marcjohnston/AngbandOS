using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AncientWhiteDragonMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheColdMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'D';
        public override string Name => "Ancient white dragon";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 9),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 9),
            new MonsterAttack(AttackType.Bite, new ColdAttackEffect(), 5, 12),
        };
        public override bool BashDoor => true;
        public override string Description => "A huge draconic form. Frost covers it from head to tail.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Ancient white dragon";
        public override int Hdice => 70;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 39;
        public override int Mexp => 2500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "   white    ";
        public override string SplitName3 => "   dragon   ";
    }
}
