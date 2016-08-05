using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.State;

namespace Nucleotide_v2
{
    /// <summary>
    /// This class is used to represent the state of an Edge, such as whether or not it is Chosen or Cut or Unchosen.
    /// This object is intended to decouple edge state from the edge objects to allow us to no longer need to clone the 
    /// edge objects to preserve object state. EdgeStates must be saved by the EdgeStateContext and keyed by the 
    /// DirectorID, WalkPathID, and  
    /// This state object implements the State design pattern.
    /// </summary>
    //public class EdgeNodeState : INodeState<string>
    //{
    //    public Node<string> Node { get; set; }
    //    public bool IsChosen { get; private set; }
    //    public bool IsCut { get; private set; }
    //    public bool IsUnchosen { get; private set; }
    //    public void ChangeState(INodeState<string> edgeState)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<INodeState<string>> GetNext()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //public class VertexNodeState : INodeState<string>
    //{
    //    public Node<string> Node { get; set; }
    //    public bool IsChosen { get; private set; }
    //    public bool IsCut { get; private set; }
    //    public bool IsUnchosen { get; private set; }
    //    public void ChangeState(INodeState<string> edgeState)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<INodeState<string>> GetNext()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
