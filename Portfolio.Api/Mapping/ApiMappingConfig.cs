using Mapster;
using Portfolio.Api.Contracts.Portfolio;
using Portfolio.Application.Portfolio;

namespace Portfolio.Api.Mapping;

public class ApiMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePortfolioRequest, CreatePortfolioCommand>();
    }
}
