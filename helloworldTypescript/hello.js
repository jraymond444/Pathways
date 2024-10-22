function myFunction() {
    var newName = " ";
    newName = document.getElementById("fname").value;
    console.log(newName);
    document.getElementById("greeting").innerHTML = "Even more and more splendid greetings " + newName + " !!";
}
