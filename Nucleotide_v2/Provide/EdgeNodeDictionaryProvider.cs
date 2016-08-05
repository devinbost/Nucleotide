using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Provide
{
    [Serializable]
    public class EdgeNodeDictionaryProvider : NodeDictionaryProvider<string>
    {
        public new Dictionary<int, EdgeNode> Dictionary { get; set; }
        public EdgeNodeDictionaryProvider()
        {
            if (Dictionary == null)
            {
                this.Dictionary = new Dictionary<int, EdgeNode>();
            }
        }

        public new IDictionary<int, EdgeNode> Elements
        {
            get { return this.Dictionary; }
        }

        public new EdgeNode Select(int position)
        {
            return this.Dictionary[position];
        }

        public EdgeNode GetEdgeNodeByEdgePosition(int position)
        {
            if (this.Dictionary.ContainsKey(position))
            {
                return Select(position);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// This method adds the element if it doesn't exist.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="element"></param>
        public void Add(int position, EdgeNode element)
        {
            if (!this.Dictionary.ContainsKey(position))
            {
                this.Dictionary.Add(position, element);
            }
        }
        /// <summary>
        /// This method could throw an error if the element doesn't exist yet.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="element"></param>
        public void Update(int position, EdgeNode element)
        {
            if (!this.Dictionary.ContainsKey(position))
            {
                this.Dictionary.Add(position, element);
            }
            else
            {
                this.Dictionary[position] = element;
            }
        }

        /// <summary>
        /// There's probably a more efficient way to do this.
        /// We're also assuming that the last element always has largest key.
        /// </summary>
        [Obsolete("Needs to be tested.")]
        public new int NextPosition
        {
            get { return this.Dictionary.Last().Key + 1; }
        }
    }
}
