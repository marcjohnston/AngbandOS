using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HardenedWarriorMonsterRace : MonsterRace
    {
        protected HardenedWarriorMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'p';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Hardened warrior";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "A scarred warrior who moves with confidence.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hardened warrior";
        public override int Hdice => 15;
        public override int Hside => 11;
        public override int LevelFound => 23;
        public override bool Male => true;
        public override int Mexp => 60;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Hardened  ";
        public override string SplitName3 => "  warrior   ";
        public override bool TakeItem => true;
    }
}
