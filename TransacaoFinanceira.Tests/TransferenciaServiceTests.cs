using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using TransacaoFinanceira.Services;
using TransacaoFinanceira.Repositories;
using TransacaoFinanceira.Entities;

public class TransferenciaServiceTests
{
    private TransferenciaService CriarService(Mock<IContaRepository> repoMock)
    {
        var loggerMock = new Mock<ILogger<TransferenciaService>>();
        return new TransferenciaService(repoMock.Object, loggerMock.Object);
    }

    [Fact]
    public void Deve_realizar_transferencia_com_sucesso()
    {
        // Arrange
        var origem = new ContaSaldo(938485762, 1000);
        var destino = new ContaSaldo(347586970, 500);

        var repoMock = new Mock<IContaRepository>();

        repoMock.Setup(r => r.Obter(938485762)).Returns(origem);
        repoMock.Setup(r => r.Obter(347586970)).Returns(destino);

        var service = CriarService(repoMock);

        // Act
        var result = service.Transferir(1, 938485762, 347586970, 50);

        // Assert
        Assert.True(result.Sucesso);
        Assert.Equal(950, origem.Saldo);
        Assert.Equal(550, destino.Saldo);
    }

    [Fact]
    public void Deve_falhar_quando_saldo_insuficiente()
    {
        // Arrange
        var origem = new ContaSaldo(1, 10);
        var destino = new ContaSaldo(2, 500);

        var repoMock = new Mock<IContaRepository>();

        repoMock.Setup(r => r.Obter(1)).Returns(origem);
        repoMock.Setup(r => r.Obter(2)).Returns(destino);

        var service = CriarService(repoMock);

        // Act
        var result = service.Transferir(1, 1, 2, 999);

        // Assert
        Assert.False(result.Sucesso);
        Assert.Equal(10, origem.Saldo);
        Assert.Equal(500, destino.Saldo);
    }

    [Fact]
    public void Deve_falhar_quando_conta_invalida()
    {
        // Arrange
        var repoMock = new Mock<IContaRepository>();

        repoMock.Setup(r => r.Obter(It.IsAny<long>()))
                .Returns((ContaSaldo)null);

        var service = CriarService(repoMock);

        // Act
        var result = service.Transferir(1, 999, 888, 100);

        // Assert
        Assert.False(result.Sucesso);
    }

}