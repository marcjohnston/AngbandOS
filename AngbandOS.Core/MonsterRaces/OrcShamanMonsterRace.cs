using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class OrcShamanMonsterRace : MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Orc shaman";

        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool CauseLightWounds => true;
        public override string Description => "An orc dressed in skins who gestures wildly.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Orc shaman";
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override int LevelFound => 9;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 30;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Orc     ";
        public override string SplitName3 => "   shaman   ";
    }
}