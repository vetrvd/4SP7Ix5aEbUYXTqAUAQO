namespace MathExpression.Contracts.Contract
{
    /// <summary>
    /// Валидация входного выражения
    /// </summary>
    public interface IValidator
    {
        void ValidateInput(string input);
    }
}
