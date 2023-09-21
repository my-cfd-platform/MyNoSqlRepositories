namespace MyNoSqlRepositories.Abstraction.Trading.BalanceOperations;

public enum BalanceUpdateOperationType
{
    Deposit,
    Withdraw,
    BalanceCorrection,
    BonusDeposit,
    BonusWithdrawal,
    BonusCorrection,
    InactivityFee
}