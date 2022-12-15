// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.FixedArtifacts;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS
{
    [Serializable]
    internal class FixedArtifact
    {
        public readonly ItemCharacteristics FixedArtifactItemCharacteristics = new ItemCharacteristics();
        public int Ac;
        public int Cost;

        /// <summary>
        /// Represents the quantity of this artifact currently in existence.
        /// </summary>
        public int CurNum;

        public int Dd;
        public int Ds;
        public bool HasOwnType;
        public int Level;
        public string Name;
        public int Pval;
        public int Rarity;

        public int ToA;
        public int ToD;
        public int ToH;

        public int Weight;
        public readonly ItemClass BaseItemCategory;
        public readonly BaseFixedArtifact BaseFixedArtifact;

        public FixedArtifact(BaseFixedArtifact baseFixedArtifact)
        {
            BaseFixedArtifact = baseFixedArtifact;
            BaseItemCategory = baseFixedArtifact.BaseItemCategory;

            Ac = baseFixedArtifact.Ac;
            Cost = baseFixedArtifact.Cost;
            CurNum = 0;
            Dd = baseFixedArtifact.Dd;
            Ds = baseFixedArtifact.Ds;
            Level = baseFixedArtifact.Level;
            Name = baseFixedArtifact.FriendlyName;
            Pval = baseFixedArtifact.Pval;
            Rarity = baseFixedArtifact.Rarity;
            ToA = baseFixedArtifact.ToA;
            ToD = baseFixedArtifact.ToD;
            ToH = baseFixedArtifact.ToH;
            Weight = baseFixedArtifact.Weight;
            HasOwnType = baseFixedArtifact.HasOwnType;

            FixedArtifactItemCharacteristics.Merge(baseFixedArtifact);
        }
    }
}