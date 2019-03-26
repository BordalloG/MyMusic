using MyMusic.Domain.Validation;
using MyMusic.Domain.Validation.Rules.MusicRules;

namespace MyMusic.Domain.Models.Validations
{
    public class MusicIsValidValidation : Validation<Music>
    {
        public MusicIsValidValidation()
        {
            base.AddRule(new ValidationRule<Music>(new AuthorLengthMustBeLowerThan100(), "O Nome do Autor da música não pode conter mais que 100 caracteres."));
            base.AddRule(new ValidationRule<Music>(new AuthorMustNotBeNullOrEmpty(), "O Nome do Autor da música não pode ser vazio."));
            base.AddRule(new ValidationRule<Music>(new TitleMustBeLowerThan100(), "O Título da música não pode conter mais que 100 caracteres."));
            base.AddRule(new ValidationRule<Music>(new TitleMustNotBeNullOrEmpty(), "O Título da música não pode ser vazio."));
            base.AddRule(new ValidationRule<Music>(new DurationMustNotBeNullOrEmpty(), "A duração da música não pode estar vazia."));
        }
    }
}
