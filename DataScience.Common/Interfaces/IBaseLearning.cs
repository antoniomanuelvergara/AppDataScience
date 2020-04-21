using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common.Interfaces
{
    public interface IBaseLearning<T,E>
    {

        Result<T,E> Execute();
        Result<T, E> Learning();
        Result<T, E> Validation();
    }
}
