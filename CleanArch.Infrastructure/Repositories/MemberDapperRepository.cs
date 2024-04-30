using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using Dapper;
using System.Data;

namespace CleanArch.Infrastructure.Repositories;
public class MemberDapperRepository : IMemberDapperRepository
{
    private readonly IDbConnection _db;

    public MemberDapperRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<Member?> GetMemberById(int memberId)
    {
        string query = "SELECT * FROM Members WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<Member>(query, new { Id = memberId });
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
        string query = "SELECT * FROM Members";
        return await _db.QueryAsync<Member>(query);
    }
}
