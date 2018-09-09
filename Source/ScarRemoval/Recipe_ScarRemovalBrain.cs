using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;

namespace SyrScarRemoval
{
    internal class Recipe_ScarRemovalBrain : RecipeWorker
    {
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            List<Hediff> allHediffs = pawn.health.hediffSet.hediffs;
            for (int i = 0; i < allHediffs.Count; i++)
            {
                if (allHediffs[i].Part != null && allHediffs[i].Part.def == BodyPartDefOf.Brain)
                {
                    if (allHediffs[i].TryGetComp<HediffComp_GetsPermanent>() != null)
                    {
                        if (allHediffs[i].IsPermanent())
                        {
                            yield return allHediffs[i].Part;
                        }
                    }
                }
            }
            yield break;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Hediff x) => x.TryGetComp<HediffComp_GetsPermanent>() != null && x.Part == part && x.IsPermanent());
            if (hediff != null)
            {
                if (PawnUtility.ShouldSendNotificationAbout(pawn) || PawnUtility.ShouldSendNotificationAbout(billDoer))
                {
                    string text;
                    if (part.def.delicate)
                    {
                        text = "SyrScarRemovalSuccessfullyHealed".Translate(new object[]
                        {
                        billDoer.LabelShort,
                        pawn.LabelShort,
                        hediff.TryGetComp<HediffComp_GetsPermanent>().Props.instantlyPermanentLabel,
                        part.Label
                        });
                    }
                    else
                    {
                        text = "SyrScarRemovalSuccessfullyHealed".Translate(new object[]
                        {
                        billDoer.LabelShort,
                        pawn.LabelShort,
                        hediff.TryGetComp<HediffComp_GetsPermanent>().Props.permanentLabel,
                        part.Label
                        });
                    }
                    Messages.Message(text, pawn, MessageTypeDefOf.PositiveEvent, true);
                }
                pawn.health.RemoveHediff(hediff);
            }
        }

        public override string GetLabelWhenUsedOn(Pawn pawn, BodyPartRecord part)
        {
            Hediff hediff = pawn.health.hediffSet.hediffs.Find((Hediff x) => x.TryGetComp<HediffComp_GetsPermanent>() != null && x.Part == part && x.IsPermanent());
            return "SyrScarRemovalHeal".Translate() + " " + hediff.Label;
        }
    }
}
