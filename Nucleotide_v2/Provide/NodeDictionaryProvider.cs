using System;
using System.Collections.Generic;
using System.Linq;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2.Provide
{
    [Serializable]
    public class NodeDictionaryProvider<T> : INodeDataProvider<T>
    {
        public Dictionary<int, Node<T>> Dictionary { get; set; }
        public NodeDictionaryProvider()
        {
            if (Dictionary == null)
            {
                this.Dictionary = new Dictionary<int, Node<T>>();
            }
        }

        public IDictionary<int, Node<T>> Elements
        {
            get { return this.Dictionary; }
        }

        public Node<T> Select(int position)
        {
            return this.Dictionary[position];
        }

        /// <summary>
        /// This method could throw an error if the element already exists.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="element"></param>
        public void Add(int position, Node<T> element)
        {
            this.Dictionary.Add(position, element);
        }
        /// <summary>
        /// This method could throw an error if the element doesn't exist yet.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="element"></param>
        public void Update(int position, Node<T> element)
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