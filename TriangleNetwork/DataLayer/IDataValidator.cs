using System.Collections.Generic;

namespace TriangleNetwork.DataLayer
{
    public interface IDataValidator
    {
        List<string> GetValidatedLines();
    }
}