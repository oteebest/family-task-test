using Core.Abstractions.Repositories;
using Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MemberRepository : BaseRepository<Guid, Member, MemberRepository>, IMemberRepository
    {
        public MemberRepository(FamilyTaskContext context) : base(context)
        { }

        public async Task<Member> GetByMemberId(Guid memberId)
        {
            return await Context.Set<Member>().FirstAsync(u => u.MemberId == memberId);
        }

        IMemberRepository IBaseRepository<Guid, Member, IMemberRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        IMemberRepository IBaseRepository<Guid, Member, IMemberRepository>.Reset()
        {
            return base.Reset();
        }

       
    }
}
