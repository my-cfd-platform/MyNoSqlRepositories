namespace MyNoSqlRepositories.Abstraction.Candles;

public enum CandleType
{
    Minute,
    Hour,
    Day,
    Month,
}
    
public interface ICandleModel
{
    DateTime DateTime { get; }
    double Open { get; }
    double Close { get; }
    double High { get; }
    double Low { get; }
}