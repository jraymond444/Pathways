
window.onload = function(){
    document.getElementById("toDo").addEventListener("keydown",function(event){
    if (event.key === "Enter"){
        event.preventDefault();
        validateAndAdd();
        }
    });
}

function validateAndAdd() {
    // place the values in the form into variables
    let newToDo = document.forms["myForm"]["toDo"].value;
    // validate that something was entered as a word
    if (newToDo == "") {
      // no word was entered so tell the user
      alert("Please enter a word to check");
      return;
    }
    //grab the body for incomplete list and add a new row, then move newToDo value to the first cell in that row
    let tableBodyToDo = document.getElementById("incompleteList").getElementsByTagName("tbody")[0];
    const newRow = tableBodyToDo.insertRow();    
    const taskCell = newRow.insertCell(0);
    taskCell.textContent = newToDo;

    //add a second cell to that row that will contain 2 buttons for completeing and deleteing tasks.  these button clicks will perform their respective functions
    const buttonCell = newRow.insertCell(1);
    const completeButton = document.createElement("button");
    completeButton.innerHTML = "&#10003;";
    completeButton.classList.add("complete-button");
    //completeButton.textContent = "Complete";
    completeButton.onclick = () => completeTask(newRow, newToDo);

    const deleteButton = document.createElement("button");
    deleteButton.innerHTML = "&#10007;";
    deleteButton.classList.add("delete-button");
    //deleteButton.textContent = "Remove task";
    deleteButton.onclick = () => deleteTask(newRow);
    //displays the buttons
    buttonCell.appendChild(completeButton);
    buttonCell.appendChild(deleteButton);
    //clear the form for input
    document.forms["myForm"]["toDo"].value = "";
}
//function deletes a row
function deleteTask(row){
    row.remove();
}
//function deletes a row from the current table and adds the value to the completed list table
function completeTask(row, task){
    row.remove();

    let tableBodyCompleted = document.getElementById("completedList").getElementsByTagName("tbody")[0];
    const newRowCompleted =tableBodyCompleted.insertRow();

    const completedCell = newRowCompleted.insertCell(0);
    completedCell.textContent = task
    checkCompleted();
}
//function that clears everything
function clearAll() {
    // clear the tables
    let table1 = document.getElementById("incompleteList");
    table1.innerHTML = "";
    let table2 = document.getElementById("completedList");
    table2.innerHTML = "";
}

//check if the list is done
function checkCompleted(){
    const incompleteListBody = document.getElementById("incompleteList").getElementsByTagName("tbody")[0];
    const completeListBody = document.getElementById("completedList").getElementsByTagName("tbody")[0];

    if (incompleteListBody.rows.length === 0 && completeListBody.rows.length > 0)
        Fireworks();
}

//celebrate a job well done with fireworks
function Fireworks(){
    confetti({
        particleCount: 1000,
        spread: 200,
        origin: {y:0.1}
    });
    confetti({
        particleCount: 1200,
        spread: 250,
        origin: {y:0.5}
    });
    confetti({
        particleCount: 1000,
        spread: 200,
        origin: {y:0.8}
    });
    const messageElement = document.getElementById("congratsMessage");
    messageElement.classList.add("show-message");
    setTimeout(() => {
        messageElement.classList.remove("show-message");
    }, 1000);


}


