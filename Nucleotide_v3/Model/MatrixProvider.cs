using System.Collections.Generic;

namespace Nucleotide_v3.Model
{
    public abstract class MatrixProvider
    {
         protected internal virtual Dictionary<int, Dictionary<int, bool>> Values { get; set; }
         protected internal abstract void UnsetVertices(int vertexPosition1, int vertexPosition2);
        /// <summary>
        /// This method deletes a vertex from the matrix (if the vertex exists).
        /// </summary>
        /// <param name="vertexPosition"></param>
         protected  internal virtual void Delete(int vertexPosition)
        {
            if (this.Values.ContainsKey(vertexPosition))
            {
                this.Values.Remove(vertexPosition);
            }
        }
         protected internal abstract void AddVertex(int vertexPosition);
        protected internal abstract bool IsVertexInMatrix(int vertexPosition);
         protected internal virtual int NextAvailableVertex { get { return Values.Count; } }
    }
}