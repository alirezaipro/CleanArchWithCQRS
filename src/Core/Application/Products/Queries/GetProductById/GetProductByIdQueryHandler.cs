using System.Data;
using Application.Abstractions.Messaging;
using Dapper;
using Domain.Exceptions;

namespace Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResponseDto>
{
    private readonly IDbConnection _dbConnection;

    public GetProductByIdQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<GetProductByIdResponseDto> Handle(GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        string query = "SELECT Id,Title,Description,Tags,Price FROM PRODUCTs WHERE Id = @Id";

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Id", request.Id);

        var result =
            await _dbConnection.QueryFirstOrDefaultAsync<GetProductByIdResponseDto>(query, parameters);

        if (result == null)
            throw new ProductNotFoundException(request.Id.ToString());

        return result;
    }
}