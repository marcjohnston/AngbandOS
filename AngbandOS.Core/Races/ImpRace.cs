using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;
using System.Windows.Markup;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class ImpRace : Race
    {
        public override string Title => "Imp";
        public override int[] AbilityBonus => new int[] { -1, -1, -1, 1, 2, -3 };
        public override int BaseDisarmBonus => -3;
        public override int BaseDeviceBonus => 2;
        public override int BaseSaveBonus => -1;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => -5;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 110;
        public override int BaseAge => 13;
        public override int AgeRange => 4;
        public override int MaleBaseHeight => 68;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 150;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 64;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 120;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 3;
        public override uint Choice => 0x97CB;
        public override int Index => RaceId.Imp;
        public override string Description => "Imps are minor demons that have escaped their binding and\nare able to run free in the world. Imps naturally resist\nfire, and can learn to throw bolt of flame (at lvl 10),\nsee invisible creatures (at lvl 10), become completely\nimmune to fire (at lvl 20), and cast fireballs (at lvl 30).";

        /// <summary>
        /// Imp 94->95->96->97->End
        /// </summary>
        public override int Chart => 94;

        public override string RacialPowersDescription(int lvl) => lvl < 9 ? "fire bolt/ball     (racial, unusable until level 9/30)" : "fire bolt/ball(30) (racial, cost 15, dam lvl, WIS based)";
        public override bool HasRacialPowers => true;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.ResFire = true;
            if (level > 9)
            {
                itemCharacteristics.SeeInvis = true;
            }
            if (level > 19)
            {
                itemCharacteristics.ImFire = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new AngelicSyllables());
        public override string[]? SelfKnowledge(int level)
        {
            List<string> values = new List<string>();
            if (level > 29)
            {
                values.Add($"You can cast a Fire Ball, dam. {level} (cost 15).");
            }
            else if (level > 8)
            {
                values.Add($"You can cast a Fire Bolt, dam. {level} (cost 15).");
            }
            if (values.Count == 0)
                return null;
            return values.ToArray();
        }
    }
}