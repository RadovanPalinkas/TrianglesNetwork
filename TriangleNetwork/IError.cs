using System;

namespace TriangleNetwork
{
    public interface IError
    {
        void GetError(EnumErrors error);
        void GetError(EnumErrors error, Exception ex);
    }
}