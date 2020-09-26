using Domain.Commands;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Exentions
{
    public static class FamilyModelExtentions
    {
        public static FamilyMember Map(this MemberVm vm)
        {
            if (vm == null)
                return null;

            var familyMemberModel = new FamilyMember
            {
                id = vm.Id,
                avtar = vm.Avatar,
                 email = vm.Email,
                  firstname = vm.FirstName,
                   lastname = vm.LastName,
                    role = vm.Roles,

            };

            return familyMemberModel;

        }

        public static FamilyMember Map(this CreateMemberCommandResult result)
        {
            if (result == null || result.Payload == null)
                return null;

            var payload = result.Payload;

            var familyMemberModel = new FamilyMember
            {
                id = payload.Id,
                avtar = payload.Avatar,
                email = payload.Email,
                firstname = payload.FirstName,
                lastname = payload.LastName,
                role = payload.Roles,

            };

            return familyMemberModel;

        }

        public static CreateMemberCommand Map(this FamilyMember member)
        {
            if (member == null )
                return null;


            var command = new CreateMemberCommand
            {
                     Avatar = member.avtar,
                     Email = member.email,
                     FirstName = member.firstname,
                     LastName = member.lastname,
                     Roles = member.role,
            };

            return command;

        }

    }
}
