// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

global using AngbandOS.Core;
global using AngbandOS.Core.ActivationWeightRandoms;
global using AngbandOS.Core.ArtifactBiases;
global using AngbandOS.Core.BirthStages;
global using AngbandOS.Core.CharacterClasses;
global using AngbandOS.Core.CharacterClassAbilities;
global using AngbandOS.Core.ChestTraps;
global using AngbandOS.Core.ConsoleElements;
global using AngbandOS.Core.DungeonGenerators;
global using AngbandOS.Core.Expressions;
global using AngbandOS.Core.MonsterSelectors;
global using AngbandOS.Core.EventArgs;
global using AngbandOS.Core.EventsArgs;
global using AngbandOS.Core.FlaggedActions;
global using AngbandOS.Core.ItemFlavors;
global using AngbandOS.Core.FloorEffects;
global using AngbandOS.Core.Functions;
global using AngbandOS.Core.GetItemProperties;
global using AngbandOS.Core.Interfaces;
global using AngbandOS.Core.WieldSlots;
global using AngbandOS.Core.ItemActions;
global using AngbandOS.Core.ItemEffects;
global using AngbandOS.Core.ItemTests;
global using AngbandOS.Core.ItemMatches;
global using AngbandOS.Core.ItemQualityRatings;
global using AngbandOS.Core.MappedSpellScripts;
global using AngbandOS.Core.MonsterFilters;
global using AngbandOS.Core.MonsterRaceFilters;
global using AngbandOS.Core.MonsterSpells;
global using AngbandOS.Core.Mutations.ActiveMutations;
global using AngbandOS.Core.Mutations.PassiveMutations;
global using AngbandOS.Core.Mutations.RandomMutations;
global using AngbandOS.Core.PlayerEffects;
global using AngbandOS.Core.Properties;
global using AngbandOS.Core.PropertyFormatters;
global using AngbandOS.Core.PhysicalAttributeSets;
global using AngbandOS.Core.Races;
global using AngbandOS.Core.RaceAbilities;
global using AngbandOS.Core.RaceGenders;
global using AngbandOS.Core.Rewards;
global using AngbandOS.Core.RoomLayouts;
global using AngbandOS.Core.Scripts;
global using AngbandOS.Core.SpellResistantDetections;
global using AngbandOS.Core.Timers;

global using static AngbandOS.Core.Extensions;
global using Timer = AngbandOS.Core.Timers.Timer;
global using AngbandOS.Core.Interface;
global using AngbandOS.Core.Interface.Configuration;
global using AngbandOS.GamePacks.Cthangband; // TODO: This can be deleted when the Cthangband game pack is complete.  We can also drop the Project Reference.

global using System.Text.Json;
