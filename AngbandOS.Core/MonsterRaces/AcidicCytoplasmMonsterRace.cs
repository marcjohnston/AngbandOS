using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.AttackTypes;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AcidicCytoplasmMonsterRace : MonsterRace
    {
        protected AcidicCytoplasmMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'j';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Acidic cytoplasm";

        public override int ArmourClass => 18;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10),
            new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10),
            new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10),
            new MonsterAttack(new TouchAttackType(), new AcidAttackEffect(), 1, 10)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A disgusting animated blob of destruction. Flee its gruesome hunger!";
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Acidic cytoplasm";
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 35;
        public override int Mexp => 36;
        public override int NoticeRange => 12;
        public override bool OpenDoor => true;
        public override int Rarity => 5;
        public override int Sleep => 1;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Acidic   ";
        public override string SplitName3 => " cytoplasm  ";
        public override bool Stupid => true;
        public override bool TakeItem => true;
    }
}
