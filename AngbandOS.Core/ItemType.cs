// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StaticData;
using System;

namespace AngbandOS
{
    /// <summary>
    /// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
    /// properties are modifyable.
    /// </summary>
    [Serializable]
    internal class ItemType
    {
        public readonly int[] Chance = new int[4];
        public readonly FlagSet Flags1 = new FlagSet();
        public readonly FlagSet Flags2 = new FlagSet();
        public readonly FlagSet Flags3 = new FlagSet();
        public readonly int[] Locale = new int[4];

        /// <summary>
        /// Returns true, if the item is stompable (based on the known "feeling" of (Broken, Average, Good & Excellent)).
        /// Use StompableType enum to address each index.
        /// </summary>
        public readonly bool[] Stompable = new bool[4];
        public readonly int Ac;
        /// <summary>
        /// Provided for backwards compatability.  Will be deleted.  Provides access to the ItemCategory enumerable.
        /// </summary>
        public readonly ItemCategory Category; 

        /// <summary>
        /// Returns the readonly scaffolded base item type.
        /// </summary>
        public IItemCategory BaseCategory = null;

        public char Character;
        public Colour Colour;
        public readonly int Cost;
        public readonly int Dd;
        public readonly int Ds;
        public bool EasyKnow;

        /// <summary>
        /// The special flavor of the item has been identified. (e.g. of "seeing")
        /// </summary>
        public bool FlavourAware;
        public bool HasFlavor;
        public readonly int Level;
        public readonly string Name;
        public readonly int Pval;

        /// <summary>
        /// Represents the subcategory enumeration for the item.  As items are scaffolded, this property should be eliminated.  Return null, when not in use.
        /// </summary>
        public readonly int? SubCategory;
        public readonly int ToA;
        public readonly int ToD;
        public readonly int ToH;
        public bool Tried;
        public readonly int Weight;

