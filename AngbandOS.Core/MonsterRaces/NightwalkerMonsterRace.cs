using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NightwalkerMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new NetherBallMonsterSpell(),
            new NetherBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 'z';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nightwalker";

        public override int ArmourClass => 175;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 7, 7),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 7, 7)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A huge giant garbed in black, more massive than a titan and stronger than a dragon. With terrible blows, it breaks your armour from your back, leaving you defenseless against its evil wrath. It can smell your fear, and you in turn smell the awful stench of death as this ghastly figure strides towards you menacingly.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Nightwalker";
        public override int Hdice => 50;
        public override int Hside => 65;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 59;
        public override int Mexp => 15000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Nightwalker ";
        public override bool Undead => true;
    }
}
