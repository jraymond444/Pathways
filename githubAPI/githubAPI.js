window.onload = function(){
    document.getElementById("newUser").addEventListener("keydown",function(event){
    if (event.key === "Enter"){
        event.preventDefault();
        getAnotherUser();
        }
    });
}

async function getAnotherUser() {

    // first build the API call string by starting with the URL
    var apiString = "https://api.github.com/users";
    // next add the user parameter to the string using the textbox and add / repos to the string
    var inpUser = document.getElementById('newUser').value;
    apiString = apiString + "/" + inpUser + "/repos";

    // now use the fetch API to make the HTTP request
    var response = await fetch(apiString);  //note response is a promise object
    // read the response as JSON since it is a JSON file
    var jsonData = await response.json();   

    // next, check to see if data was returned and provide the proper message or information
    var theNewRepos = "";   // this string will store what to display to the user
    if (jsonData.message == "Not Found") {    // the github API returns this in the JSON file if not found
      theNewRepos = "That user was not found."
    }
    else {       // the repo was found so build a string with all the repos and their links
      for (var aRepos in jsonData) {
        theNewRepos += "<p><a href=" + jsonData[aRepos].html_url + ">" + jsonData[aRepos].name + "</a></p>";
        if (jsonData[aRepos].description){
            theNewRepos += "<p>Description: " + jsonData[aRepos].description + "</p>";
        }
        theNewRepos += "<p><a href='" + jsonData[aRepos].html_url + "/compare/master...HEAD'>Compare Changes<a/></p>";

        theNewRepos += "<p>Languages: " + jsonData[aRepos].languages_url + "</p>";

        theNewRepos += "<hr>"; 
      }
    } // end else

    // finally, print both the quote and the authoer
    document.getElementById("newUser").innerHTML = "";   // clear what was previously shown
    document.getElementById("theRepos").innerHTML = "";   // clear what was previously shown
    // print out the information for the user and clear the userid
    document.getElementById("newUser").innerHTML = newUser;
    document.getElementById("theRepos").innerHTML = theNewRepos;
    document.getElementById('newUser').value = "";

    //finally scroll back to the top of the page
    window.scrollTo(0,0);
  
    return true;
  }