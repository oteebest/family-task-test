using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Exentions
{
    public static class TaskModelExtensions
    {
        public static TaskModel Map(this TaskVm vm)
        {
            if (vm == null)
                return null;

            var taskModel = new TaskModel
            {
                id = vm.Id,
                isDone = vm.IsComplete,
                text = vm.Subject,

            };

            if(vm.Member != null)
            {
                var member = vm.Member;

                taskModel.member = new FamilyMember
                {
                    avtar = member.Avatar,
                    email = member.Email,
                    firstname = member.FirstName,
                    lastname = member.LastName,
                    id = member.Id,
                    role = member.Roles
                };
            }

            return taskModel;


        }
    }
}
