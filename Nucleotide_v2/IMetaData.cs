using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2
{
    public interface IMetaData
    {
        string Type { get; set; }
        string GetDataAsJsonString();
        T DeepMapToType<T>();
        //string Data { get; set; }
    }
}
