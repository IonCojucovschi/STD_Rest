
using Int.Core.Network;
using System.Collections.Generic;

namespace Core.Services.Response
{
    public interface IResponseWithMeta : IResponseService
    {
        IList<string> Errors { get; set; }
    }
}