        public ItemType(IItemCategory baseItem)
        {
            Character = baseItem.Character;
            Colour = baseItem.Colour;
            Name = baseItem.FriendlyName;
            Ac = baseItem.Ac;
            BaseCategory = baseItem; // Instantiate the ItemCategory that this ItemType is based from.
            Category = baseItem.CategoryEnum; // We need a copy of this category enum for backwards compatability at this time.
            Chance[0] = baseItem.Chance1;
            Chance[1] = baseItem.Chance2;
            Chance[2] = baseItem.Chance3;
            Chance[3] = baseItem.Chance4;
            Cost = baseItem.Cost;
            Dd = baseItem.Dd;
            Ds = baseItem.Ds;
            Level = baseItem.Level;
            Locale[0] = baseItem.Locale1;
            Locale[1] = baseItem.Locale2;
            Locale[2] = baseItem.Locale3;
            Locale[3] = baseItem.Locale4;
            Pval = baseItem.Pval;
            SubCategory = baseItem.SubCategory;
            ToA = baseItem.ToA;
            ToD = baseItem.ToD;
            ToH = baseItem.ToH;
            Tried = baseItem.Tried;
            Weight = baseItem.Weight;
            Flags1.Set(baseItem.Blows ? ItemFlag1.Blows : 0);
            Flags1.Set(baseItem.BrandAcid ? ItemFlag1.BrandAcid : 0);
            Flags1.Set(baseItem.BrandCold ? ItemFlag1.BrandCold : 0);
            Flags1.Set(baseItem.BrandElec ? ItemFlag1.BrandElec : 0);
            Flags1.Set(baseItem.BrandFire ? ItemFlag1.BrandFire : 0);
            Flags1.Set(baseItem.BrandPois ? ItemFlag1.BrandPois : 0);
            Flags1.Set(baseItem.Cha ? ItemFlag1.Cha : 0);
            Flags1.Set(baseItem.Chaotic ? ItemFlag1.Chaotic : 0);
            Flags1.Set(baseItem.Con ? ItemFlag1.Con : 0);
            Flags1.Set(baseItem.Dex ? ItemFlag1.Dex : 0);
            Flags1.Set(baseItem.Impact ? ItemFlag1.Impact : 0);
            Flags1.Set(baseItem.Infra ? ItemFlag1.Infra : 0);
            Flags1.Set(baseItem.Int ? ItemFlag1.Int : 0);
            Flags1.Set(baseItem.KillDragon ? ItemFlag1.KillDragon : 0);
            Flags1.Set(baseItem.Search ? ItemFlag1.Search : 0);
            Flags1.Set(baseItem.SlayAnimal ? ItemFlag1.SlayAnimal : 0);
            Flags1.Set(baseItem.SlayDemon ? ItemFlag1.SlayDemon : 0);
            Flags1.Set(baseItem.SlayDragon ? ItemFlag1.SlayDragon : 0);
            Flags1.Set(baseItem.SlayEvil ? ItemFlag1.SlayEvil : 0);
            Flags1.Set(baseItem.SlayGiant ? ItemFlag1.SlayGiant : 0);
            Flags1.Set(baseItem.SlayOrc ? ItemFlag1.SlayOrc : 0);
            Flags1.Set(baseItem.SlayTroll ? ItemFlag1.SlayTroll : 0);
            Flags1.Set(baseItem.SlayUndead ? ItemFlag1.SlayUndead : 0);
            Flags1.Set(baseItem.Speed ? ItemFlag1.Speed : 0);
            Flags1.Set(baseItem.Stealth ? ItemFlag1.Stealth : 0);
            Flags1.Set(baseItem.Str ? ItemFlag1.Str : 0);
            Flags1.Set(baseItem.Tunnel ? ItemFlag1.Tunnel : 0);
            Flags1.Set(baseItem.Vampiric ? ItemFlag1.Vampiric : 0);
            Flags1.Set(baseItem.Vorpal ? ItemFlag1.Vorpal : 0);
            Flags1.Set(baseItem.Wis ? ItemFlag1.Wis : 0);
            Flags2.Set(baseItem.FreeAct ? ItemFlag2.FreeAct : 0);
            Flags2.Set(baseItem.HoldLife ? ItemFlag2.HoldLife : 0);
            Flags2.Set(baseItem.ImAcid ? ItemFlag2.ImAcid : 0);
            Flags2.Set(baseItem.ImCold ? ItemFlag2.ImCold : 0);
            Flags2.Set(baseItem.ImElec ? ItemFlag2.ImElec : 0);
            Flags2.Set(baseItem.ImFire ? ItemFlag2.ImFire : 0);
            Flags2.Set(baseItem.Reflect ? ItemFlag2.Reflect : 0);
            Flags2.Set(baseItem.ResAcid ? ItemFlag2.ResAcid : 0);
            Flags2.Set(baseItem.ResBlind ? ItemFlag2.ResBlind : 0);
            Flags2.Set(baseItem.ResChaos ? ItemFlag2.ResChaos : 0);
            Flags2.Set(baseItem.ResCold ? ItemFlag2.ResCold : 0);
            Flags2.Set(baseItem.ResConf ? ItemFlag2.ResConf : 0);
            Flags2.Set(baseItem.ResDark ? ItemFlag2.ResDark : 0);
            Flags2.Set(baseItem.ResDisen ? ItemFlag2.ResDisen : 0);
            Flags2.Set(baseItem.ResElec ? ItemFlag2.ResElec : 0);
            Flags2.Set(baseItem.ResFear ? ItemFlag2.ResFear : 0);
            Flags2.Set(baseItem.ResFire ? ItemFlag2.ResFire : 0);
            Flags2.Set(baseItem.ResLight ? ItemFlag2.ResLight : 0);
            Flags2.Set(baseItem.ResNether ? ItemFlag2.ResNether : 0);
            Flags2.Set(baseItem.ResNexus ? ItemFlag2.ResNexus : 0);
            Flags2.Set(baseItem.ResPois ? ItemFlag2.ResPois : 0);
            Flags2.Set(baseItem.ResShards ? ItemFlag2.ResShards : 0);
            Flags2.Set(baseItem.ResSound ? ItemFlag2.ResSound : 0);
            Flags2.Set(baseItem.SustCha ? ItemFlag2.SustCha : 0);
            Flags2.Set(baseItem.SustCon ? ItemFlag2.SustCon : 0);
            Flags2.Set(baseItem.SustDex ? ItemFlag2.SustDex : 0);
            Flags2.Set(baseItem.SustInt ? ItemFlag2.SustInt : 0);
            Flags2.Set(baseItem.SustStr ? ItemFlag2.SustStr : 0);
            Flags2.Set(baseItem.SustWis ? ItemFlag2.SustWis : 0);
            Flags3.Set(baseItem.AntiTheft ? ItemFlag3.AntiTheft : 0);
            Flags3.Set(baseItem.Activate ? ItemFlag3.Activate : 0);
            Flags3.Set(baseItem.Aggravate ? ItemFlag3.Aggravate : 0);
            Flags3.Set(baseItem.Blessed ? ItemFlag3.Blessed : 0);
            Flags3.Set(baseItem.Cursed ? ItemFlag3.Cursed : 0);
            Flags3.Set(baseItem.DrainExp ? ItemFlag3.DrainExp : 0);
            Flags3.Set(baseItem.DreadCurse ? ItemFlag3.DreadCurse : 0);
            Flags3.Set(baseItem.EasyKnow ? ItemFlag3.EasyKnow : 0);
            Flags3.Set(baseItem.Feather ? ItemFlag3.Feather : 0);
            Flags3.Set(baseItem.HeavyCurse ? ItemFlag3.HeavyCurse : 0);
            Flags3.Set(baseItem.HideType ? ItemFlag3.HideType : 0);
            Flags3.Set(baseItem.IgnoreAcid ? ItemFlag3.IgnoreAcid : 0);
            Flags3.Set(baseItem.IgnoreCold ? ItemFlag3.IgnoreCold : 0);
            Flags3.Set(baseItem.IgnoreElec ? ItemFlag3.IgnoreElec : 0);
            Flags3.Set(baseItem.IgnoreFire ? ItemFlag3.IgnoreFire : 0);
            Flags3.Set(baseItem.InstaArt ? ItemFlag3.InstaArt : 0);
            Flags3.Set(baseItem.Lightsource ? ItemFlag3.Lightsource : 0);
            Flags3.Set(baseItem.NoMagic ? ItemFlag3.NoMagic : 0);
            Flags3.Set(baseItem.NoTele ? ItemFlag3.NoTele : 0);
            Flags3.Set(baseItem.PermaCurse ? ItemFlag3.PermaCurse : 0);
            Flags3.Set(baseItem.Regen ? ItemFlag3.Regen : 0);
            Flags3.Set(baseItem.SeeInvis ? ItemFlag3.SeeInvis : 0);
            Flags3.Set(baseItem.ShElec ? ItemFlag3.ShElec : 0);
            Flags3.Set(baseItem.ShFire ? ItemFlag3.ShFire : 0);
            Flags3.Set(baseItem.ShowMods ? ItemFlag3.ShowMods : 0);
            Flags3.Set(baseItem.SlowDigest ? ItemFlag3.SlowDigest : 0);
            Flags3.Set(baseItem.Telepathy ? ItemFlag3.Telepathy : 0);
            Flags3.Set(baseItem.Teleport ? ItemFlag3.Teleport : 0);
            Flags3.Set(baseItem.Wraith ? ItemFlag3.Wraith : 0);
            Flags3.Set(baseItem.XtraMight ? ItemFlag3.XtraMight : 0);
            Flags3.Set(baseItem.XtraShots ? ItemFlag3.XtraShots : 0);
        }

