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
    }
}
