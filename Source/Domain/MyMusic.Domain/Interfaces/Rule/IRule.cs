namespace MyMusic.Domain.Interfaces.Rule
{
    public interface IRule<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
