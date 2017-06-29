namespace MathExpression.Contracts.Contract
{
    public interface IOperation
    {
        char Separator { get; }
        float Priority { get; }
        double Calculate(double args1, double args2);
    }
}
