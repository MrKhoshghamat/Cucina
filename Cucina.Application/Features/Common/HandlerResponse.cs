namespace Cucina.Application.Features.Common;

public class HandlerResponse<TData>
{
    public bool IsSucceed { get; set; }
    public string? Message { get; set; }
    public TData? Data { get; set; }
}