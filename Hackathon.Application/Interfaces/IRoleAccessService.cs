namespace Hackathon.Application.Interfaces
{
    public interface IRoleAccessService
    {
        bool HasAccess(int roleId, string route);
    }
}