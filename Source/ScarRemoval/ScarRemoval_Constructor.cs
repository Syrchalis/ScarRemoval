using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;
using System.Reflection;
using System.Globalization;

namespace SyrScarRemoval
{
    [StaticConstructorOnStartup]
    public static class ScarRemoval_Constructor
    {
        static ScarRemoval_Constructor()
        {
            ApplySettings();
        }

        public static BindingFlags all = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty;
        public static IEnumerable<ThingDef> allAnimals;
        public static void ApplySettings()
        {
            if (ScarRemovalSettings.hardMode)
            {
                ScarRemovalDefOf.RemoveScar.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.RemoveScarBrain.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.RegrowSmallBodyPart.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.HealAlzheimers.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(6);
                ScarRemovalDefOf.HealDementia.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(8);
                ScarRemovalDefOf.HealFrailty.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(10);
            }
            else
            {
                ScarRemovalDefOf.RemoveScar.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(1);
                ScarRemovalDefOf.RemoveScarBrain.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(1);
                ScarRemovalDefOf.RegrowSmallBodyPart.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(1);
                ScarRemovalDefOf.HealAlzheimers.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.HealDementia.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(4);
                ScarRemovalDefOf.HealFrailty.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(5);
            }
            FieldInfo recipeCachedInfo = typeof(ThingDef).GetField("allRecipesCached", all);
            if (allAnimals == null)
            {
                allAnimals = DefDatabase<ThingDef>.AllDefs.Where((ThingDef x) => x?.race?.FleshType != null && x.race.Animal);
            }
            if (ScarRemovalSettings.applyToAnimals && allAnimals != null && recipeCachedInfo != null)
            {
                foreach (ThingDef thingDef in allAnimals)
                {
                    thingDef.recipes.Add(ScarRemovalDefOf.RemoveScar);
                    thingDef.recipes.Add(ScarRemovalDefOf.RemoveScarBrain);
                    thingDef.recipes.Add(ScarRemovalDefOf.RegrowSmallBodyPart);
                    thingDef.recipes.Add(ScarRemovalDefOf.HealAlzheimers);
                    thingDef.recipes.Add(ScarRemovalDefOf.HealDementia);
                    thingDef.recipes.Add(ScarRemovalDefOf.HealFrailty);
                    recipeCachedInfo.SetValue(thingDef, null);
                }
            }
            else if (!ScarRemovalSettings.applyToAnimals && allAnimals != null && recipeCachedInfo != null)
            {
                foreach (ThingDef thingDef in allAnimals)
                {
                    thingDef.recipes.Remove(ScarRemovalDefOf.RemoveScar);
                    thingDef.recipes.Remove(ScarRemovalDefOf.RemoveScarBrain);
                    thingDef.recipes.Remove(ScarRemovalDefOf.RegrowSmallBodyPart);
                    thingDef.recipes.Remove(ScarRemovalDefOf.HealAlzheimers);
                    thingDef.recipes.Remove(ScarRemovalDefOf.HealDementia);
                    thingDef.recipes.Remove(ScarRemovalDefOf.HealFrailty);
                    recipeCachedInfo.SetValue(thingDef, null);
                }
            }
        }
    }
}
