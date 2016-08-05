using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Provide
{
    public interface INodeDataProvider<T>
    {
        IDictionary<int, Node<T>> Elements { get; }
        Node<T> Select(int position);
        void Add(int position, Node<T> element);
        void Update(int position, Node<T> element);
        //void Delete(int position);
    }
}
