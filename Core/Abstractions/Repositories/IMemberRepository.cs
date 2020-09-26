using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstractions.Repositories;
using System.Threading.Tasks;

namespace Core.Abstractions.Repositories
{
    public interface IMemberRepository : IBaseRepository<Guid, Member, IMemberRepository>
    {
        Task<Member> GetByMemberId(Guid memberId);
    }
}
