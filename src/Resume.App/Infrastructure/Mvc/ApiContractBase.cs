using kr.bbon.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Resume.App.Infrastructure.Mvc;

public class ApiContractBase:ApiControllerBase
{
    public const string PRODUCE_MIMETYPE = "application/json";

    public ApiContractBase(IMediator mediator, ILogger logger)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    public ApiContractBase(ILogger logger) : this(null, logger)
    {

    }

    protected IMediator Mediator => mediator;
    protected ILogger Logger => logger;

    private readonly IMediator mediator;
    private readonly ILogger logger;
}