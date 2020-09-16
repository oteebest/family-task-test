

function Drag(e) {

    console.log("Dragging", e.currentTarget);

    const dragTaskHiddenInput = document.querySelector("#dragTaskId");

    dragTaskHiddenInput.value = e.target.id;
}

function RefreshTaskForDraging() {

    const taskItems = document.querySelectorAll(".task-item");

    taskItems.forEach(u => { u.ondrag = null });

    taskItems.forEach(u => { u.addEventListener("drag", Drag) });

}

function DropMe(dotnetHelper) {

    
    //const taskItems = document.querySelectorAll(".task-item");

    //taskItems.forEach(u => { u.ondrag = null });

    //taskItems.forEach(u => { u.addEventListener("drag", Drag) });
        

    const menuItems = document.querySelectorAll(".drop-menu");

    menuItems.forEach(u => { u.ondrag = null });

    menuItems.forEach(u => { u.addEventListener("drop", Drop); });

    async function Drop(e) {
        e.stopPropagation();
        e.preventDefault();
        const memberId = e.currentTarget.id;
        const taskId = document.querySelector("#dragTaskId").value;

        console.log('Called Api')
        await dotnetHelper.invokeMethodAsync("AssignTaskToMember", taskId.toString(), memberId.toString())

        document.querySelector("#dragTaskId").value = "";

    }

    menuItems.forEach(u => u.addEventListener("dragover", allowDrop));

    menuItems.forEach(u => { u.ondragover = null });

    function allowDrop(e) {
        e.stopPropagation();
       // console.log("Allow drop");
        e.preventDefault();
    }

}
    
