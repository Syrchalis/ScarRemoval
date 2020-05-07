using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;

namespace SyrScarRemoval
{
    internal class Recipe_BodyPartRegrowth : RecipeWorker
    {
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            List<Hediff> allHediffs = pawn.health.hediffSet.hediffs;
            for (int i = 0; i < allHediffs.Count; i++)
            {
                if (allHediffs[i].Part != null)
                {
                    if (allHediffs[i].Part.def == ScarRemovalDefOf.Ear || 
                        allHediffs[i].Part.def == ScarRemovalDefOf.Finger || 
                        allHediffs[i].Part.def == ScarRemovalDefOf.Nose || 
                        allHediffs[i].Part.def == ScarRemovalDefOf.Toe ||
                        allHediffs[i].Part.def == ScarRemovalDefOf.Tail)
                    {
                        if (allHediffs[i].def == HediffDefOf.MissingBodyPart && !pawn.health.hediffSet.AncestorHasDirectlyAddedParts(allHediffs[i].Part) && !ParentIsMissing(pawn, allHediffs[i].Part))
                        {
                            yield return allHediffs[i].Part;
                        }
                    }
                }
            }
            yield break;
        }

        private bool ParentIsMissing(Pawn pawn, BodyPartRecord part)
        {
            for (int i = 0; i < pawn.health.hediffSet.hediffs.Count; i++)
            {
                Hediff_MissingPart hediff_MissingPart = pawn.health.hediffSet.hediffs[i] as Hediff_MissingPart;
                if (hediff_MissingPart != null && hediff_MissingPart.Part == part.parent)
                {
                    return true;
                }
            }
            return false;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Hediff x) => x.def == HediffDefOf.MissingBodyPart && x.Part == part);
            if (hediff != null)
            {
                if (PawnUtility.ShouldSendNotificationAbout(pawn) || PawnUtility.ShouldSendNotificationAbout(billDoer))
                {
                    string text;
                    text = "SyrScarRemovalSuccessfullyRegrown".Translate(
                    billDoer.LabelShort,
                    pawn.LabelShort,
                    part.Label);
                    Messages.Message(text, pawn, MessageTypeDefOf.PositiveEvent, true);
                }
                pawn.health.RemoveHediff(hediff);
            }
        }

        public override string GetLabelWhenUsedOn(Pawn pawn, BodyPartRecord part)
        {
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Hediff x) => x.def == HediffDefOf.MissingBodyPart && x.Part == part);
            return "SyrScarRemovalRegrown".Translate() + " " + part.Label;
        }
    }
}
