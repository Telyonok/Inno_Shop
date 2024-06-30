namespace ProductManagementService.Application.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, object id) : base($"Entity {name}({id}) was not found.") { }
    }
}
