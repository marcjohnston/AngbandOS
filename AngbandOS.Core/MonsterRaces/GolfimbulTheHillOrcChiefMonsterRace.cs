using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GolfimbulTheHillOrcChiefMonsterRace : MonsterRace
    {
        protected GolfimbulTheHillOrcChiefMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'o';
        public override Colour Colour => Colour.Copper;
        public override string Name => "Golfimbul, the Hill Orc Chief";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10)
        };
        public override bool BashDoor => true;
        public override string Description => "A leader of a band of raiding orcs, he picks on hobbits.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Golfimbul, the Hill Orc Chief";
        public override int Hdice => 24;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 12;
        public override bool Male => true;
        public override int Mexp => 230;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Golfimbul  ";
        public override bool Unique => true;
    }
}
