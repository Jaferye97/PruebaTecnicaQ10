using Domain.Model.Constants;

namespace Domain.Model
{
    public class BaseEntityy<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
