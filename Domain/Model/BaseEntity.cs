using Domain.Model.Constants;

namespace Domain.Model
{
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
