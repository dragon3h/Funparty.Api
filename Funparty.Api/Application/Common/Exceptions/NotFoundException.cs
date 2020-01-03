using System;

namespace Funparty.Api.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found")
        {
        }
    }
}
