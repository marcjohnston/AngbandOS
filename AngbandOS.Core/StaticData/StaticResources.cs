// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Debug;
using Cthangband.Enumerations;
using Cthangband.Projection;
using System.Reflection;

namespace Cthangband.StaticData
{
    /// <summary>
    /// Singleton class containing objects loaded from an embedded resource
    /// </summary>
    [Serializable]
    internal sealed class StaticResources
    {
        public StaticResources()
        {

        }

        /// <summary>
        /// The singleton instance
        /// </summary>
        public static StaticResources Instance
        {
            get;
            private set;
        }

        public Dictionary<string, AmuletFlavour> AmuletFlavours
        {
            get;
            private set;
        }

        /// <summary>
        /// Animations for spells and effects
        /// </summary>
        public Dictionary<string, Animation> Animations
        {
            get;
            private set;
        }

        public Dictionary<string, BaseFixedartifact> BaseFixedartifacts
        {
            get;
            private set;
        }

        public Dictionary<string, BaseItemType> BaseItemTypes
        {
            get;
            private set;
        }

        public Dictionary<string, BaseMonsterRace> BaseMonsterRaces
        {
            get;
            private set;
        }

        public Dictionary<string, BaseRareItemType> BaseRareItemTypes
        {
            get;
            private set;
        }

        public Dictionary<string, BaseVaultType> BaseVaultTypes
        {
            get;
            private set;
        }

        /// <summary>
        /// Types of floor tile
        /// </summary>
        public Dictionary<string, FloorTileType> FloorTileTypes
        {
            get;
            private set;
        }

        public Dictionary<string, MushroomFlavour> MushroomFlavours
        {
            get;
            private set;
        }

        public Dictionary<string, PotionFlavour> PotionFlavours
        {
            get;
            private set;
        }

        /// <summary>
        /// Graphics for projectiles
        /// </summary>
        public Dictionary<string, ProjectileGraphic> ProjectileGraphics
        {
            get;
            private set;
        }

        public Dictionary<string, RingFlavour> RingFlavours
        {
            get;
            private set;
        }

        public Dictionary<string, RodFlavour> RodFlavours
        {
            get;
            private set;
        }

        public Dictionary<string, ScrollFlavour> ScrollFlavours
        {
            get;
            private set;
        }

        public Dictionary<string, StaffFlavour> StaffFlavours
        {
            get;
            private set;
        }

        public Dictionary<string, WandFlavour> WandFlavours
        {
            get;
            private set;
        }

        /// <summary>
        /// Load the dictionaries from the binary resource file
        /// </summary>
        public static void LoadOrCreate()
        {
            Instance = new StaticResources
            {
                BaseMonsterRaces = ReadEntitiesFromCsv(new BaseMonsterRace())
            };
            // Instance.BaseItemTypes = ReadEntitiesFromCsv(new BaseItemType(), "BaseItemType"); // Uncomment to scaffold
            Instance.BaseFixedartifacts = ReadEntitiesFromCsv(new BaseFixedartifact());
            Instance.BaseRareItemTypes = ReadEntitiesFromCsv(new BaseRareItemType());
            Instance.BaseVaultTypes = ReadEntitiesFromCsv(new BaseVaultType());
            Instance.FloorTileTypes = ReadEntitiesFromCsv(new FloorTileType());
            Instance.Animations = ReadEntitiesFromCsv(new Animation());
            Instance.ProjectileGraphics = ReadEntitiesFromCsv(new ProjectileGraphic());
            Instance.AmuletFlavours = ReadEntitiesFromCsv(new AmuletFlavour());
            Instance.MushroomFlavours = ReadEntitiesFromCsv(new MushroomFlavour());
            Instance.PotionFlavours = ReadEntitiesFromCsv(new PotionFlavour());
            Instance.WandFlavours = ReadEntitiesFromCsv(new WandFlavour());
            Instance.ScrollFlavours = ReadEntitiesFromCsv(new ScrollFlavour());
            Instance.StaffFlavours = ReadEntitiesFromCsv(new StaffFlavour());
            Instance.RingFlavours = ReadEntitiesFromCsv(new RingFlavour());
            Instance.RodFlavours = ReadEntitiesFromCsv(new RodFlavour());
        }

