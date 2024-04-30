using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions;
public interface IMemberRepository
{
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int memberId);
    Task<Member> GetMemberById(int memberId);
}
