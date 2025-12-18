using System.Data.Common;

namespace orderMicroService.Infrastructure.Connection
{
    public interface IDbConnectionFactory
    {
        DbConnection CreateConnection();

        string GetProviderName();
    }
}