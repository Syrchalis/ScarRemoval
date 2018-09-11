using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;
using System.Reflection;

namespace SyrScarRemoval
{
    [StaticConstructorOnStartup]
    public static class ScarRemoval_Constructor
    {
        static ScarRemoval_Constructor()
        {
            ApplySettings();
        }

        public static void ApplySettings()
        {
            if (ScarRemovalSettings.hardMode)
            {
                ScarRemovalDefOf.RemoveScar.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.RemoveScarBrain.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.HealAlzheimers.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(6);
                ScarRemovalDefOf.HealDementia.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(8);
                ScarRemovalDefOf.HealFrailty.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(10);
            }
            else
            {
                ScarRemovalDefOf.RemoveScar.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(1);
                ScarRemovalDefOf.RemoveScarBrain.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(1);
                ScarRemovalDefOf.HealAlzheimers.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(3);
                ScarRemovalDefOf.HealDementia.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(4);
                ScarRemovalDefOf.HealFrailty.ingredients.Find(i => i.FixedIngredient == ThingDefOf.MedicineUltratech).SetBaseCount(5);
            }
        }
    }
}
