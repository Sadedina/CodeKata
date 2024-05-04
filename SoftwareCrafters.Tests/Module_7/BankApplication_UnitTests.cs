using SoftwareCrafters.Module_7;

namespace SoftwareCrafters.Tests.Module_7;

public class BankApp_Tests
{
    [Test]
    public void Transfer_GivenClientATransfersAmountToClientB_ThenTransferShouldSucceed()
    {
        var mockAccountA = new Mock<IAccount>();
        var mockAccountB = new Mock<IAccount>();

        mockAccountA
            .Setup(a => a.Deposit(It.IsAny<decimal>()))
            .Verifiable();

        mockAccountB
            .Setup(a => a.Deposit(It.IsAny<decimal>()))
            .Verifiable();

        var transfer = 500;

        var app = new BankApplication();
        app.Transfer(mockAccountA.Object, mockAccountB.Object, transfer);

        mockAccountA.Verify(a => a.Withdrawal(transfer), Times.Once());
        mockAccountB.Verify(a => a.TransferDeposit(transfer), Times.Once());
    }

    [Test]
    public void Transfer_GivenClientAToAnExceedingAccount_ThenTransferShouldFail()
    {
        var mockAccountA = new Mock<IAccount>();
        var mockAccountB = new Mock<IAccount>();

        mockAccountA
            .Setup(a => a.Deposit(It.IsAny<decimal>()))
            .Verifiable();

        mockAccountB
            .Setup(a => a.Deposit(It.IsAny<decimal>()))
            .Verifiable();

        var transfer = 10;

        var app = new BankApplication();
        app.Transfer(mockAccountA.Object, mockAccountB.Object, transfer);

        mockAccountA.Verify(a => a.Withdrawal(transfer), Times.Once());
        mockAccountB.Verify(a => a.TransferDeposit(transfer), Times.Once());
    }
}