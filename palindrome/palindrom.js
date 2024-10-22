function validateANDadd() {
    // place the values in the form into variables
    let theNewWord = document.forms["myForm"]["newWord"].value;
    // validate that something was entered as a word
    if (theNewWord == "") {
      // no word was entered so tell the user
      alert("Please enter a word to check");
      return false;
    }
    else {
        // a word was entered and a 1 or 2 was entered as the number 
        // so add the word to the proper table
        if(PalindromCheck1(theNewWord))
            {
              let tableRef = document.getElementById("myList1");
              (tableRef.insertRow(tableRef.rows.length)).innerHTML = theNewWord ;}
        else {var tableRef = document.getElementById("myList2");
              (tableRef.insertRow(tableRef.rows.length)).innerHTML = theNewWord ;}
        // erase the form fields
        document.forms["myForm"]["newWord"].value = "";
        return true;
    }
  }

  function clearList1() {
    // clear the table of all rows
    var tableRef = document.getElementById("myList1");
    tableRef.innerHTML = " ";
  }

  function clearList2() {
    // clear the table of all rows
    var tableRef = document.getElementById("myList2");
    tableRef.innerHTML = " ";
  }

  function PalindromCheck1(theword){
    // This algorithm creates a string that is the reverse 
    //   of the original string and then compares the strings 

    // create a string the reverse of the original
        // Step 1. Use the split() method to return a new array of characters
        // Step 2. Use the reverse() method to reverse the new created array
        // Step 3. Use the join() method to join all elements of the array into a string
    let reverseword = theword.split("").reverse().join("");  // thank you freecodecamp.com
    // compare them using the ===
    return theword === reverseword;
  }

