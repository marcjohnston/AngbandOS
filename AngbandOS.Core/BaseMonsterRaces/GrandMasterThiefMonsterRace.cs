using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GrandMasterThiefMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Black;
        public override string Name => "Grand master thief";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Touch, new EatItemAttackEffect(), 5, 5),
        };
        public override bool BashDoor => true;
        public override bool CreateTraps => true;
        public override string Description => "A furtive figure who makes you want to hide all your valuables.";
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Grand master thief";
        public override int Hdice => 25;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 52;
        public override bool Male => true;
        public override int Mexp => 20000;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 140;
        public override string SplitName1 => "   Grand    ";
        public override string SplitName2 => "   master   ";
        public override string SplitName3 => "   thief    ";
        public override bool TakeItem => true;
    }
}
