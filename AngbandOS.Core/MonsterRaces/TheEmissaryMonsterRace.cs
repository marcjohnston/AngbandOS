using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TheEmissaryMonsterRace : MonsterRace
    {
        protected TheEmissaryMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'p';
        public override Colour Colour => Colour.Orange;
        public override string Name => "The Emissary";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Gaze, new TerrifyAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "The Emmisary can pass for human and is used by her demonic overlords to infiltrate human society and gather information. Only her eyes give away her demonic nature.";
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "The Emissary";
        public override int Hdice => 34;
        public override int Hside => 10;
        public override int LevelFound => 16;
        public override int Mexp => 200;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => "  Emissary  ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
