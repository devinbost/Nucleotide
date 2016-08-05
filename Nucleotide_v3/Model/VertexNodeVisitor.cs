using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v3.Exceptions;
using Nucleotide_v3.States;

namespace Nucleotide_v3.Model
{
    public class VertexNodeVisitor<E,V,M>  where M:NodeStateContextMediator<E,V>, new() 
        where E:EdgeNodeStateContext, new()
        where V:VertexNodeStateContext, new()
    {
        public enum FirstStepTaken
        {
            Yes,
            No
        }

        //public void Visit(NodeStateContextMediator<E, V> mediator,
        //    int startingVertexPosition)
        //{
        //    Visit(mediator, null, null, startingVertexPosition, FirstStepTaken.No, new List<V>(),new List<V>());
        //}
        //public void Visit(NodeStateContextMediator<E, V> mediator,
        //    VertexNodeStateContext chosenManVertex,
        //    VertexNodeStateContext chosenWomanVertex,
        //    int startingVertexPosition, FirstStepTaken firstStepTaken, List<V> manVertexTrail, List<V> womanVertexTrail)
        //{
        //    #region initialStep
        //    if (firstStepTaken == FirstStepTaken.No)
        //    {

        //        var startingVertexContext = mediator.GetVertexNodeStateContextByPosition(startingVertexPosition);

        //        startingVertexContext.ChooseAsOrigin();

        //        var adjacentEdgeStateContexts = startingVertexContext.GetIncidentEdgeNodeStateContexts(mediator);
        //        var edgeNodeStateFactory = new EdgeNodeStateContextFactory<E>();
        //        var vertexNodeStateFactory = new VertexNodeStateContextFactory<V>();
        //        var facadeFactory = new NodeStateContextContainerFacadeFlyweightFactory<E, V>(edgeNodeStateFactory, vertexNodeStateFactory);
        //        /* Now that the state is changed to origin, I need the origin
        //         * to return a list of incident unchosen edges.
        //         * Note: The elements returned by the DecideNext(..) method of a state
        //         *      depend upon that state.
        //         * Then I must generate the marriage list.
        //        */
        //        var marriageList = new List<Tuple<EdgeNodeStateContext, EdgeNodeStateContext>>();
        //        for (int i = 0; i <= adjacentEdgeStateContexts.Count - 1; i++)
        //        {
        //            for (int j = 0; j <= i; j++)
        //            {
        //                var man = adjacentEdgeStateContexts[i];
        //                var woman = adjacentEdgeStateContexts[j];
        //                if (man.Position != woman.Position)
        //                {
        //                    var marriage = new Tuple<EdgeNodeStateContext, EdgeNodeStateContext>(man, woman);
        //                    marriageList.Add(marriage);
        //                }
        //            }
        //        }
        //        foreach (var marriage in marriageList)
        //        {
        //            //Parallel.ForEach(marriageList, marriage =>
        //            //{
        //            var manVertexTrailCopy = manVertexTrail.Copy<V>(vertexNodeStateFactory);
        //            var womanVertexTrailCopy = womanVertexTrail.Copy<V>(vertexNodeStateFactory);
        //            var mediatorCopy = mediator.Copy(facadeFactory);

        //            var manEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item1.Position);
        //            var womanEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item2.Position);
        //            // performance impact of all the copying may be significant.
        //            // this may be where making contexts flyweight will improve performance much.
        //            // In that case, we would need to change state at the context level
        //            //      or at least inject the context (and a factory?) into the nodeStateContext.

        //            manEdgeCopy.ChooseAsMale();
        //            var manTargetVertex =
        //                manEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
        //            manTargetVertex.ChooseAsMale();
        //            manVertexTrailCopy.Add(manTargetVertex);

        //            womanEdgeCopy.ChooseAsFemale(); // We can just choose the female here because we already ensured that the only marriages that exist are ones where the man's choice will not cause the woman's choice to orphan a vertex.
        //            var womanTargetVertex = womanEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
        //            womanTargetVertex.ChooseAsFemale();
        //            womanVertexTrailCopy.Add(womanTargetVertex);
        //            // Since this is the first step, the edges that must be cut are the ones that are incident to the sourceVertex but are still Unchosen.

        //            // Any remaining unchosen edges that are incident to the originVertex must be cut.
        //            var originVertexCopy = mediatorCopy.GetVertexNodeStateContextByPosition(startingVertexPosition);
        //            originVertexCopy.CutRemainingUnchosenEdges(mediatorCopy); // And thus they are cut.

        //            var manVertexTrailCopy2 = manVertexTrailCopy.Copy<V>(vertexNodeStateFactory);
        //            var womanVertexTrailCopy2 = womanVertexTrailCopy.Copy<V>(vertexNodeStateFactory);
        //            Visit(mediatorCopy, manTargetVertex, womanTargetVertex, startingVertexPosition, FirstStepTaken.Yes, manVertexTrailCopy2, womanVertexTrailCopy2);
        //            // I need a method on the EdgeNodeStateContext that returns the incident vertex
        //            // that has specified state (of UnchosenVertexNodeState).


        //            // I need to copy the facade here.
        //            // Then I can change the stateContexts for the appropriate ones

        //        }
        //        //});
        //    }
        //    #endregion
        //    if (firstStepTaken == FirstStepTaken.Yes)
        //    {
        //        // from the manTarget and womanTarget, we need to select the list of UnvisitedEdgeNodeStateContexts.
        //        // We must check if any cut orphans a target vertex.
        //        // Cuts that create orphans must be processed first.

        //        // Get all the unchosen edges that don't orphan vertex?
        //        // It is important to determine that the choice of the man does not
        //        //      orphan the woman's vertex after cuts are made.

        //        var unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault = chosenManVertex.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(mediator);
        //        //var unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault = chosenWomanVertex.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(mediator);
        //        // would a cut to any of these unchosenEdgeNodes cause an orphan?
        //        // If count == 0, then we can choose all of these edges.
        //        // If count == 1, then we can choose only one of these edges.
        //        // If count >= 2, then neither of these edges can be chosen without creating an orphan.

        //        var marriageList = new List<Tuple<EdgeNodeStateContext, EdgeNodeStateContext>>();
        //        marriageList.Clear();

        //        var edgeNodeStateFactory = new EdgeNodeStateContextFactory<E>();
        //        var vertexNodeStateFactory = new VertexNodeStateContextFactory<V>();
        //        var facadeFactory = new NodeStateContextContainerFacadeFlyweightFactory<E, V>(edgeNodeStateFactory, vertexNodeStateFactory);

        //        for (int i = 0; i < unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault.Count; i++)
        //        {
        //            var man = unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault[i];
        //            // We must determine if choosing this man will affect our possible choices of women.

        //            var tempMediatorCopy = mediator.Copy(facadeFactory);
        //            var tempManEdgeCopy = tempMediatorCopy.GetEdgeNodeStateContextByPosition(man.Position);
        //            var tempManEdgeCopyVertices = tempManEdgeCopy.GetIncidentVerticesAsTuple(tempMediatorCopy);
        //            //if ((tempManEdgeCopyVertices.Item1.Position.Equals(9) || tempManEdgeCopyVertices.Item1.Position.Equals(10))
        //            //    && ((tempManEdgeCopyVertices.Item2.Position.Equals(9) || tempManEdgeCopyVertices.Item2.Position.Equals(10))))
        //            //{
        //            //    Console.Write("This is where we must inspect");
        //            //}
        //            //var tempEdge911 = tempMediatorCopy.GetEdgeIncidentToBothVertices(9, 11);
        //            //var tempEdge910 = tempMediatorCopy.GetEdgeIncidentToBothVertices(9, 10);
        //            //var tempEdge1112 = tempMediatorCopy.GetEdgeIncidentToBothVertices(11, 12);
        //            //var tempEdge39 = tempMediatorCopy.GetEdgeIncidentToBothVertices(3, 9);

        //            //var edge911 = mediator.GetEdgeIncidentToBothVertices(9, 11);
        //            //var edge910 = mediator.GetEdgeIncidentToBothVertices(9, 10);
        //            //var edge1112 = mediator.GetEdgeIncidentToBothVertices(11, 12);
        //            //var edge39 = mediator.GetEdgeIncidentToBothVertices(3, 9);

        //            var tempManEdgeIncidentUnchosenVertices =
        //                tempManEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(tempMediatorCopy);
        //            if (tempManEdgeIncidentUnchosenVertices == null)
        //            {
        //                // Then this means we have found an edge that forms a closure and cannot be chosen.
        //                // Perhaps we can just cut it.
        //                // We really probably should log this to the console.
        //                continue; // Regardless, we need to skip to the next possible man edge.
        //            }
        //            var tempManTargetVertexCopy =
        //                tempMediatorCopy.GetVertexNodeStateContextByPosition(tempManEdgeIncidentUnchosenVertices.Position);
        //            tempManEdgeCopy.ChooseAsMale();
        //            tempManTargetVertexCopy.ChooseAsMale();
        //            var tempManSourceVertexCopy =
        //                tempMediatorCopy.GetVertexNodeStateContextByPosition(chosenManVertex.Position);
        //            tempManSourceVertexCopy.CutRemainingUnchosenEdges(tempMediatorCopy);

        //            var tempWomanSourceVertexCopy = tempMediatorCopy.GetVertexNodeStateContextByPosition(chosenWomanVertex.Position);

        //            var unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault = tempWomanSourceVertexCopy.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(tempMediatorCopy);
        //            var manTrail = mediator.GetEdgeNodesWithStateChosenMale.ToList(); // What's faster: dynamic lookup, or copy to method parameters?
        //            var womanTrail = mediator.GetEdgeNodesWithStateChosenFemale.ToList(); // We must use the mediator because the copy contains edges with temporary state changes.

        //            for (int j = 0; j < unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault.Count; j++)
        //            {
        //                //var man = unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault[i];
        //                var woman = unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault[j];
        //                if (man.Position != woman.Position)
        //                {
        //                    var manVertices = man.GetIncidentVerticesAsTuple(tempMediatorCopy); // Should I ensure that only one hasn't been visited?
        //                    // Or should I ensure that both haven't been visited?
        //                    var womanVertices = woman.GetIncidentVerticesAsTuple(tempMediatorCopy);
        //                    // This is where we are resolving conflicts by only adding elements to the marriageList
        //                    // that have not already been visited.
        //                    // We actually could simplify these checks.
        //                    var manEdgeVertexTupleList = new List<Tuple<V, V>>();
        //                    var womanEdgeVertexTupleList = new List<Tuple<V, V>>();
        //                    foreach (var manEdgeInTrail in manTrail)
        //                    {
        //                        var edgeVertices = manEdgeInTrail.GetIncidentVerticesAsTuple(tempMediatorCopy);
        //                        manEdgeVertexTupleList.Add(edgeVertices);
        //                    }
        //                    foreach (var womanEdgeInTrail in womanTrail)
        //                    {
        //                        var edgeVertices = womanEdgeInTrail.GetIncidentVerticesAsTuple(tempMediatorCopy);
        //                        womanEdgeVertexTupleList.Add(edgeVertices);
        //                    }
        //                    //var manVertex1InManTrail = manVertexTrail.Any(t => t.Position == manVertices.Item1.Position);
        //                    //var manVertex2InManTrail = manVertexTrail.Any(t => t.Position == manVertices.Item2.Position);
        //                    //var manVertex1InWomanTrail = womanVertexTrail.Any(t => t.Position == manVertices.Item1.Position);
        //                    //var manVertex2InWomanTrail = womanVertexTrail.Any(t => t.Position == manVertices.Item2.Position);
        //                    //var womanVertex1InManTrail = manVertexTrail.Any(t => t.Position == womanVertices.Item1.Position);
        //                    //var womanVertex2InManTrail = manVertexTrail.Any(t => t.Position == womanVertices.Item2.Position);
        //                    //var womanVertex1InWomanTrail = womanVertexTrail.Any(t => t.Position == womanVertices.Item1.Position);
        //                    //var womanVertex2InWomanTrail = womanVertexTrail.Any(t => t.Position == womanVertices.Item2.Position);

        //                    //var manVerticesAreAlreadyVisited = (manVertex1InManTrail && manVertex2InManTrail) ||
        //                    //                   (manVertex1InWomanTrail && manVertex2InWomanTrail) ||
        //                    //                   (manVertex1InManTrail && manVertex2InWomanTrail) ||
        //                    //                   (manVertex2InManTrail && manVertex1InWomanTrail);
        //                    //var womanVerticesAreAlreadyVisited = (womanVertex1InManTrail && womanVertex2InManTrail) ||
        //                    //                   (womanVertex1InWomanTrail && womanVertex2InWomanTrail) ||
        //                    //                   (womanVertex1InManTrail && womanVertex2InWomanTrail) ||
        //                    //                   (womanVertex2InManTrail && womanVertex1InWomanTrail);

        //                    var manTrailContainsMan = manTrail.Any(t => t.Position == man.Position);
        //                    var womanTrailContainsWoman = womanTrail.Any(t => t.Position == woman.Position);
        //                    var manTrailContainsWoman = manTrail.Any(t => t.Position == woman.Position);
        //                    var womanTrailContainsMan = womanTrail.Any(t => t.Position == man.Position);
        //                    //if (!manVerticesAreAlreadyVisited && !womanVerticesAreAlreadyVisited)
        //                    if (!manTrailContainsMan && !womanTrailContainsWoman && !manTrailContainsWoman && !womanTrailContainsMan)
        //                    {
        //                        // I need a way to check: where if man is chosen, are any of woman's incident target vertices orphaned?
        //                        // If so, then these must be chosen.
        //                        // Get original man and woman contexts.
        //                        var originalManEdge = mediator.GetEdgeNodeStateContextByPosition(man.Position);
        //                        var originalManEdgeVertices =
        //                            originalManEdge.GetIncidentVerticesAsTuple(mediator);

        //                        var originalWomanEdge = mediator.GetEdgeNodeStateContextByPosition(woman.Position);

        //                        var originalWomanEdgeVertices =
        //                            originalWomanEdge.GetIncidentVerticesAsTuple(mediator);
        //                        //if ((originalManEdge.Position == 15 && originalWomanEdge.Position == 18) ||
        //                        //(originalManEdge.Position == 18 && originalWomanEdge.Position == 15))
        //                        //{
        //                        //    Console.WriteLine("Here is a problem.");
        //                        //}

        //                        var marriage = new Tuple<EdgeNodeStateContext, EdgeNodeStateContext>(originalManEdge, originalWomanEdge);
        //                        marriageList.Add(marriage);
        //                    }
        //                }
        //                else // In this case, because both man and woman have reached the same vertex, we have the closure of a cycle.
        //                {
        //                    Console.WriteLine("Closure on vertex {0}", man.Position); // note: man.Position == woman.Position in this case.
        //                    // Then we should write the members of the two trails to the console, like this:
        //                    // womanTrailReverse = womanTrail.Reverse();
        //                    // originVertex, manTrail[0], manTrail[1], ..., manTrail[n], man.Position, womanTrailReverse[0], womanTrailReverse[1], ...,
        //                    // womanTrailReverse[m].
        //                    //WritePathIDToConsole(originVertex, manTrail, womanTrail, man);
        //                    //WritePathIDToConsoleFaster(startingVertexPosition, manTrail, womanTrail, man, mediator);
        //                }
        //            }
        //        }
        //        Parallel.ForEach(marriageList, marriage =>
        //        {
        //            //foreach (var marriage in marriageList)
        //            //{


        //            // The marriageList contains the list of edge pairs that we may visit/choose.
        //            // At this point, since we are beyond the first step, when we choose an edge,
        //            // the source chosen vertex will have two chosen incident edges, and any 
        //            // remaining unchosen incident edges need to be cut.
        //            // If that cut produces an orphan, then we cannot make the cut.
        //            // So if that cut produces an orphan, then this marriage cannot be chosen.

        //            // How would we determine (in advance) if a particular marriage pair choice would result in
        //            // a cut that would create an orphan?

        //            /*We would need to go back to where we are adding marriages to the list.
        //             Then, when we are about to add a manVertex to the marriage,
        //             * the choice of the edge between the sourceMan and the marriage's targetMan
        //             * would induce a cut in the other unchosen edges incident to the sourceMan.
        //             * 
        //             * Is there a way that we could infer these cases (before creating the marriages)
        //             * that would be more efficient than just doing it here?
        //             */
        //            // item1 is the man, item2 is the woman

        //            /* At this point, we need to copy the mediator, choose the manEdge, perform cuts to unchosen
        //             * edges ,
        //            */
        //            var mediatorCopy = mediator.Copy(facadeFactory);

        //            var manEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item1.Position);
        //            var womanEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item2.Position);
        //            // performance impact of all the copying may be significant.
        //            // this may be where making contexts flyweight will improve performance much.
        //            // In that case, we would need to change state at the context level
        //            //      or at least inject the context (and a factory?) into the nodeStateContext.

        //            // I need a way to choose the vertex.

        //            var manVertexTrailCopy = manVertexTrail.Copy<V>(vertexNodeStateFactory); // these must be copied at the beginning of the loop
        //            var womanVertexTrailCopy = womanVertexTrail.Copy<V>(vertexNodeStateFactory); // to prevent modifying the list across loop iterations.

        //            manEdgeCopy.ChooseAsMale();

        //            var manTargetVertexCopy =
        //                manEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
        //            manTargetVertexCopy.ChooseAsMale();
        //            manVertexTrailCopy.Add(manTargetVertexCopy);

        //            // These women should already be compatable with the men UNLESS the woman's edge forms a closure for a cycle
        //            // in which case at least one of the womanEdge's vertices should already be NOT unchosen (i.e. chosen as a man).
        //            var womanVertexTuple = womanEdgeCopy.GetIncidentVerticesAsTuple(mediatorCopy);
        //            var womanVertex1IsUnchosen = womanVertexTuple.Item1.State.Equals(UnchosenVertexNodeState.Instance);
        //            var womanVertex2IsUnchosen = womanVertexTuple.Item2.State.Equals(UnchosenVertexNodeState.Instance);
        //            //if (!womanVertex1IsUnchosen || !womanVertex2IsUnchosen)
        //            //{
        //            //    Console.WriteLine("Test");
        //            //    //continue; // This continue operation takes us out of this loop instance because we are done here for this marriage.
        //            //}
        //            womanEdgeCopy.ChooseAsFemale();
        //            var womanTargetVertexCopy = womanEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
        //            if (womanTargetVertexCopy == null)
        //            {
        //                //Console.WriteLine("One of womanEdge's vertices has already been chosen, so this womanEdge will close the cycle.");
        //                // We must write the result to the console and continue.
        //                WritePathIDToConsoleFaster(startingVertexPosition,
        //                    manVertexTrailCopy,
        //                    womanVertexTrailCopy, mediatorCopy);
        //                return; // return is used for the parallel foreach loop.
        //                //continue; // continue is used for the regular foreach loop.
        //            }
        //            // the above method call will fail if the womanEdge closes a cycle.
        //            womanTargetVertexCopy.ChooseAsFemale();
        //            womanVertexTrailCopy.Add(womanTargetVertexCopy);
        //            // Since this is the first step, the edges that must be cut are the ones that are incident to the sourceVertex but are still Unchosen.

        //            // Any remaining unchosen edges that are incident to the originVertex must be cut.
        //            var manSourceVertexCopy = mediatorCopy.GetVertexNodeStateContextByPosition(chosenManVertex.Position);
        //            manSourceVertexCopy.CutRemainingUnchosenEdges(mediatorCopy);
        //            var womanSourceVertexCopy =
        //                mediatorCopy.GetVertexNodeStateContextByPosition(chosenWomanVertex.Position);
        //            womanSourceVertexCopy.CutRemainingUnchosenEdges(mediatorCopy);

        //            var manVertexTrailCopy2 = manVertexTrailCopy.Copy<V>(vertexNodeStateFactory); // these must be copied at the beginning of the loop
        //            var womanVertexTrailCopy2 = womanVertexTrailCopy.Copy<V>(vertexNodeStateFactory);

        //            Visit(mediatorCopy, manTargetVertexCopy, womanTargetVertexCopy, startingVertexPosition, FirstStepTaken.Yes, manVertexTrailCopy2, womanVertexTrailCopy2);

        //            //}
        //        });
        //    }
        //}
        public void Visit(NodeStateContextMediator<E, V> mediator,
            int startingVertexPosition)
        {
            Visit(mediator, null, null, startingVertexPosition, FirstStepTaken.No, new List<V>(), new List<V>());
        }
        
        public void Visit(NodeStateContextMediator<E, V> mediator,
            VertexNodeStateContext chosenManVertex,
            VertexNodeStateContext chosenWomanVertex,
            int startingVertexPosition, FirstStepTaken firstStepTaken, List<V> manVertexTrail, List<V> womanVertexTrail)
        {
            #region initialStep
            if (firstStepTaken == FirstStepTaken.No)
            {

                var startingVertexContext = mediator.GetVertexNodeStateContextByPosition(startingVertexPosition);
                mediator.NodeStateContextContainerFacade.ChooseVertexAsOrigin(startingVertexContext);
                //startingVertexContext.ChooseAsOrigin();
                startingVertexContext = mediator.GetVertexNodeStateContextByPosition(startingVertexPosition);
                
                var edgeNodeStateFactory = EdgeNodeStateContextFlyweightFactory<E>.GetInstance;
                var vertexNodeStateFactory = VertexNodeStateContextFlyweightFactory<V>.GetInstance;
                var facadeFactory = new NodeStateContextContainerFacadeFlyweightFactory<E, V>(edgeNodeStateFactory, vertexNodeStateFactory);
                /* Now that the state is changed to origin, I need the origin
                 * to return a list of incident unchosen edges.
                 * Note: The elements returned by the DecideNext(..) method of a state
                 *      depend upon that state.
                 * Then I must generate the marriage list.
                */
                var marriageList = GetVertexNodeStateContextMarriageListFirst(mediator, startingVertexContext);
                foreach (var marriage in marriageList)
                {
                    //Parallel.ForEach(marriageList, marriage =>
                    //{
                    var manVertexTrailCopy = manVertexTrail.Copy<V>(vertexNodeStateFactory);
                    var womanVertexTrailCopy = womanVertexTrail.Copy<V>(vertexNodeStateFactory);
                    var mediatorCopy = mediator.Copy(facadeFactory);

                    var manEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item1.Position);
                    var womanEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item2.Position);
                    // performance impact of all the copying may be significant.
                    // this may be where making contexts flyweight will improve performance much.
                    // In that case, we would need to change state at the context level
                    //      or at least inject the context (and a factory?) into the nodeStateContext.
                    mediatorCopy.NodeStateContextContainerFacade.ChooseEdgeAsMale(manEdgeCopy);
                    manEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item1.Position);
                    //manEdgeCopy.ChooseAsMale();
                    var manTargetVertex =
                        manEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    mediatorCopy.NodeStateContextContainerFacade.ChooseVertexAsMale(manTargetVertex);
                    //manTargetVertex.ChooseAsMale();
                    manTargetVertex =
                        manEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    
                    manVertexTrailCopy.Add(manTargetVertex);

                    mediatorCopy.NodeStateContextContainerFacade.ChooseEdgeAsFemale(womanEdgeCopy);
                    womanEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item2.Position);
                    // womanEdgeCopy.ChooseAsFemale(); // We can just choose the female here because we already ensured that the only marriages that exist are ones where the man's choice will not cause the woman's choice to orphan a vertex.
                    var womanTargetVertex = womanEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    mediatorCopy.NodeStateContextContainerFacade.ChooseVertexAsFemale(womanTargetVertex);
                    //womanTargetVertex.ChooseAsFemale();
                    womanVertexTrailCopy.Add(womanTargetVertex);
                    // Since this is the first step, the edges that must be cut are the ones that are incident to the sourceVertex but are still Unchosen.

