using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ApprenticeCultistMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Apprentice cultist";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override bool CauseLightWounds => true;
        public override string Description => "He is tripping over his fetishes.";
        public override bool Drop60 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Apprentice cultist";
        public override bool Friends => true;
        public override int Hdice => 7;
        public override bool Heal => true;
        public override int Hside => 4;
        public override int LevelFound => 6;
        public override bool Male => true;
        public override int Mexp => 7;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Apprentice   ";
        public override string SplitName3 => "  cultist   ";
    }
}