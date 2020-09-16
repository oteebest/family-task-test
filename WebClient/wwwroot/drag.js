

function DropMe(dotnetHelper) {

    const taskItems = document.querySelectorAll(".task-item");

    taskItems.forEach(u => u.addEventListener("drag", Drag))

    let taskId;

    function Drag(e) {
        taskId = e.target.id;
    }

    const menuItems = document.querySelectorAll(".menu-item");

    menuItems.forEach(u => u.addEventListener("drop", Drop));

    async function Drop(e) {

        console.log("Drop Current Target", e.currentTarget);
        console.log("Drop Target", e.target);
        const memberId = e.target.id;

        await dotnetHelper.invokeMethodAsync("AssignTaskToMember", taskId.toString(), memberId.toString())
            

    }

    menuItems.forEach(u => u.addEventListener("dragover", allowDrop));

    function allowDrop(e) {
        console.log("Allow drop");
        e.preventDefault();
    }

}
    