                    // Any remaining unchosen edges that are incident to the originVertex must be cut.
                    var originVertexCopy = mediatorCopy.GetVertexNodeStateContextByPosition(startingVertexPosition);
                    originVertexCopy.CutRemainingUnchosenEdges2(mediatorCopy); // And thus they are cut.

                    var manVertexTrailCopy2 = manVertexTrailCopy.Copy<V>(vertexNodeStateFactory);
                    var womanVertexTrailCopy2 = womanVertexTrailCopy.Copy<V>(vertexNodeStateFactory);
                    Visit(mediatorCopy, manTargetVertex, womanTargetVertex, startingVertexPosition, FirstStepTaken.Yes, manVertexTrailCopy2, womanVertexTrailCopy2);
                    // I need a method on the EdgeNodeStateContext that returns the incident vertex
                    // that has specified state (of UnchosenVertexNodeState).


                    // I need to copy the facade here.
                    // Then I can change the stateContexts for the appropriate ones

                }
                //});
            }
            #endregion
            if (firstStepTaken == FirstStepTaken.Yes)
            {
                // from the manTarget and womanTarget, we need to select the list of UnvisitedEdgeNodeStateContexts.
                // We must check if any cut orphans a target vertex.
                // Cuts that create orphans must be processed first.

                // Get all the unchosen edges that don't orphan vertex?
                // It is important to determine that the choice of the man does not
                //      orphan the woman's vertex after cuts are made.

                var unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault = chosenManVertex.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(mediator);
                //var unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault = chosenWomanVertex.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(mediator);
                // would a cut to any of these unchosenEdgeNodes cause an orphan?
                // If count == 0, then we can choose all of these edges.
                // If count == 1, then we can choose only one of these edges.
                // If count >= 2, then neither of these edges can be chosen without creating an orphan.

                VertexNodeStateContextFlyweightFactory<V> vertexNodeStateFactory;
                NodeStateContextContainerFacadeFlyweightFactory<E, V> facadeFactory;
                var marriageList = GetVertexNodeStateContextMarriageListSubsequent(mediator, chosenManVertex, chosenWomanVertex, startingVertexPosition, manVertexTrail, womanVertexTrail, unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault, out vertexNodeStateFactory, out facadeFactory);
                Parallel.ForEach(marriageList, marriage =>
                {
                    #region comments
                    //foreach (var marriage in marriageList)
                    //{


                    // The marriageList contains the list of edge pairs that we may visit/choose.
                    // At this point, since we are beyond the first step, when we choose an edge,
                    // the source chosen vertex will have two chosen incident edges, and any 
                    // remaining unchosen incident edges need to be cut.
                    // If that cut produces an orphan, then we cannot make the cut.
                    // So if that cut produces an orphan, then this marriage cannot be chosen.

                    // How would we determine (in advance) if a particular marriage pair choice would result in
                    // a cut that would create an orphan?

                    /*We would need to go back to where we are adding marriages to the list.
                     Then, when we are about to add a manVertex to the marriage,
                     * the choice of the edge between the sourceMan and the marriage's targetMan
                     * would induce a cut in the other unchosen edges incident to the sourceMan.
                     * 
                     * Is there a way that we could infer these cases (before creating the marriages)
                     * that would be more efficient than just doing it here?
                     */
                    // item1 is the man, item2 is the woman

                    /* At this point, we need to copy the mediator, choose the manEdge, perform cuts to unchosen
                     * edges ,
                    */
#endregion
                    var mediatorCopy = mediator.Copy(facadeFactory);

                    var manEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item1.Position);
                    var womanEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item2.Position);
                    // performance impact of all the copying may be significant.
                    // this may be where making contexts flyweight will improve performance much.
                    // In that case, we would need to change state at the context level
                    //      or at least inject the context (and a factory?) into the nodeStateContext.

                    // I need a way to choose the vertex.

                    var manVertexTrailCopy = manVertexTrail.Copy<V>(vertexNodeStateFactory); // these must be copied at the beginning of the loop
                    var womanVertexTrailCopy = womanVertexTrail.Copy<V>(vertexNodeStateFactory); // to prevent modifying the list across loop iterations.
                    mediatorCopy.NodeStateContextContainerFacade.ChooseEdgeAsMale(manEdgeCopy);
                    //manEdgeCopy.ChooseAsMale();
                    manEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item1.Position);
                    var manTargetVertexCopy =
                        manEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    mediatorCopy.NodeStateContextContainerFacade.ChooseVertexAsMale(manTargetVertexCopy);
                    manTargetVertexCopy =
                        manEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    //manTargetVertexCopy.ChooseAsMale();
                    manVertexTrailCopy.Add(manTargetVertexCopy);

                    // These women should already be compatable with the men UNLESS the woman's edge forms a closure for a cycle
                    // in which case at least one of the womanEdge's vertices should already be NOT unchosen (i.e. chosen as a man).
                    var womanVertexTuple = womanEdgeCopy.GetIncidentVerticesAsTuple(mediatorCopy);
                    var womanVertex1IsUnchosen = womanVertexTuple.Item1.State.Equals(UnchosenVertexNodeState.Instance);
                    var womanVertex2IsUnchosen = womanVertexTuple.Item2.State.Equals(UnchosenVertexNodeState.Instance);
                    //if (!womanVertex1IsUnchosen || !womanVertex2IsUnchosen)
                    //{
                    //    Console.WriteLine("Test");
                    //    //continue; // This continue operation takes us out of this loop instance because we are done here for this marriage.
                    //}
                    mediatorCopy.NodeStateContextContainerFacade.ChooseEdgeAsFemale(womanEdgeCopy);
                    womanEdgeCopy = mediatorCopy.GetEdgeNodeStateContextByPosition(marriage.Item2.Position);
                    //womanEdgeCopy.ChooseAsFemale();
                    var womanTargetVertexCopy = womanEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    if (womanTargetVertexCopy == null)
                    {
                        //Console.WriteLine("One of womanEdge's vertices has already been chosen, so this womanEdge will close the cycle.");
                        // We must write the result to the console and continue.
                        WritePathIDToConsoleFaster(startingVertexPosition,
                            manVertexTrailCopy,
                            womanVertexTrailCopy, mediatorCopy);
                        return; // return is used for the parallel foreach loop.
                        //continue; // continue is used for the regular foreach loop.
                    }
                    // the above method call will fail if the womanEdge closes a cycle.
                    //womanTargetVertexCopy.ChooseAsFemale();
                    mediatorCopy.NodeStateContextContainerFacade.ChooseVertexAsFemale(womanTargetVertexCopy);
                    womanTargetVertexCopy = womanEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(mediatorCopy);
                    womanVertexTrailCopy.Add(womanTargetVertexCopy);
                    // Since this is the first step, the edges that must be cut are the ones that are incident to the sourceVertex but are still Unchosen.

                    // Any remaining unchosen edges that are incident to the originVertex must be cut.
                    var manSourceVertexCopy = mediatorCopy.GetVertexNodeStateContextByPosition(chosenManVertex.Position);
                    
                    manSourceVertexCopy.CutRemainingUnchosenEdges2(mediatorCopy);
                    var womanSourceVertexCopy =
                        mediatorCopy.GetVertexNodeStateContextByPosition(chosenWomanVertex.Position);
                    womanSourceVertexCopy.CutRemainingUnchosenEdges2(mediatorCopy);

                    var manVertexTrailCopy2 = manVertexTrailCopy.Copy<V>(vertexNodeStateFactory); // these must be copied at the beginning of the loop
                    var womanVertexTrailCopy2 = womanVertexTrailCopy.Copy<V>(vertexNodeStateFactory);

                    Visit(mediatorCopy, manTargetVertexCopy, womanTargetVertexCopy, startingVertexPosition, FirstStepTaken.Yes, manVertexTrailCopy2, womanVertexTrailCopy2);

                    //}
                });
            }
        }

        private static List<Tuple<EdgeNodeStateContext, EdgeNodeStateContext>> GetVertexNodeStateContextMarriageListSubsequent(NodeStateContextMediator<E, V> mediator,
            VertexNodeStateContext chosenManVertex, VertexNodeStateContext chosenWomanVertex, int startingVertexPosition,
            List<V> manVertexTrail, List<V> womanVertexTrail, List<E> unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault,
            out VertexNodeStateContextFlyweightFactory<V> vertexNodeStateFactory,
            out NodeStateContextContainerFacadeFlyweightFactory<E, V> facadeFactory)
        {
            var marriageList = new List<Tuple<EdgeNodeStateContext, EdgeNodeStateContext>>();
            marriageList.Clear();

            var edgeNodeStateFactory = EdgeNodeStateContextFlyweightFactory<E>.GetInstance;
            vertexNodeStateFactory = VertexNodeStateContextFlyweightFactory<V>.GetInstance;
            facadeFactory = new NodeStateContextContainerFacadeFlyweightFactory<E, V>(edgeNodeStateFactory,
                vertexNodeStateFactory);

            for (int i = 0; i < unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault.Count; i++)
            {
                var man = unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault[i];
                // We must determine if choosing this man will affect our possible choices of women.

                var tempMediatorCopy = mediator.Copy(facadeFactory);
                var tempManEdgeCopy = tempMediatorCopy.GetEdgeNodeStateContextByPosition(man.Position);
                var tempManEdgeCopyVertices = tempManEdgeCopy.GetIncidentVerticesAsTuple(tempMediatorCopy);
                //if ((tempManEdgeCopyVertices.Item1.Position.Equals(9) || tempManEdgeCopyVertices.Item1.Position.Equals(10))
                //    && ((tempManEdgeCopyVertices.Item2.Position.Equals(9) || tempManEdgeCopyVertices.Item2.Position.Equals(10))))
                //{
                //    Console.Write("This is where we must inspect");
                //}

                var tempManEdgeIncidentUnchosenVertices =
                    tempManEdgeCopy.GetIncidentUnchosenVertexNodeStateContext(tempMediatorCopy);
                if (tempManEdgeIncidentUnchosenVertices == null)
                {
                    // Then this means we have found an edge that forms a closure and cannot be chosen.
                    // Perhaps we can just cut it.
                    // We really probably should log this to the console.
                    WritePathIDToConsoleFaster(startingVertexPosition,
                        manVertexTrail,
                        womanVertexTrail, mediator);
                    continue; // Regardless, we need to skip to the next possible man edge.
                }
                var tempManTargetVertexCopy =
                    tempMediatorCopy.GetVertexNodeStateContextByPosition(tempManEdgeIncidentUnchosenVertices.Position);
                tempMediatorCopy.NodeStateContextContainerFacade.ChooseEdgeAsMale(tempManEdgeCopy);
                //tempManEdgeCopy = tempMediatorCopy.GetEdgeNodeStateContextByPosition(man.Position);
                //tempManEdgeCopy.ChooseAsMale();
                tempMediatorCopy.NodeStateContextContainerFacade.ChooseVertexAsMale(tempManTargetVertexCopy);
                //tempManTargetVertexCopy =
                //    tempMediatorCopy.GetVertexNodeStateContextByPosition(tempManEdgeIncidentUnchosenVertices.Position);
                //tempManTargetVertexCopy.ChooseAsMale();
                var tempManSourceVertexCopy =
                    tempMediatorCopy.GetVertexNodeStateContextByPosition(chosenManVertex.Position);
                tempManSourceVertexCopy.CutRemainingUnchosenEdges2(tempMediatorCopy);

                var tempWomanSourceVertexCopy = tempMediatorCopy.GetVertexNodeStateContextByPosition(chosenWomanVertex.Position);

                var unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault =
                    tempWomanSourceVertexCopy.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(tempMediatorCopy);
                var manTrail = mediator.GetEdgeNodesWithStateChosenMale.ToList();
                    // What's faster: dynamic lookup, or copy to method parameters?
                var womanTrail = mediator.GetEdgeNodesWithStateChosenFemale.ToList();
                    // We must use the mediator because the copy contains edges with temporary state changes.

                for (int j = 0; j < unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault.Count; j++)
                {
                    //var man = unchosenEdgeNodesIncidentToManThatCutWouldOrphanOrDefault[i];
                    var woman = unchosenEdgeNodesIncidentToWomanThatCutWouldOrphanOrDefault[j];
                    if (man.Position != woman.Position)
                    {
                        var manVertices = man.GetIncidentVerticesAsTuple(tempMediatorCopy);
                            // Should I ensure that only one hasn't been visited?
                        // Or should I ensure that both haven't been visited?
                        var womanVertices = woman.GetIncidentVerticesAsTuple(tempMediatorCopy);
                        // This is where we are resolving conflicts by only adding elements to the marriageList
                        // that have not already been visited.
                        // We actually could simplify these checks.
                        var manEdgeVertexTupleList = new List<Tuple<V, V>>();
                        var womanEdgeVertexTupleList = new List<Tuple<V, V>>();
                        foreach (var manEdgeInTrail in manTrail)
                        {
                            var edgeVertices = manEdgeInTrail.GetIncidentVerticesAsTuple(tempMediatorCopy);
                            manEdgeVertexTupleList.Add(edgeVertices);
                        }
                        foreach (var womanEdgeInTrail in womanTrail)
                        {
                            var edgeVertices = womanEdgeInTrail.GetIncidentVerticesAsTuple(tempMediatorCopy);
                            womanEdgeVertexTupleList.Add(edgeVertices);
                        }


                        var manTrailContainsMan = manTrail.Any(t => t.Position == man.Position);
                        var womanTrailContainsWoman = womanTrail.Any(t => t.Position == woman.Position);
                        var manTrailContainsWoman = manTrail.Any(t => t.Position == woman.Position);
                        var womanTrailContainsMan = womanTrail.Any(t => t.Position == man.Position);
                        //if (!manVerticesAreAlreadyVisited && !womanVerticesAreAlreadyVisited)
                        if (!manTrailContainsMan && !womanTrailContainsWoman && !manTrailContainsWoman && !womanTrailContainsMan)
                        {
                            // I need a way to check: where if man is chosen, are any of woman's incident target vertices orphaned?
                            // If so, then these must be chosen.
                            // Get original man and woman contexts.
                            var originalManEdge = mediator.GetEdgeNodeStateContextByPosition(man.Position);
                            var originalManEdgeVertices =
                                originalManEdge.GetIncidentVerticesAsTuple(mediator);

                            var originalWomanEdge = mediator.GetEdgeNodeStateContextByPosition(woman.Position);

                            var originalWomanEdgeVertices =
                                originalWomanEdge.GetIncidentVerticesAsTuple(mediator);
                            //if ((originalManEdge.Position == 15 && originalWomanEdge.Position == 18) ||
                            //(originalManEdge.Position == 18 && originalWomanEdge.Position == 15))
                            //{
                            //    Console.WriteLine("Here is a problem.");
                            //}

                            var marriage = new Tuple<EdgeNodeStateContext, EdgeNodeStateContext>(originalManEdge,
                                originalWomanEdge);
                            marriageList.Add(marriage);
                        }
                    }
                    else
                    // In this case, because both man and woman have reached the same vertex, we have the closure of a cycle.
                    {
                        Console.WriteLine("Closure on vertex {0}", man.Position);
                            // note: man.Position == woman.Position in this case.
                        // Then we should write the members of the two trails to the console, like this:
                        // womanTrailReverse = womanTrail.Reverse();
                        // originVertex, manTrail[0], manTrail[1], ..., manTrail[n], man.Position, womanTrailReverse[0], womanTrailReverse[1], ...,
                        // womanTrailReverse[m].
                        //WritePathIDToConsole(originVertex, manTrail, womanTrail, man);
                        //WritePathIDToConsoleFaster(startingVertexPosition, manTrail, womanTrail, man, mediator);
                    }
                }
            }
            return marriageList;
        }

        private static List<Tuple<EdgeNodeStateContext, EdgeNodeStateContext>> GetVertexNodeStateContextMarriageListFirst(NodeStateContextMediator<E, V> mediator,
            V startingVertexContext)
        {
            var adjacentEdgeStateContexts = startingVertexContext.GetIncidentEdgeNodeStateContexts(mediator);
            var marriageList = new List<Tuple<EdgeNodeStateContext, EdgeNodeStateContext>>();
            for (int i = 0; i <= adjacentEdgeStateContexts.Count - 1; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    var man = adjacentEdgeStateContexts[i];
                    var woman = adjacentEdgeStateContexts[j];
                    if (man.Position != woman.Position)
                    {
                        var marriage = new Tuple<EdgeNodeStateContext, EdgeNodeStateContext>(man, woman);
                        marriageList.Add(marriage);
                    }
                }
            }
            return marriageList;
        }

        ///// <summary>
        ///// For this method call, this overload assumes that the last man is not included on the manTrail. So,  
        ///// the man parameter should be the last man edge that we would intend to choose to complete the cycle.
        ///// </summary>
        ///// <param name="originVertexPosition"></param>
        ///// <param name="manTrail"></param>
        ///// <param name="womanTrail"></param>
        ///// <param name="man"></param>
        ///// <param name="mediator"></param>
        //private static void WritePathIDToConsoleFaster(int originVertexPosition, List<E> manTrail, List<E> womanTrail,
        //    E man, NodeStateContextMediator<E, V> mediator)
        //{
        //    // foreach edge, get distinct chosen vertexPositions
        //    var womanVertexPositions = new List<int>();
        //    foreach (var edgeNodeStateContext in womanTrail)
        //    {
        //        var incidentVertices = edgeNodeStateContext.GetIncidentVertices(mediator);
        //        foreach (var vertexNodeStateContext in incidentVertices)
        //        {
        //            womanVertexPositions.Add(vertexNodeStateContext.Position);
        //        }
        //    }
        //    var womanPositionsDistinct = womanVertexPositions.Distinct();
        //    var womanPositionsReversed = womanPositionsDistinct.Reverse();
        //    var manVertexPositions = new List<int>();
        //    foreach (var edgeNodeStateContext in manTrail)
        //    {
        //        var incidentVertices = edgeNodeStateContext.GetIncidentVertices(mediator);
        //        foreach (var vertexNodeStateContext in incidentVertices)
        //        {
        //            manVertexPositions.Add(vertexNodeStateContext.Position);
        //        }
        //    }
        //    var manPositionsDistinct = manVertexPositions.Distinct();

        //    var sb = new StringBuilder((manTrail.Count + womanTrail.Count) * 3);
        //    sb.Append(originVertexPosition + ", ");
        //    foreach (var manItem in manPositionsDistinct)
        //    {
        //        sb.Append(manItem + ", ");
        //    }
        //    sb.Append(man.Position + ", ");
        //    foreach (var womanPosition in womanPositionsReversed) // skip the first because it should be the same as the last man.
        //    {
        //        sb.Append(womanPosition + ", ");
        //    }
        //    sb.Append(originVertexPosition);
        //    Console.WriteLine(sb.ToString());
        //}
        private static void WritePathIDToConsoleFaster(int originVertexPosition, List<V> manTrail, List<V> womanTrail,
            NodeStateContextMediator<E, V> mediator)
        {
            //if (manTrail.Count > 9)
            //{
                
            
            // foreach edge, get distinct chosen vertexPositions
            var womanVertexPositions = new List<int>();
            foreach (var vertexNodeStateContext in womanTrail)
            {
                 womanVertexPositions.Add(vertexNodeStateContext.Position);
            }
            var womanPositionsDistinct = womanVertexPositions.Distinct();
            var womanPositionsReversed = womanPositionsDistinct.Reverse();
            var manVertexPositions = new List<int>();
            foreach (var vertexNodeStateContext in manTrail)
            {
                 manVertexPositions.Add(vertexNodeStateContext.Position);
            }
            var manPositionsDistinct = manVertexPositions.Distinct();

            var sb = new StringBuilder((manTrail.Count + womanTrail.Count) * 3);
            sb.Append(originVertexPosition + ", ");
            foreach (var manItem in manPositionsDistinct)
            {
                sb.Append(manItem + ", ");
            }
            foreach (var womanPosition in womanPositionsReversed) // skip the first because it should be the same as the last man.
            {
                sb.Append(womanPosition + ", ");
            }
            sb.Append(originVertexPosition);
            Console.WriteLine(sb.ToString());

            //}
        }
    }
}
