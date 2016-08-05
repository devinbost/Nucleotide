using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2.Provide
{
    [Serializable]
    public class VertexDictionaryProvider : IVertexDataProvider 
    {
        public Dictionary<int, IAdjacencyDirectableVisitable> Dictionary { get; set; }
        public VertexDictionaryProvider()
        {
            if (Dictionary == null)
            {
                this.Dictionary = new Dictionary<int, IAdjacencyDirectableVisitable>();
            }
        }

        public IDictionary<int, IAdjacencyDirectableVisitable> Elements
        {
            get { return this.Dictionary; }
        }

        public IAdjacencyDirectableVisitable Select(int position)
        {
            return this.Dictionary[position];
        }
        public void Delete(int position)
        {
            if (this.Dictionary.ContainsKey(position))
            {
                this.Dictionary.Remove(position);
            }
        }

        /// <summary>
        /// This method could throw an error if the element already exists.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="element"></param>
        public void Add(int position, IAdjacencyDirectableVisitable element)
        {
            this.Dictionary.Add(position, element);
        }
        /// <summary>
        /// This method could throw an error if the element doesn't exist yet.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="element"></param>
        public void Update(int position, IAdjacencyDirectableVisitable element)
        {
           this.Dictionary[position] = element;
        }

        /// <summary>
        /// There's probably a more efficient way to do this.
        /// We're also assuming that the last element always has largest key.
        /// </summary>
        [Obsolete("Needs to be tested.")]
        public int NextPosition
        {
            get { return this.Dictionary.Last().Key + 1; }
        }
    }
}
