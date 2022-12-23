using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShubNiggurathBlackGoatOfTheWoodsMonsterRace : MonsterRace
    {
        protected ShubNiggurathBlackGoatOfTheWoodsMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheChaosMonsterSpell(),
            new BreatheConfusionMonsterSpell(),
            new BreathePoisonMonsterSpell(),
            new BreatheRadiationMonsterSpell(),
            new ChaosBallMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new DarkBallMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new HealMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new SummonUniqueMonsterSpell());
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Shub-Niggurath, Black Goat of the Woods";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new LoseWisAttackEffect(), 20, 5),
            new MonsterAttack(AttackType.Crush, new LoseIntAttackEffect(), 20, 5),
            new MonsterAttack(AttackType.Bite, new LoseStrAttackEffect(), 10, 2),
            new MonsterAttack(AttackType.Bite, new LoseConAttackEffect(), 10, 2)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "This horrendous outer god looks like a writhing cloudy mass filled with mouths and tentacles.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Shub-Niggurath, Black Goat of the Woods";
        public override bool GreatOldOne => true;
        public override int Hdice => 65;
        public override int Hside => 99;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 91;
        public override bool LightningAura => true;
        public override int Mexp => 47500;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Shub-Niggura";
        public override bool Unique => true;
    }
}
