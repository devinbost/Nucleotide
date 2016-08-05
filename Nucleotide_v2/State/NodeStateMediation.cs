namespace Nucleotide_v2.State
{
    public class NodeStateMediation<T>
    {
        INodeState<T> NodeState { get; set; }
        Node<T> Node { get; set; } 
    }
}