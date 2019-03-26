namespace MyMusic.Domain.Interfaces.Rule
{
    public interface IValidationRule<in TEntity>
    {
        
        string ErrorMessage { get; }
        bool Valid(TEntity entity);


    }
}