        public static bool KindIsGood(ItemType kPtr)
        {
            return kPtr.BaseCategory.KindIsGood;
        }

        public static ItemType RandomItemType(SaveGame saveGame, int level)
        {
            int i;
            int j;
            AllocationEntry[] table = saveGame.AllocKindTable;
            if (level > 0)
            {
                if (Program.Rng.RandomLessThan(Constants.GreatObj) == 0)
                {
                    level = 1 + (level * Constants.MaxDepth / Program.Rng.DieRoll(Constants.MaxDepth));
                }
            }
            int total = 0;
            for (i = 0; i < saveGame.AllocKindSize; i++)
            {
                if (table[i].Level > level)
                {
                    break;
                }
                table[i].FinalProbability = 0;
                int kIdx = table[i].Index;
                ItemType kPtr = saveGame.ItemTypes[kIdx];
                if (saveGame.Level?.OpeningChest == true &&
                    kPtr.Category == ItemCategory.Chest)
                {
                    continue;
                }
                table[i].FinalProbability = table[i].FilteredProbabiity;
                total += table[i].FinalProbability;
            }
            if (total <= 0)
            {
                return null;
            }
            long value = Program.Rng.RandomLessThan(total);
            for (i = 0; i < saveGame.AllocKindSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            int p = Program.Rng.RandomLessThan(100);
            if (p < 60)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < saveGame.AllocKindSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            if (p < 10)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < saveGame.AllocKindSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            return saveGame.ItemTypes[table[i].Index];
        }

        public bool HasQuality()
        {
            switch (Category)
            {
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                case ItemCategory.Boots:
                case ItemCategory.Bow:
                case ItemCategory.Cloak:
                case ItemCategory.Crown:
                case ItemCategory.Digging:
                case ItemCategory.DragArmor:
                case ItemCategory.Gloves:
                case ItemCategory.Hafted:
                case ItemCategory.HardArmor:
                case ItemCategory.Helm:
                case ItemCategory.Polearm:
                case ItemCategory.Shield:
                case ItemCategory.Shot:
                case ItemCategory.SoftArmor:
                case ItemCategory.Sword:
                    return true;

                case ItemCategory.Light:
                    return SubCategory == LightType.Orb;

                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}