using System.Collections.Generic;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2.Provide
{
    /// <summary>
    /// This Provider is responsible for tracking the actual storage, retrieval and maintenance of the actual elements
    /// of data. 
    /// </summary>
    public interface IVertexDataProvider
    {
        IDictionary<int, IAdjacencyDirectableVisitable> Elements { get; }
        void Delete(int position);
        IAdjacencyDirectableVisitable Select(int position);
        void Add(int position, IAdjacencyDirectableVisitable element);
        void Update(int position, IAdjacencyDirectableVisitable element);
        //void Delete(int position);
    }
    
}