        private static Dictionary<string, T> ReadEntitiesFromCsv<T>(T sample, string scaffoldTemplateName = null) where T : EntityType, new()
        {
            Dictionary<string, T> dictionary = new Dictionary<string, T>();
            PropertyInfo[] properties = sample.GetType().GetProperties();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] names = assembly.GetManifestResourceNames();
            string name = sample.GetType().Name;
            string resourceName = $"AngbandOS.Core.Data.{name}s.csv";
            foreach (string match in names)
            {
                if (match == resourceName)
                {
                    using (Stream ms = assembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader reader = new StreamReader(ms))
                        {
                            string[] header = reader.ReadLine().Split(',');
                            Dictionary<string, int> headerNames = new Dictionary<string, int>();
                            for (int i = 0; i < header.Length; i++)
                            {
                                headerNames.Add(header[i], i);
                            }
                            if (reader.EndOfStream == false)
                            {
                                do
                                {
                                    string line = reader.ReadLine();
                                    if (string.IsNullOrEmpty(line))
                                    {
                                        continue;
                                    }
                                    string[] values = line.Split(',');
                                    T entity = new T();
                                    foreach (PropertyInfo p in properties)
                                    {
                                        if (headerNames.ContainsKey(p.Name))
                                        {
                                            if (!p.CanWrite)
                                            {
                                                continue;
                                            }
                                            string stringValue = values[headerNames[p.Name]].FromCsvFriendly();
                                            switch (p.PropertyType.Name)
                                            {
                                                case "Colour":
                                                    p.SetValue(entity, Enum.Parse(typeof(Colour), stringValue));
                                                    break;

                                                case "Char":
                                                    p.SetValue(entity, Convert.ToChar(stringValue));
                                                    break;

                                                case "String":
                                                    p.SetValue(entity, stringValue);
                                                    break;

                                                case "AttackEffect":
                                                    p.SetValue(entity, Enum.Parse(typeof(AttackEffect), stringValue));
                                                    break;

                                                case "FloorTileAlterAction":
                                                    p.SetValue(entity, Enum.Parse(typeof(FloorTileAlterAction), stringValue));
                                                    break;

                                                case "FixedArtifactId":
                                                    p.SetValue(entity, Enum.Parse(typeof(FixedArtifactId), stringValue));
                                                    break;

                                                case "FloorTileTypeCategory":
                                                    p.SetValue(entity, Enum.Parse(typeof(FloorTileTypeCategory), stringValue));
                                                    break;

                                                case "ItemCategory":
                                                    p.SetValue(entity, Enum.Parse(typeof(ItemCategory), stringValue));
                                                    break;

                                                case "RareItemType":
                                                    p.SetValue(entity, Enum.Parse(typeof(Enumerations.RareItemType), stringValue));
                                                    break;

                                                case "AttackType":
                                                    p.SetValue(entity, Enum.Parse(typeof(AttackType), stringValue));
                                                    break;

                                                case "Int32":
                                                    p.SetValue(entity, Convert.ToInt32(stringValue));
                                                    break;

                                                case "Boolean":
                                                    p.SetValue(entity, Convert.ToBoolean(stringValue));
                                                    break;

                                                case "MonsterAttack":
                                                    break;

                                                default:
                                                    Program.MessageBoxShow($"Unrecognised property type: {p.PropertyType.Name}");
                                                    break;
                                            }
                                        }
                                    }
                                    dictionary.Add(entity.Name, entity);
                                } while (reader.EndOfStream == false);
                            }
                        }
                        ms.Close();
                    }
                }
            }

            if (scaffoldTemplateName != null)
            {
                string templateName = $"Cthangband.Data.ScaffoldTemplates.{scaffoldTemplateName}.template";
                List<string> templateLines = new List<string>();
                using (Stream templateStream = assembly.GetManifestResourceStream(templateName))
                {
                    using (StreamReader streamReader = new StreamReader(templateStream))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            templateLines.Add(streamReader.ReadLine());
                        }
                    }
                }
                string path = "C:\\Users\\Marc\\Source\\Repos\\Cthangband\\AngbandOS.Core\\Data";
                path = $"{path}{Path.DirectorySeparatorChar}{scaffoldTemplateName}s{Path.DirectorySeparatorChar}";
                foreach (T entity in dictionary.Values)
                {
                    List<string> scaffoldedOutput = new List<string>();
                    PropertyInfo[] entityProperties = entity.GetType().GetProperties();
                    foreach (string templateLine in templateLines)
                    {
                        string[] tokens = templateLine.Split(Path.DirectorySeparatorChar);
                        bool include = true;
                        for (int index = 1; index < tokens.Length; index += 2)
                        {
                            PropertyInfo desiredProperty = entityProperties.Single(property => property.Name == tokens[index]);
                            switch (desiredProperty.PropertyType.Name)
                            {
                                case "Boolean":
                                    {
                                        bool value = (bool)desiredProperty.GetValue(entity);
                                        tokens[index] = value ? "true" : "false";
                                        include = value;
                                        break;
                                    }
                                case "Colour":
                                    {
                                        Colour value = (Colour)desiredProperty.GetValue(entity);
                                        tokens[index] = value.ToString();
                                        include = (value != Colour.White && value != Colour.Background); // Provided by the base class no need to override
                                        break;
                                    }
                                case "Int32":
                                    {
                                        int value = (int)desiredProperty.GetValue(entity);
                                        tokens[index] = value.ToString();
                                        include = (value != 0); // Provided by the base class no need to override
                                        break;
                                    }
                                case "ItemCategory":
                                    {
                                        tokens[index] = desiredProperty.GetValue(entity).ToString();
                                        break;
                                    }
                                case "Char":
                                    {
                                        char value = (char)desiredProperty.GetValue(entity);
                                        tokens[index] = value == '\\' ? @"\\" : value.ToString();
                                        break;
                                    }
                                case "String":
                                    {
                                        tokens[index] = desiredProperty.GetValue(entity).ToString();
                                        break;
                                    }
                                default:
                                    throw new Exception("Scaffolding data type not supported.");
                            }
                        }
                        if (include)
                        {
                            scaffoldedOutput.Add(String.Join("", tokens));
                        }
                    }
                    string className = (string)entityProperties.Single(property => property.Name == "ClassName").GetValue(entity);
                    File.WriteAllLines($"{path}{Path.DirectorySeparatorChar}{className}.cs", scaffoldedOutput);
                }
            }
            return dictionary;
        }
    }
}