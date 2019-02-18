using System;

namespace Actio.Common.Command
{
    public interface IAuthentication: ICommand
    {
         Guid UserId {get;set;}
    }
}