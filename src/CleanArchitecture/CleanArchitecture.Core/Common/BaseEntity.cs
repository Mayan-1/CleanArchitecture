namespace CleanArchitecture.Core.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset? DateCreated { get; set; }
    public DateTimeOffset? DateModified { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }

}
